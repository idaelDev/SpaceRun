using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CharacterMovementScript))]
public class PlayerControllerScript : MonoBehaviour {

    public int playerId = 0;

    public delegate void PlayerControlDelegate(float horizontal, float vertical);
    public event PlayerControlDelegate PlayerControlEvent;

    public delegate void PlayerActionPresssedDelegate(bool pressed);
    public event PlayerActionPresssedDelegate PlayerActionEvent;

    public delegate void PlayerConnectDelegate();
    public event PlayerConnectDelegate PlayerConnectEvent;

    CharacterMovementScript characterMovement;

    private ConsoleObject actionable;
    private bool isConnected;

    private static string HORIZONTAL = "Horizontal_";
    private static string VERTICAL = "Vertical_";
    private static string ACTION = "Jump_";
    private static string CONNECT = "Action_";

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
            PlayerControlEvent(h, v);
        }

        if(Input.GetButtonDown(ACTION+playerId))
        {
            PlayerActionEvent(true);
        }
        else if(Input.GetButtonUp(ACTION + playerId))
        {
            PlayerActionEvent(false);
        }

	}

    void Update()
    {
        if (PlayerActionEvent != null)
        {
            if (Input.GetButtonDown(CONNECT+playerId))
            {
                PlayerConnectEvent();
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

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Actionable")
        {
            Debug.Log("Player On Actionable");
            actionable = other.GetComponent<ConsoleObject>();
            PlayerConnectEvent += SetConnected;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Actionable")
        {
            Debug.Log("Player On Actionable");
            actionable = null;
            PlayerConnectEvent -= SetConnected;
        }
    }

}