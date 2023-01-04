using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public void startGame() 
    {
        SceneManager.LoadScene("World");
    }

    public void saveGame() 
    {
        // save game code here
    }

    public void settings(){
        //open game setting scenes
    }
 

    public void gameEnd() 
    {
        Application.Quit();
    }
}
