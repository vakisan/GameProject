using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Create", menuName = "Collectible")]
public class Collectible : ScriptableObject
{
   public string collectibleName, description;

   public int value;
   public Sprite collectibleIcon;

   public CollectibleType collectibleType;

}

public enum CollectibleType {
        Memo,
        Coin
    }
