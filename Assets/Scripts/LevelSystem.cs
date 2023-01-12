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

    private Timer timer;
    // Start is called before the first frame update
    void Awake()
    {
        level = 1;
        difficulty = 10;
        levelMessage = GameObject.Find("LevelChangeMessage").GetComponent<TMP_Text>();
        levelUISystem = GetComponent<LevelUISystem>();
        timer = GetComponent<Timer>();
    }

    public int GetLevel()
    {
        return level;
    }

    public void SetLevel(int newLevel){
        this.level = newLevel;
    }

    public int GetDifficulty(){
        return difficulty;
    }

    public void displayIncreasedLevelMessage(bool display){
        levelMessage.enabled = true;
        level++;
        levelMessage.text = "Congratulations! You have reached Level " + level; 
        // this.level += difficulty
    }

    IEnumerator Wait(){
        yield return new WaitForSeconds(5);
    }

    public void PlayerLevelUpdate(int coins){
        levelUISystem.GainExperienceManual(coins);
    }
}
