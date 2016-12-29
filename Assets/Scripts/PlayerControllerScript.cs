using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CharacterMovementScript))]
public class PlayerControllerScript : MonoBehaviour {

    public int playerId = 0;

    public delegate void PlayerControlDelegate(float horizontal, float vertical, bool jump);
    public event PlayerControlDelegate PlayerControlEvent;

    public delegate void PlayerActionDelegate();
    public event PlayerActionDelegate PlayerActionEvent;

    CharacterMovementScript characterMovement;

    private ConsoleObject actionable;
    private bool isConnected;

    private static string HORIZONTAL = "Horizontal_";
    private static string VERTICAL = "Vertical_";
    private static string JUMP = "Jump_";
    private static string ACTION = "Action_";

    // Use this for initialization
    void Awake ()
    {
        characterMovement = GetComponent<CharacterMovementScript>();
        characterMovement.AddController(this);
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        float h = Input.GetAxis(HORIZONTAL+playerId);
        float v = Input.GetAxis(VERTICAL+playerId);
        
        if (PlayerControlEvent != null)
        {
            PlayerControlEvent(h, v, Input.GetButtonDown(JUMP+playerId));
        }

	}

    void Update()
    {
        if (PlayerActionEvent != null)
        {
            if (Input.GetButtonDown(ACTION+playerId))
            {
                PlayerActionEvent();
            }
        }
    }

    public void SetConnected()
    {
        if(isConnected)
        {
            actionable.DisconectPlayer(this);
            characterMovement.AddController(this);
            isConnected = false;
        }
        else
        {
            characterMovement.RemoveController(this);
            actionable.ConnectPlayer(this);
            isConnected = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Actionable")
        {
            Debug.Log("Player On Actionable");
            actionable = other.GetComponent<ConsoleObject>();
            PlayerActionEvent += SetConnected;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Actionable")
        {
            Debug.Log("Player On Actionable");
            actionable = null;
            PlayerActionEvent -= SetConnected;
        }
    }

}