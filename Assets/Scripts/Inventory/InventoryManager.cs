using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    private static InventoryManager inventoryManager;
    private Dictionary<CollectibleType,List<Collectible>> inventoryList;
    public Transform inventoryContent;
    public GameObject inventoryCollectible;

    public TMP_Text currentItemDescription;

    public List<Collectible> currentItemList = null;
    public int currentItem;

    public void Awake(){
        if(inventoryManager == null){
            inventoryManager = this;
            inventoryList = new Dictionary<CollectibleType, List<Collectible>>();
            foreach(CollectibleType collectibleType in Enum.GetValues(typeof(CollectibleType))){
                inventoryList[collectibleType] = new List<Collectible>();
            }
            currentItem = 0;
            Debug.Log(inventoryList);
        }
        inventoryManager = this;
        Debug.Log("Created Inventory");
    }

    // public void Update(){
    //     list = inventory.getCollectibleList(CollectibleObject.Type.memo);   
    // }

    public void addCollectible(Collectible collectible){

        inventoryList[collectible.collectibleType].Add(collectible);

    }

    public void removeCollectible(Collectible collectible){
        inventoryList[collectible.collectibleType].Remove(collectible);
    }

    public static InventoryManager getInventory(){
        return inventoryManager;
    }

    public static int getCollectibleCount(Collectible collectible){
        return inventoryManager.inventoryList[collectible.collectibleType].Count;
    }

    public void refreshCollectibles(){
        // foreach(CollectibleObject.Type collectibleType in Enum.GetValues(typeof(CollectibleObject.Type))){
        this.clearInventoryCollectibles();
        this.insertInventoryCollectible();
    }

    public void clearInventoryCollectibles(){
        foreach(Transform collectible in inventoryContent.transform){
            Destroy(collectible.gameObject);
        }
    }

    // public void insertInventoryCollectible(){
    //     foreach(Collectible collectible in inventoryList){
    //         GameObject gameObject = Instantiate(inventoryCollectible,inventoryContent);
    //         Debug.Log(gameObject.transform.childCount);
    //         var collectibleName = gameObject.transform.Find(UICollectibleElement.COLLECTIBLE_NAME).GetComponent<Text>();
    //         var collectibleQuantity = gameObject.transform.Find(UICollectibleElement.COLLECTIBLE_QUANTITY).GetComponent<Text>();
    //         var collectibleImage = gameObject.transform.Find(UICollectibleElement.COLLECTIBLE_IMAGE).GetComponent<Image>();
    //         var collectibleDescription = gameObject.transform.Find(UICollectibleElement.COLLECTIBLE_DESCRIPTION).GetComponent<Text>();

    //         collectibleName.text = collectible.collectibleName;
    //         collectibleDescription.text = collectible.description;
    //         collectibleQuantity.text = 1.ToString();
    //         collectibleImage.sprite = collectible.collectibleIcon; 
    //     }
    // }

    public void insertInventoryCollectible(){
        foreach(CollectibleType collectibleType in Enum.GetValues(typeof(CollectibleType))){
            GameObject gameObject = Instantiate(inventoryCollectible,inventoryContent);

            gameObject.AddComponent(typeof(EventTrigger));
            EventTrigger trigger = gameObject.GetComponent<EventTrigger>();
            EventTrigger.Entry entry = new EventTrigger.Entry();
            entry.eventID = EventTriggerType.PointerClick;
            entry.callback.AddListener( (eventData) => {
                foreach(CollectibleType collectibleType in Enum.GetValues(typeof(CollectibleType))){
                    if(collectibleType.ToString() == eventData.selectedObject.transform.Find(UICollectibleElement.COLLECTIBLE_NAME).GetComponent<Text>().text){
                        currentItemList = inventoryList[collectibleType];
                    }
                    currentItem = 0;
                    refreshCollectibles();
                }
            });
            trigger.triggers.Add(entry);

            foreach(Collectible collectible in inventoryList[collectibleType]){

                var collectibleName = gameObject.transform.Find(UICollectibleElement.COLLECTIBLE_NAME).GetComponent<Text>();
                var collectibleQuantity = gameObject.transform.Find(UICollectibleElement.COLLECTIBLE_QUANTITY).GetComponent<Text>();
                var collectibleImage = gameObject.transform.Find(UICollectibleElement.COLLECTIBLE_IMAGE).GetComponent<Image>();

                collectibleName.text = collectible.collectibleName;

                if(currentItemList.Count == 0){
                    currentItemDescription.text = "Please Select an Item on the Left";
                }
                else{
                    currentItemDescription.text = "Item " + (currentItem + 1) + " of " + currentItemList.Count + "<br>" + inventoryList[collectibleType][currentItem].description;
                }
                collectibleQuantity.text = inventoryList[collectibleType].Count.ToString();
                collectibleImage.sprite = collectible.collectibleIcon; 
            }
        }
    }

    public void nextItem(){
        if(currentItem < currentItemList.Count - 1){
            currentItem = currentItem + 1;
        }
        else{
            currentItem = 0;
        }
        Debug.Log(currentItem);
        refreshCollectibles();
    }

    // public void previousItem(){
    //     currentItem = currentItem - 1;
    //     Debug.Log(currentItem);
    //     // refreshCollectibles();
    // }
    
    
}


