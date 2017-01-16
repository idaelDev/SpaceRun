using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Reactor controllable object.
/// Give the controle of the ship to the player
/// </summary>
public class ControlableReactor : AbstractControlable {


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public override void Control(float horizontal, float vertical)
    {
        throw new NotImplementedException();
    }

    public override void OnAction(bool action)
    {
        throw new NotImplementedException();
    }
}
