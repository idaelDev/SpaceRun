using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractControllable : MonoBehaviour{
    
    public void AddController(PlayerControllerScript control)
    {
        control.PlayerControlEvent += Control;
    }

    public void RemoveController(PlayerControllerScript control)
    {
        control.PlayerControlEvent -= Control;
    }

    public abstract void Control(float horizontal, float vertical, bool jump);

}