// using System;
// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.UI;

// public class InventoryManager : MonoBehaviour
// {
//     private static InventoryManager inventoryManager;
//     public List<Collectible> inventoryList;
//     private Dictionary<CollectibleType,List<Collectible>> inventoryTest;
//     public Transform inventoryContent;
//     public GameObject inventoryCollectible;

//     public void Awake(){
//         if(inventoryManager == null){
//             inventoryManager = this;
//         }
//         inventoryManager = this;
//         Debug.Log("Created Inventory");
//     }

//     // public void Update(){
//     //     list = inventory.getCollectibleList(CollectibleObject.Type.memo);   
//     // }

//     public void addCollectible(Collectible collectible){

//         inventoryList.Add(collectible);

//     }

//     public void removeCollectible(Collectible collectible){
//         inventoryList.Remove(collectible);
//     }

//     public static InventoryManager getInventory(){
//         return inventoryManager;
//     }

//     // public static int getCollectibleCount(CollectibleObject.Type collectibleType){
//     //     return inventory.getCollectibleList(collectibleType).Count;
//     // }

//     public void refreshCollectibles(){
//         // foreach(CollectibleObject.Type collectibleType in Enum.GetValues(typeof(CollectibleObject.Type))){

//         this.clearInventoryCollectibles();
//         this.insertInventoryCollectible();
//     }

//     public void clearInventoryCollectibles(){
//         foreach(Transform collectible in inventoryContent.transform){
//             Destroy(collectible.gameObject);
//         }
//     }

//     // public void insertInventoryCollectible(){
//     //     foreach(Collectible collectible in inventoryList){
//     //         GameObject gameObject = Instantiate(inventoryCollectible,inventoryContent);
//     //         Debug.Log(gameObject.transform.childCount);
//     //         var collectibleName = gameObject.transform.Find(UICollectibleElement.COLLECTIBLE_NAME).GetComponent<Text>();
//     //         var collectibleQuantity = gameObject.transform.Find(UICollectibleElement.COLLECTIBLE_QUANTITY).GetComponent<Text>();
//     //         var collectibleImage = gameObject.transform.Find(UICollectibleElement.COLLECTIBLE_IMAGE).GetComponent<Image>();
//     //         var collectibleDescription = gameObject.transform.Find(UICollectibleElement.COLLECTIBLE_DESCRIPTION).GetComponent<Text>();

//     //         collectibleName.text = collectible.collectibleName;
//     //         collectibleDescription.text = collectible.description;
//     //         collectibleQuantity.text = 1.ToString();
//     //         collectibleImage.sprite = collectible.collectibleIcon; 
//     //     }
//     // }

//     public void insertInventoryCollectible(){
//         foreach(Collectible collectible in inventoryList){
//             GameObject gameObject = Instantiate(inventoryCollectible,inventoryContent);
//             Debug.Log(gameObject.transform.childCount);
//             var collectibleName = gameObject.transform.Find(UICollectibleElement.COLLECTIBLE_NAME).GetComponent<Text>();
//             var collectibleQuantity = gameObject.transform.Find(UICollectibleElement.COLLECTIBLE_QUANTITY).GetComponent<Text>();
//             var collectibleImage = gameObject.transform.Find(UICollectibleElement.COLLECTIBLE_IMAGE).GetComponent<Image>();
//             var collectibleDescription = gameObject.transform.Find(UICollectibleElement.COLLECTIBLE_DESCRIPTION).GetComponent<Text>();

//             collectibleName.text = collectible.collectibleName;
//             collectibleDescription.text = collectible.description;
//             collectibleQuantity.text = 1.ToString();
//             collectibleImage.sprite = collectible.collectibleIcon; 
//         }
//     }
    
    
// }
