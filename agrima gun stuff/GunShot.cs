using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunShot : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
         if(Input.GetMouseButtonDown(0) == true)
         {
            GetComponent<AudioSource>().Play();
         } 

        if(Input.GetMouseButtonUp(0) == true)
         {
            GetComponent<AudioSource>().Stop();
         }
    }
}
