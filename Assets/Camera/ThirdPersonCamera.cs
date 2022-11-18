using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{

    [Header("References")]
    public Transform orientation;
    public Transform player;
    public Transform playerObject;
    public Rigidbody playerRigidBody;
    public float rotationSpeed;

    public PlayerController playerController;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 viewDir = player.position - new Vector3(transform.position.x, player.position.y, transform.position.z);
        orientation.forward = viewDir.normalized;

        Vector3 input = playerController.GetInput();

        float horizontalInput = input.x; 
        float verticalInput =  input.y;

        Vector3 inputDir = orientation.forward * verticalInput  + orientation.right * horizontalInput;

        if(inputDir != Vector3.zero){
            playerObject.forward = Vector3.Slerp(playerObject.forward, inputDir.normalized, Time.deltaTime * rotationSpeed);
        } 
    }
}
