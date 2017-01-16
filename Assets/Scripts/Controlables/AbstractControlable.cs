using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class is a template for every controlable component of the ship. 
/// Reactor, weapon and every other object that player can control must inherit this class.
/// </summary>

public abstract class AbstractControlable : MonoBehaviour{
    
    /// <summary>
    /// Call when the player take control of this object
    /// </summary>
    /// <param name="control"></param>
    public void AddController(PlayerControllerScript control)
    {
        control.PlayerControlEvent += Control;
        control.PlayerActionEvent += OnAction;
    }

    /// <summary>
    /// Call when the player stop to control this opbject
    /// </summary>
    /// <param name="control"></param>
    public void RemoveController(PlayerControllerScript control)
    {
        control.PlayerControlEvent -= Control;
        control.PlayerActionEvent -= OnAction;
    }

    /// <summary>
    /// Must be override,
    /// This function take player input
    /// </summary>
    /// <param name="horizontal"></param>
    /// <param name="vertical"></param>
    /// <param name="jump"></param>
    public abstract void Control(float horizontal, float vertical);

    public abstract void OnAction(bool action);

}
