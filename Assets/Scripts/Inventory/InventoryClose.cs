using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryClose : MonoBehaviour
{
    public GameObject inventory;
    Button closeInventory;

    /*Stores the state of the inventory. Ie if the inventory visibility*/

    public InventoryClose(GameObject inventory){
        this.inventory = inventory;
    }


	void Start () {
		this.closeInventory = GetComponent<Button>();
		this.closeInventory.onClick.AddListener(TaskOnClick);
	}

	void TaskOnClick(){
        if(inventory.activeSelf){
            inventory.SetActive(false);
        }
	}
}
