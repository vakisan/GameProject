using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class CollectiblePickup : MonoBehaviour
{
    public Collectible collectible;

    /*
        Collectible Pickups should be added to the Inventory using the InventoryManager.
    */
    public void pickupCollectible(){
        InventoryManager.getInventory().addCollectible(collectible);
        InventoryManager.getInventory().refreshCollectibles();
        Destroy(collectible);
        Debug.Log("Picked Up Item");
    }

    // private void OnMouseDown(){
    //     pickupCollectible();
    // }

    void OnMouseDown()
    {
        pickupCollectible();
        // Destroy the gameObject after clicking on it

    }
}
