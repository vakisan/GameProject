using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CutScene : MonoBehaviour
{
    public CinemachineVirtualCamera cutSceneCamera;

    public CinemachineVirtualCamera zoomCamera;

    public void SwitchOnCamera(){
        zoomCamera.enabled = false;
        cutSceneCamera.Priority = 20;
    }

    public void SwitchOffCamera(){
        zoomCamera.enabled = true;
        cutSceneCamera.Priority = 1;
    }
}
