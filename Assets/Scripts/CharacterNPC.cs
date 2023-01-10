using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterNPC : MonoBehaviour
{

    public CharacterModel characterModel;

    public Rigidbody rigidbody;

    void Awake(){
        rigidbody = GetComponent<Rigidbody>();
    }
    // Start is called before the first frame update
    public void buildCharacter(bool coin, bool memo, string memoDetail,string dialogue)
    {
        characterModel.coin = coin;
        characterModel.memo = memo;
        characterModel.memoDetail = memoDetail;
        characterModel.dialogue = dialogue;
    }

    Rigidbody GetRigidbody(){
        return this.rigidbody;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
