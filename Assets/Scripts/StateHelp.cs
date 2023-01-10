using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateHelp : State
{
    public override State RunCurrentState()
    {
        Debug.Log("Help");
        return this;
    }
}
