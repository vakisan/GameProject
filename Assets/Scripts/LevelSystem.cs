using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelSystem : MonoBehaviour
{

    private int level;

    private int difficulty;

    public TMP_Text levelMessage;

    public LevelUISystem levelUISystem;
    // Start is called before the first frame update
    void Awake()
    {
        level = 1;
        difficulty = 10;
        levelMessage = GameObject.Find("LevelChangeMessage").GetComponent<TMP_Text>();
        levelUISystem = GetComponent<LevelUISystem>();
    }

    public int GetLevel()
    {
        return level;
    }

    public int GetDifficulty(){
        return difficulty;
    }

    private void increaseLevel(int difficulty=1){
        levelMessage.enabled = true;
        level++;
        levelMessage.text = "Congratulations! You have reached Level " + level; 
        this.level += difficulty;
    }

    public void displayIncreasedLevelMessage(bool display){
        increaseLevel();
        levelMessage.enabled = display;
    }

    public void PlayerLevelUpdate(int coins){
        levelUISystem.GainExperienceManual(coins);
    }
}
