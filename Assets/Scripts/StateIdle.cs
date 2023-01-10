using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateIdle : State
{   
    public bool isPlayerVisible;
    public StateChase stateChase;

    public override State RunCurrentState()
    {
        if(isPlayerVisible){
            return stateChase;
        }

        return this;
    }
}
