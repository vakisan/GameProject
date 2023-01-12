using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SavePlayer
{   
    
    public float health;
    public int level;
    public float[] position; 

    public float timeValue;

    public int gameLevel;
    


    public SavePlayer(PlayerHealth playerHealth, LevelUISystem levelUISystem, Transform transform, Timer timer, LevelSystem levelSystem)
    {
        health = playerHealth.GetHealth();
        level = levelUISystem.GetPlayerLevel();
        position = new float[3];
        position[0] = transform.position.x;
        position[1] = transform.position.y;
        position[2] = transform.position.z;
        timeValue = timer.timeValue;
        gameLevel = levelSystem.GetLevel();
    }

}
