using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSpawner : MonoBehaviour
{

    public GameObject road;
    public GameObject npcCharacter;

    public List<CharacterModel> charactersList;
    public List<GameObject> characterGameObjectList;

    public GameObject NPCParent;
    //LEVL LIST

    private float road_x;
    private float road_z; 

    [SerializeField]
    public int difficulty = 2;
    [SerializeField]
    public int difficultyFactor = 1;
    [SerializeField]
    private float edgeOffset = 10;
    // Start is called before the first frame update
    void Start()
    {   
        Collider collider = road.GetComponent<Collider>();
        road_x = (collider.bounds.size.x * collider.transform.localScale.x) - edgeOffset;
        road_z = (collider.bounds.size.z * collider.transform.localScale.z) - edgeOffset;

        SpawnCharacters();
    }

    void createCharacters(){
        difficulty += Random.Range(difficultyFactor,difficulty);
        charactersList = new List<CharacterModel>();
        int range = difficulty;
        for(int i= 0; i<range; i++){
            int coin = (Random.Range(0,500));
            CharacterModel characterModel = CharacterModel.CreateInstance<CharacterModel>();
            characterModel.BuildCharacterModel(coin,false,"",new CharacterDialogue().getDialogue());
            charactersList.Add(characterModel);
        }
        int specialCharacter = Random.Range(0,range-1);
        charactersList[specialCharacter].memo = true;
        charactersList[specialCharacter].memoDetail = "Found Special Memo";
    }

    public void SpawnCharacters(){
        createCharacters();
        characterGameObjectList = new List<GameObject>();
        foreach(CharacterModel characterModel in charactersList){
            GameObject character = Instantiate(npcCharacter,Vector3.zero, Quaternion.identity,NPCParent.transform) as GameObject;
            characterGameObjectList.Add(character);
            CharacterNPC instantiatedModel = character.GetComponent<CharacterNPC>();
            instantiatedModel.characterModel = characterModel;

            float x = Random.Range(-road_x,road_x);
            float z = Random.Range(-road_z,road_z);

            // Debug.Log(new Vector3(x,10,z));
            character.transform.position = new Vector3(x,10,z);
        }
    }

    public void RemoveCharacters(){
        foreach(GameObject character in characterGameObjectList){
            Destroy(character);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
