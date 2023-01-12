using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    public GameObject road;
    public GameObject enemy;

    private float road_x;
    private float road_z; 

    [SerializeField]
    public int difficulty = 2;
    [SerializeField]
    public int difficultyFactor = 1;
    [SerializeField]
    private float edgeOffset = 10;

    private LevelSystem levelSystem;

    // Start is called before the first frame update
    void Start()
    {   
        Collider collider = road.GetComponent<Collider>();
        road_x = (collider.bounds.size.x * collider.transform.localScale.x) - edgeOffset;
        road_z = (collider.bounds.size.z * collider.transform.localScale.z) - edgeOffset;
        levelSystem = GameObject.Find("LevelSystem").GetComponent<LevelSystem>();
        SpawnCharacters();
    }

    public void SpawnCharacters(){
        for(int i = 0; i< levelSystem.GetLevel()/difficulty; i++ ){
            GameObject character = Instantiate(enemy,Vector3.zero, Quaternion.identity,transform) as GameObject;

            float x = Random.Range(-road_x,road_x);
            float z = Random.Range(-road_z,road_z);

            // Debug.Log(new Vector3(x,10,z));
            character.transform.position = new Vector3(x,10,z);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
