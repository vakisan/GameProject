using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    public Camera fpsCam;

    public InputManager inputManager;
    public float damage;
    public float range;


    void Awake(){
        inputManager = this.transform.parent.transform.parent.GetComponent<InputManager>();
    }
}