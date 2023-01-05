using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*This class should be passed as an object to 
gameobjects that require input reading. Please Add futher
Actions Maps here if needed.
*/
public class InputManager : MonoBehaviour
{
    private PlayerControl playerControl;

    void Awake()
    {
        playerControl = new PlayerControl();
        Debug.Log("Created Player Control");
    }

    private void OnEnable()
    {
        playerControl.Land.Enable();
        Debug.Log("Land Action Map Enabled");
    }

    public PlayerControl getPlayerControl(){
        return playerControl;
    }

}
