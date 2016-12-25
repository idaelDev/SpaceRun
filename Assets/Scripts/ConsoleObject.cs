using System;   
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsoleObject : AbstractActionable{

    public AbstractControllable target;

    private bool isPlayerConnected;
    private PlayerControllerScript playerInControl = null;

    public override void Action(PlayerControllerScript controler)
    {
        if(!isPlayerConnected)
        {
            isPlayerConnected = true;
            playerInControl = controler;
            controler.SetConnected(true);
            target.AddController(controler);
        }
        else if(playerInControl == controler)
        {
            isPlayerConnected = false;
            playerInControl.SetConnected(false);
            target.RemoveController(playerInControl);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            if(!isPlayerConnected)
            {
                AddActioner(other.gameObject.GetComponent<PlayerControllerScript>());
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Player out");
            RemoveActioner(other.gameObject.GetComponent<PlayerControllerScript>());
        }
    }

}
