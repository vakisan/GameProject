using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEngine.SceneManagement;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveStateManager : MonoBehaviour
{ 
    public Button savePlayer;
    public Button loadPlayer;
    public LevelSystem levelSystem;
    LevelUISystem levelUISystem;
    PlayerHealth playerHealth;

    public GameObject player;

    Timer timer;

    public bool doesSaveExit;

    void OnEnable()
    {
        if(SceneManager.GetActiveScene().name == "Game"){
            savePlayer.onClick.AddListener(() => SavePlayerStateToPause());
            loadPlayer.onClick.AddListener(() => LoadPlayerState());
        }
    }

    void OnDisable()
    {
        //Un-Register Button Events
        if(SceneManager.GetActiveScene().name == "Game"){
            savePlayer.onClick.RemoveAllListeners();
            loadPlayer.onClick.RemoveAllListeners();
        }
    }
    void Awake(){
        if(SceneManager.GetActiveScene().name == "Game"){
        player = GameObject.Find("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
        levelSystem = GameObject.Find("LevelSystem").GetComponent<LevelSystem>();
        levelUISystem = levelSystem.GetComponent<LevelUISystem>();
        savePlayer = savePlayer.GetComponent<Button>();
        loadPlayer = loadPlayer.GetComponent<Button>();
        timer = levelSystem.GetComponent<Timer>();
        doesSaveExit = DoesSaveExit();

        }
    }

    public void SavePlayerState(){
        if(SceneManager.GetActiveScene().name == "Game"){
        SavePlayer savePlayer = new SavePlayer(playerHealth,levelUISystem,player.transform,timer, levelSystem);
        Debug.Log(savePlayer.health);
        Debug.Log(transform);

        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/Player.fun";
        FileStream stream = new FileStream(path,FileMode.Create);

        formatter.Serialize(stream,savePlayer);

        stream.Close();
        }
    }

    public void SavePlayerStateToPause(){
        SavePlayerState();
        SceneManagementSystem.pauseButtonInGame();
    }

    public void LoadPlayerState(){
        if(SceneManager.GetActiveScene().name == "Game"){
        string path = Application.persistentDataPath + "/Player.fun";
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream fileStream = new FileStream(path,FileMode.Open);

        SavePlayer save = formatter.Deserialize(fileStream) as SavePlayer;
        playerHealth.SetHealth(save.health);
        levelUISystem.level = save.level;
        player.GetComponent<CharacterController>().enabled = false;
        player.transform.position = new Vector3(save.position[0],save.position[1],save.position[2]);
        player.GetComponent<CharacterController>().enabled = true;

        levelSystem.SetLevel(save.gameLevel);
        timer.timeValue = save.timeValue;
        Debug.Log("");

        // Vector3 diff = transform.TransformDirection(new Vector3(save.position[0],save.position[1],save.position[2]) - player.transform.position);
        // player.GetComponent<CharacterController>().Move(diff);
        fileStream.Close();
        }
    }

    public static void DeleteState(){
        // if(SceneManager.GetActiveScene().name == "Game"){
            string path = Application.persistentDataPath + "/Player.fun";
            if(File.Exists(path)){
                File.Delete(path);
            // }
        }
    }

    public bool DoesSaveExit(){
        string path = Application.persistentDataPath + "/Player.fun";
        return File.Exists(path);
    }


}
