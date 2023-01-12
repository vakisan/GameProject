using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField]
    public float timeValue = 30;
    [SerializeField]
    public float originaTimeValue = 30 ;
    [SerializeField]
    private TMP_Text timerTextUI;
    private TMP_Text LevelTextUI;
    // Start is called before the first frame update

    [SerializeField]
    private Light sunLight;
    [SerializeField]
    private double sunLightRotation;
    [SerializeField]
    private double sunset;

    [SerializeField]
    private LevelSystem levelSystem;

    [SerializeField]
    private CharacterSpawner characterSpawner;

    private EnemySpawner enemySpawner;
    
    private CutScene cutScene;

    private SaveStateManager saveStateManager;

    [SerializeField]
    private int rotationSpeed = 1;

    private PlayerHealth playerHealth;

    public static bool isSunset;

    public static bool shouldStateBeLoaded = false;

    public static bool shouldGameBeLoaded = false;

    void Awake(){
        saveStateManager = GameObject.Find("SaveSystem").GetComponent<SaveStateManager>();
        playerHealth = GameObject.Find("Player").GetComponent<PlayerHealth>();
        cutScene = GetComponent<CutScene>();
        timerTextUI = GameObject.Find("Timer").GetComponent<TMP_Text>();
        LevelTextUI = GameObject.Find("PrefixTimer").GetComponent<TMP_Text>(); 
        originaTimeValue = timeValue;
        sunset = 0.5 * originaTimeValue;
        characterSpawner = GetComponent<CharacterSpawner>();
        enemySpawner = GetComponent<EnemySpawner>();
        levelSystem = GetComponent<LevelSystem>();
    }

    void Start(){
        saveStateManager.LoadPlayerState();
        // saveStateManager.SavePlayerState();
    }

    void DisplayTimer(float displayTime)
    {
        if(displayTime < 0){
            displayTime = 0;
        }

        float minutes = Mathf.FloorToInt(displayTime/60);
        float seconds = Mathf.FloorToInt(displayTime % 60);
        
        timerTextUI.text = string.Format("{0:00}:{1:00}",minutes,seconds);
        LevelTextUI.text = "Time to Clear Level " + levelSystem.GetLevel().ToString();
    }

    void rotateSunlight(){
        double sunligthRatio = timeValue/originaTimeValue;
        sunset = originaTimeValue * 0.5;
        isSunset = timeValue < sunset;

        sunLightRotation = Mathf.Lerp(270,0,(float) sunligthRatio) * rotationSpeed;

        sunLight.transform.rotation = Quaternion.AngleAxis((float) sunLightRotation, Vector3.right);
    }

    // Update is called once per frame
    void Update()
    {   
        if(shouldGameBeLoaded){
            shouldGameBeLoaded = false;
            if(shouldStateBeLoaded){
                shouldStateBeLoaded = false;
                if(saveStateManager.DoesSaveExit()){
                    saveStateManager.LoadPlayerState();
                    SceneManagementSystem.Resume();
                }
                else{
                    SceneManagementSystem.StartNewGame();
                }
            }
            else{
                SceneManagementSystem.StartNewGame();
            }
        }
        
        if(timeValue > 0){
            timeValue-=Time.deltaTime;
        }
        else if(timeValue <= 0){
            SceneManagementSystem.MainMenu();
            timeValue = originaTimeValue;
        }

        if(timeValue + 2 > originaTimeValue){
            cutScene.SwitchOnCamera();
            rotationSpeed = 20;
        }
        else{
            cutScene.SwitchOffCamera();
            rotationSpeed = 1;
        }

        FormatTimerColour();
        rotateSunlight();
        DisplayTimer(timeValue);
    }

    IEnumerator Wait(){
        yield return new WaitForSeconds(2);
    }

    void FormatTimerColour(){
        if(timeValue < originaTimeValue*0.1){
            timerTextUI.color = Color.red;
        }
        else if(timeValue < originaTimeValue*0.5){
            timerTextUI.color = Color.yellow;
        }
        else{
            timerTextUI.color = Color.green;
        }
    }

    public void IncrementLevel(){
        playerHealth.RestoreHealth(originaTimeValue);
        saveStateManager.SavePlayerState();
        cutScene.SwitchOnCamera();
        cleanUpLevel();
        levelSystem.displayIncreasedLevelMessage(true);
        // originaTimeValue = originaTimeValue + 10;
        // timeValue = -10;
        timeValue = 30 + 10 * levelSystem.GetLevel();
        originaTimeValue = 30 + 10 * levelSystem.GetLevel();
    }

    void cleanUpLevel(){
        // Wait();
        characterSpawner.RemoveCharacters();
        characterSpawner.SpawnCharacters();
        enemySpawner.SpawnCharacters();
    }
}
