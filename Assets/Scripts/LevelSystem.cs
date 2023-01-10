using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelSystem : MonoBehaviour
{

    private int level;

    private int difficulty;

    public TMP_Text levelMessage;
    // Start is called before the first frame update
    void Awake()
    {
        level = 1;
        difficulty = 10;
        levelMessage = GameObject.Find("LevelChangeMessage").GetComponent<TMP_Text>();
    }

    public int GetLevel()
    {
        return level;
    }

    public int GetDifficulty(){
        return difficulty;
    }

    public void increaseLevel(int difficulty=1){
        levelMessage.enabled = true;
        levelMessage.text = "Congratulations! You have reached Level " + level; 
        this.level += difficulty;
    }

    public void displayLevelMessage(bool display){
        levelMessage.enabled = display;
    }
}
