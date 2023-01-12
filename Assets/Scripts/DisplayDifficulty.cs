using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayDifficulty : MonoBehaviour
{

    string message;

    readonly string[] difficulties = {"Novice", "Easy", "Average", "Hard", "Advanced", "Extreme", "Hardware is your Friend"};

    void Awake(){
        CalculateMessage();
    }
    // Start is called before the first frame update
    public void IncreaseDifficulty()
    {
        CalculateMessage();
        // LevelSystem.difficulty = (LevelSystem.difficulty /10)*10;
        gameObject.GetComponent<TMPro.TMP_Text>().text = "Difficulty: " + message + " " + LevelSystem.difficulty; 
    }

    // Update is called once per frame
    void CalculateMessage()
    {   
        if(LevelSystem.difficulty/10 < difficulties.Length) {
            message = difficulties[LevelSystem.difficulty/10];
        }
        else{
            message = difficulties[0];
            LevelSystem.difficulty = 0;
        }

        LevelSystem.difficulty += 10;

    }
}
