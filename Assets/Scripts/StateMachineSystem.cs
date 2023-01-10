using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachineSystem : MonoBehaviour
{   
    public State currentState;


    void RunStateMachine(){
        State nextState = currentState?.RunCurrentState();

        if(nextState != null){
            // switch to next state;
            SwitchNextState(nextState);
        }
    }

    void SwitchNextState(State nextState){

    }

    // Update is called once per frame
    void Update()
    {
        RunStateMachine();
    }
}
