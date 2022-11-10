// using System;
// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.UI;

// public class InventoryManager : MonoBehaviour
// {
//     private static Inventory inventory;
//     public List<CollectibleObject> list;
//     public Transform inventoryContent;
//     public GameObject inventoryCollectible;

//     public void Awake(){
//         if(inventory == null){
//             inventory = new Inventory();
//         }
//         Debug.Log("Created Inventory");
//     }

//     public void Update(){
//         list = inventory.getCollectibleList(CollectibleObject.Type.memo);   
//     }

//     public static Inventory GetInventory(){
//         return inventory;
//     }

//     public static int getCollectibleCount(CollectibleObject.Type collectibleType){
//         return inventory.getCollectibleList(collectibleType).Count;
//     }

//     public void DisplayCollectibles(){
//         foreach(CollectibleObject.Type collectibleType in Enum.GetValues(typeof(CollectibleObject.Type))){
//            foreach(CollectibleObject collectibleObject in inventory.getCollectibleList(collectibleType)){
//                 GameObject gameObject = Instantiate(inventoryCollectible,inventoryContent);
//                 var collectibleName = gameObject.transform.Find("Collectible").GetComponent<Text>();
//                 var collectibleImage = gameObject.transform.Find("Collectible").GetComponent<Image>();
                
//                 collectibleName.text = collectibleObject.collectibleName;
//                 collectibleImage.sprite = collectibleObject.collectibleIcon; 
//            }
//         };
//     }
// }
