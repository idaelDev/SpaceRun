using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractActionable : MonoBehaviour {

    public void AddActioner(PlayerControllerScript control)
    {
        control.PlayerActionEvent += Action;
    }

    public void RemoveActioner(PlayerControllerScript control)
    {
        control.PlayerActionEvent -= Action;
    }

    public abstract void Action(PlayerControllerScript controler);
}
