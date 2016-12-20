using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CharacterMovementScript))]
public class PlayerCharacterControlScript : MonoBehaviour {

    CharacterMovementScript characterMovement;

	// Use this for initialization
	void Awake () {
        characterMovement = GetComponent<CharacterMovementScript>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        characterMovement.Move(h, v);

        if (Input.GetButtonDown("Jump"))
        {
            characterMovement.Jump();
        }

	}
}
