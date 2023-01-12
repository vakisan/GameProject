using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using System.IO;

public class SceneManagementSystem : MonoBehaviour
{
    private SaveStateManager saveStateManagerInstance;

    public static bool soundEnabled = true;

    bool paused;

    void Awake(){
        // if(SceneManager.GetActiveScene().name == "Game"){
        saveStateManagerInstance = GameObject.Find("SaveSystem").GetComponent<SaveStateManager>();
        // }
        if(saveStateManagerInstance != null){
            // DontDestroyOnLoad(saveStateManagerInstance);
        }
    }

    public static void StartNewGame() 
    {
        SaveStateManager.DeleteState();
        SceneManager.LoadScene("Game");
    }

    public static void MainMenu() 
    {
        SceneManager.LoadScene("Start");
    }

    public void gameEnd() 
    {
        Application.Quit();
    }

    public void pause() 
    {
        saveStateManagerInstance.SavePlayerState();
        SceneManager.LoadScene("Pause");
    }

    public static void pauseButtonInGame() 
    {
        SceneManager.LoadScene("Pause");
    }

    public void back() 
    {
        SceneManager.LoadScene("Pause");
    }

    public static void Resume(){
        SceneManager.LoadScene("Game");
        // saveStateManagerInstance.LoadPlayerState();
    }

    public void settings(){
        SceneManager.LoadScene("Setting");
    }

    public void DisableSounds(){
        soundEnabled = !soundEnabled;
        AudioListener.pause = soundEnabled;
    }

    public static void SetStartGameNoSave(){
        Timer.shouldGameBeLoaded = true;
        Timer.shouldStateBeLoaded = false;
        // SceneManager.LoadScene("Game");
    }

    public static void SetLoadGameWithSave(){
        Timer.shouldGameBeLoaded = true;
        Timer.shouldStateBeLoaded = true;
    }

    public static void DeleteGameSaveOnly(){
        SaveStateManager.DeleteState();
    }

}
