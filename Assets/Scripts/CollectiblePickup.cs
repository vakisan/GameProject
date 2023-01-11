using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class CollectiblePickup : MonoBehaviour
{
    public Collectible collectible;

    void Awake(){
        InventoryManager.getInventory().refreshCollectibles();
    }
    /*
        Collectible Pickups should be added to the Inventory using the InventoryManager.
    */
    
    public void pickupCollectible(){
        InventoryManager.getInventory().addCollectible(collectible);
        InventoryManager.getInventory().refreshCollectibles();
        // Destroy(collectible);
        Debug.Log("Picked Up Item");
    }
}
