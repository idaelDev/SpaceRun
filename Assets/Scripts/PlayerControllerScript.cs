using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CharacterMovementScript))]
public class PlayerControllerScript : MonoBehaviour {

    public delegate void PlayerControlDelegate(float horizontal, float vertical, bool jump);
    public event PlayerControlDelegate PlayerControlEvent;

    public delegate void PlayerActionDelegate(PlayerControllerScript controler);
    public event PlayerActionDelegate PlayerActionEvent;

    CharacterMovementScript characterMovement;

	// Use this for initialization
	void Awake ()
    {
        characterMovement = GetComponent<CharacterMovementScript>();
        characterMovement.AddController(this);
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        if (PlayerControlEvent != null)
        {
            PlayerControlEvent(h, v, Input.GetButtonDown("Jump"));
        }
        if (PlayerActionEvent != null)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                PlayerActionEvent(this);
            }
        }
	}

    public void SetConnected(bool connected)
    {
        if(connected)
        {
            characterMovement.RemoveController(this);
        }
        else
        {
            characterMovement.AddController(this);
        }
    }
}