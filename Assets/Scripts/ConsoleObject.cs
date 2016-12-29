using System;   
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsoleObject : MonoBehaviour{

    public AbstractControllable target;
    private bool isOccupîed;
    
    public bool ConnectPlayer(PlayerControllerScript player)
    {
        if (isOccupîed)
            return false;
        target.AddController(player);
        isOccupîed = true;
        return true;
    }

    public void DisconectPlayer(PlayerControllerScript player)
    {
        isOccupîed = false;
        target.RemoveController(player);
    }

}
