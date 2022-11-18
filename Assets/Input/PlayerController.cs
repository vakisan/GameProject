using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    
    private PlayerInput playerInput;

    public float movementSpeed = 2;
    private Rigidbody playerRigidbody;

    private PlayerControl playerControl;

    private void Awake(){
        playerInput = GetComponent<PlayerInput>();
        playerRigidbody = GetComponent<Rigidbody>();

        playerControl = new PlayerControl();
        playerControl.Land.Walk.Enable();
        playerControl.Land.Walk.performed += Walk;
        Debug.Log("Created player Actions");
    }

    private void Walk(InputAction.CallbackContext context){
        Vector3 movement = context.ReadValue<Vector3>();
        playerRigidbody.transform.Translate(new Vector3(movement.x,0,movement.y) * movementSpeed * Time.deltaTime);
    }

    void Update(){
        Vector3 movement = playerControl.Land.Walk.ReadValue<Vector3>();
        playerRigidbody.transform.Translate(new Vector3(movement.x,0,movement.y) * movementSpeed * Time.deltaTime);

        // Vector3 mouseMovement = Mouse.current.position.ReadValue();
        // turn.x = mouseMovement.x - initialMouse.x;
        // playerRigidbody.transform.localRotation = Quaternion.Euler(0, turn.x/10, 0);
        // Vector2 movement = playerControl.Land.Walk.ReadValue<Vector2>();
        // playerRigidbody.AddForce(new Vector3(movement.x,0,movement.y) * movementSpeed, ForceMode.Force);
    }

    public Vector3 GetInput(){
        return playerControl.Land.Walk.ReadValue<Vector3>();
    }
}
