using System;   
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class is a console object.
/// This manage connection between a player character and a controlable object
/// </summary>
public class ConsoleObject : MonoBehaviour{

    /// <summary>
    /// The targeted controlable object
    /// </summary>
    public AbstractControlable target;
    /// <summary>
    /// Flag if the console is already in use
    /// </summary>
    private bool isOccupied;
    
    /// <summary>
    /// Connect the player to the controlable
    /// </summary>
    /// <param name="player"></param>
    /// <returns></returns>
    public bool ConnectPlayer(PlayerControllerScript player)
    {
        if (isOccupied)
            return false;
        target.AddController(player);
        isOccupied = true;
        return true;
    }

    /// <summary>
    /// Disconnect player 
    /// </summary>
    /// <param name="player"></param>
    public void DisconectPlayer(PlayerControllerScript player)
    {
        isOccupied = false;
        target.RemoveController(player);
    }

}
