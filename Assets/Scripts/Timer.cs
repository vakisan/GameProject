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
    
    private CutScene cutScene;

    void Awake(){

        cutScene = GetComponent<CutScene>();
        timerTextUI = GameObject.Find("Timer").GetComponent<TMP_Text>();
        originaTimeValue = timeValue;
        sunset = 0.5 * originaTimeValue;
        characterSpawner = GetComponent<CharacterSpawner>();
        levelSystem = GetComponent<LevelSystem>();
    }

    void DisplayTimer(float displayTime)
    {
        if(displayTime < 0){
            displayTime = 0;
        }

        float minutes = Mathf.FloorToInt(displayTime/60);
        float seconds = Mathf.FloorToInt(displayTime % 60);

        timerTextUI.text = string.Format("{0:00}:{1:00}",minutes,seconds);
    }

    void rotateSunlight(){
        double sunligthRatio = timeValue/originaTimeValue;

        sunLightRotation = Mathf.Lerp(270,0,(float) sunligthRatio);

        sunLight.transform.rotation = Quaternion.AngleAxis((float) sunLightRotation, Vector3.right);
    }

    // Update is called once per frame
    void Update()
    {   
        // if(timeValue > 2){
        //     cutScene.SwitchOnCamera();
        // }
        
        if(timeValue > 0){
            timeValue-=Time.deltaTime;
        }

        if(timeValue + 1 > originaTimeValue){
            cutScene.SwitchOnCamera();
        }
        else{
            cutScene.SwitchOffCamera();
        }

        FormatTimerColour();
        rotateSunlight();
        DisplayTimer(timeValue);
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

    void IncrementLevel(){
        cutScene.SwitchOnCamera();
        cleanUpLevel();
        levelSystem.displayIncreasedLevelMessage(true);
        originaTimeValue = originaTimeValue + 10;
        timeValue = -10;
    }

    void cleanUpLevel(){
        // Wait();
        characterSpawner.RemoveCharacters();
        characterSpawner.SpawnCharacters();

    }
}
