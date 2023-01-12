using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class SceneManagementSystem : MonoBehaviour
{
    private SaveStateManager saveStateManager;

    public static bool soundEnabled = true;

    bool paused;

    void Awake(){
        saveStateManager = GameObject.Find("SaveSystem").GetComponent<SaveStateManager>();
    }

    public void gameStart() 
    {
        SceneManager.LoadScene("Game");
        saveStateManager.LoadPlayerState();
    }

    public void gameEnd() 
    {
        Application.Quit();
    }

    public void pause() 
    {
        saveStateManager.SavePlayerState();
        SceneManager.LoadScene("Pause");
    }

    public void back() 
    {
        SceneManager.LoadScene("Pause");
    }

    public void Resume(){
        SceneManager.LoadScene("Game");
    }

    public void settings(){
        //open game setting scenes
        SceneManager.LoadScene("Settings");
    }

    public void increaseDifficulty(){

    }

    public void switchCamea(){

    }

    public void DisableSounds(){
        soundEnabled = !soundEnabled;
        AudioListener.pause = soundEnabled;
    }

}
