using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    private float speedH = 2.0f;
    private float speedV = 2.0f;

    private float yaw = 0.0f;
    private float pitch= 0.0f;

    public InputManager inputManager;

    public GameObject player;

    // Uses old input method as i could not find a way to read using the new input system, behaves buggy.
    // Function that runs every frame to allow camera to move. mimicks free look using mouse.
    void Update(){
        yaw += speedH * Input.GetAxis("Mouse X");
        pitch -= speedV * Input.GetAxis("Mouse Y");

        yaw = Mathf.Clamp(yaw, -180f, 180f);
        //the rotation range
        pitch = Mathf.Clamp(pitch, -60f, 90f);
        //the rotation range

        player.transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);
    }
}