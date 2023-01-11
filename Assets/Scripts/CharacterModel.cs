using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/CharacterModel", order = 1)]
public class CharacterModel : ScriptableObject
{
    public int coin;

    public bool memo;

    public string memoDetail;

    public string dialogue;

    public void BuildCharacterModel(int coin, bool memo, string memoDetail,string dialogue){
        this.coin = coin;
        this.memo = memo;
        this.memoDetail = memoDetail;
        this.dialogue = dialogue;
    }

}
