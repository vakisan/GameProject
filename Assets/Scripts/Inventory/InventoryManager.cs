using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    private static InventoryManager inventoryManager;
    public List<Collectible> inventoryList;
    private Dictionary<CollectibleType,List<Collectible>> inventoryTest;
    public Transform inventoryContent;
    public GameObject inventoryCollectible;

    public void Awake(){
        if(inventoryManager == null){
            inventoryManager = this;
        }
        inventoryManager = this;
        Debug.Log("Created Inventory");
    }

    // public void Update(){
    //     list = inventory.getCollectibleList(CollectibleObject.Type.memo);   
    // }

    public void addCollectible(Collectible collectible){

        inventoryList.Add(collectible);

    }

    public void removeCollectible(Collectible collectible){
        inventoryList.Remove(collectible);
    }

    public static InventoryManager getInventory(){
        return inventoryManager;
    }

    // public static int getCollectibleCount(CollectibleObject.Type collectibleType){
    //     return inventory.getCollectibleList(collectibleType).Count;
    // }

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

    public void insertInventoryCollectible(){
        foreach(Collectible collectible in inventoryList){
            GameObject gameObject = Instantiate(inventoryCollectible,inventoryContent);
            Debug.Log(gameObject.transform.childCount);
            var collectibleName = gameObject.transform.Find(UICollectibleElement.COLLECTIBLE_NAME).GetComponent<Text>();
            var collectibleQuantity = gameObject.transform.Find(UICollectibleElement.COLLECTIBLE_QUANTITY).GetComponent<Text>();
            var collectibleImage = gameObject.transform.Find(UICollectibleElement.COLLECTIBLE_IMAGE).GetComponent<Image>();
            
            collectibleName.text = collectible.collectibleName;
            collectibleQuantity.text = 1.ToString();
            collectibleImage.sprite = collectible.collectibleIcon; 
        }
    }
    
    
}
