using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryToggle : MonoBehaviour
{
    Button inventoryToggle;
    // Start is called before the first frame update

    public GameObject inventory; 

    public InventoryToggle(GameObject inventory){
        this.inventory = inventory;
    }


	void Start () {
		this.inventoryToggle = GetComponent<Button>();
        this.inventory.SetActive(false);
		this.inventoryToggle.onClick.AddListener(TaskOnClick);
	}

	void TaskOnClick(){
        Debug.Log("Clicked");
        if(!inventory.activeSelf){
            inventory.SetActive(true);
        }
        else{
            inventory.SetActive(false);
        }
	}
}