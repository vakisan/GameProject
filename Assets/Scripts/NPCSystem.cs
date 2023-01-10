using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCSystem : MonoBehaviour
{   
    [SerializeField]
    private GameObject LevelSystem;
    [SerializeField]
    // private CharacterSpawner characterSpawner;
    // Start is called before the first frame update
    void Awake()
    {
        LevelSystem = GameObject.Find("LevelSystem");
        // this.characterSpawner = LevelSystem.GetComponent<CharacterSpawner>();
    }

}
