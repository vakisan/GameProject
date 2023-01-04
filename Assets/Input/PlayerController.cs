using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    
    private PlayerInput playerInput;

    public float movementSpeed = 10;
    private Rigidbody playerRigidbody;

    private PlayerControl playerControl;

    Vector3 worldPosition;

    private void Awake(){
        playerInput = GetComponent<PlayerInput>();
        playerRigidbody = GetComponent<Rigidbody>();

        playerControl = new PlayerControl();
        playerControl.Land.Walk.Enable();
        playerControl.Land.Pause.Enable();
        playerControl.Land.Shoot.Enable();
        playerControl.Land.Walk.performed += Walk;
        playerControl.Land.Pause.performed += Pause;
        playerControl.Land.Shoot.performed += Shoot;
        Debug.Log("Created player Actions");
    }

    void Shoot(InputAction.CallbackContext context){
        Ray ray = Camera.main.ScreenPointToRay(Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue()));
        RaycastHit hit;
        Debug.Log(ray.origin);
        Debug.Log(ray.direction);
        Debug.DrawRay(ray.origin,ray.direction,Color.green,10);
    }

    private void Walk(InputAction.CallbackContext context){
        // Vector3 movement = context.ReadValue<Vector3>();
        // playerRigidbody.transform.Translate(new Vector3(movement.x,0,movement.y) * movementSpeed * Time.deltaTime);
    }

    private void Pause(InputAction.CallbackContext context){
        Debug.Log("Pause");
        SceneManager.LoadScene("Pause");
    }

    void Update(){

        // if(worldPosition == null){
        //     worldPosition = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        // }

        Vector3 movement = playerControl.Land.Walk.ReadValue<Vector3>();
        
        Vector3 mousePosition = Mouse.current.position.ReadValue();
        
        Vector3 newWorldPosition = Camera.main.ScreenToWorldPoint(mousePosition);

        Transform camTransform = Camera.main.transform;
        Vector3 camPosition = new Vector3(camTransform.position.x, transform.position.y, camTransform.position.z);
        Vector3 direction = (transform.position - camPosition);

        Vector3 resulting = direction;
        resulting.y = 0;
        if(movement.x != 0){
            playerRigidbody.transform.Translate(resulting.normalized * movementSpeed * Time.deltaTime);
        }
        else if(movement.y != 0){
            playerRigidbody.transform.Translate(resulting.normalized * movementSpeed * Time.deltaTime);
        }

        playerRigidbody.rotation = Quaternion.Euler(0,0,0);

        // Vector3 forwardMovement = direction * movement.x;
        // Vector3 horizontalMovement = camTransform.right * movement.y;
        // Vector3 movementPlayer = Vector3.ClampMagnitude(forwardMovement + horizontalMovement, 1);
        // transform.Translate(movementPlayer * movementSpeed * Time.deltaTime, Space.World);

        // Vector3 mouseMovement = Mouse.current.position.ReadValue();
        // movement.x = mouseMovement.x - initialMouse.x;
        // playerRigidbody.transform.localRotation = Quaternion.Euler(0, turn.x/10, 0);
        // Vector2 movement = playerControl.Land.Walk.ReadValue<Vector2>();
        // playerRigidbody.AddForce(new Vector3(movement.x,0,movement.y) * movementSpeed, ForceMode.Force);
    }

    public Vector3 GetInput(){
        return playerControl.Land.Walk.ReadValue<Vector3>();
    }
}
