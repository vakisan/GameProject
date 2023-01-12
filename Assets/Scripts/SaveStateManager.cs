using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
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

    bool isPaused;

    void OnEnable()
    {
        savePlayer.onClick.AddListener(() => SavePlayerState());
        loadPlayer.onClick.AddListener(() => LoadPlayerState());
    }

    void OnDisable()
    {
        //Un-Register Button Events
        savePlayer.onClick.RemoveAllListeners();
        loadPlayer.onClick.RemoveAllListeners();
    }
    void Awake(){
        player = GameObject.Find("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
        levelSystem = GameObject.Find("LevelSystem").GetComponent<LevelSystem>();
        levelUISystem = levelSystem.GetComponent<LevelUISystem>();
        savePlayer = savePlayer.GetComponent<Button>();
        loadPlayer = loadPlayer.GetComponent<Button>();

        timer = levelSystem.GetComponent<Timer>();

        Debug.Log(playerHealth);
        Debug.Log(levelUISystem);
        Debug.Log(player.transform);
        Debug.Log(timer);
        Debug.Log(levelSystem);
    }

    public void SavePlayerState(){
        SavePlayer savePlayer = new SavePlayer(playerHealth,levelUISystem,player.transform,timer, levelSystem);
        Debug.Log(savePlayer.health);
        Debug.Log(transform);

        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/Player.fun";
        FileStream stream = new FileStream(path,FileMode.Create);

        formatter.Serialize(stream,savePlayer);

        stream.Close();
        Debug.Log(true);
    }

    public void LoadPlayerState(){
        string path = Application.persistentDataPath + "/Player.fun";
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream fileStream = new FileStream(path,FileMode.Open);

        SavePlayer save = formatter.Deserialize(fileStream) as SavePlayer;
        Debug.Log(save.health);
        playerHealth.SetHealth(save.health);
        levelUISystem.level = save.level;
        Debug.Log("Before Loading " + player.transform.position);
        player.GetComponent<CharacterController>().enabled = false;
        player.transform.position = new Vector3(save.position[0],save.position[1],save.position[2]);
        Debug.Log("After Loading" + player.transform.position);
        player.GetComponent<CharacterController>().enabled = true;

        levelSystem.SetLevel(save.gameLevel);
        timer.timeValue = save.timeValue;
        Debug.Log("");

        // Vector3 diff = transform.TransformDirection(new Vector3(save.position[0],save.position[1],save.position[2]) - player.transform.position);
        // player.GetComponent<CharacterController>().Move(diff);
        fileStream.Close();
    }


}
