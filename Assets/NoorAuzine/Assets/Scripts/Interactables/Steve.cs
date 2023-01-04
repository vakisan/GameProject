using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Steve : Interactable
{
    protected override void Interact()
    {
        Debug.Log("Interacted with " + gameObject.name);
    }
 
}

/*
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
*/