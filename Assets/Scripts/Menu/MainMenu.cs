using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void gameStart() 
    {
        SceneManager.LoadScene("World");
    }

    public void gameEnd() 
    {
        Application.Quit();
    }
}
