using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateChase : State
{
    public bool isPlayerAttackable;
    public StateAttack stateAttack;

    public override State RunCurrentState()
    {
        if(isPlayerAttackable){
            return stateAttack;
        }
        else{     
            return this;
        }
    }
}
