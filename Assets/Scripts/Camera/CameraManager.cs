using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public GameObject firstPersonCamera;
    public GameObject thirdPersonCamera;

    public Camera firstPersonCam;

    private bool isFirstPerson;

    void Awake(){
        firstPersonCamera.SetActive(false);
        thirdPersonCamera.SetActive(true);
        isFirstPerson = false;
    }

    public void switchCamera(){
        isFirstPerson = !isFirstPerson;
        firstPersonCamera.SetActive(isFirstPerson);
        thirdPersonCamera.SetActive(!isFirstPerson);
    }

    public bool isFirstPersonCameraActive(){
        return isFirstPerson;
    }
    

    // void switchThirPerson(){
    //     firstPersonCamera.SetActive(false);
    //     thirdPersonCamera.SetActive(true);
    // }
}
