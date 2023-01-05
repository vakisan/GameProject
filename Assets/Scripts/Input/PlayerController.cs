using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    public InputManager inputManager;
    private PlayerControl playerControl;
    public CameraManager cameraManager;

    private CharacterController characterController;

    private PlayerMotor playerMotor;

    private PlayerHealth playerHealth;

    private LevelSystem levelSystem;

    private PlayerUI playerUI;

    public float movementSpeed = 50;
    private Rigidbody playerRigidbody;

    private void Awake(){
        playerRigidbody = GetComponent<Rigidbody>();
        characterController = GetComponent<CharacterController>();
        playerMotor = GetComponent<PlayerMotor>();
        playerHealth = GetComponent<PlayerHealth>();
        levelSystem = GetComponent<LevelSystem>();
        playerUI = GetComponent<PlayerUI>();

        playerControl = inputManager.getPlayerControl();

        playerControl.Land.Pause.performed += Pause;
        // playerControl.Land.Shoot.performed += Scan;
        playerControl.Land.Test.performed += Test;
        playerControl.Land.Jump.performed += ctx => playerMotor.Jump();
        playerControl.Land.Sprint.performed += ctx => playerMotor.Sprint();
        playerControl.Land.Crouch.performed += ctx => playerMotor.Crouch();
        playerControl.Land.TakeDamage.performed += ctx => playerHealth.TakeDamage(20);
        playerControl.Land.RecoverDamage.performed += ctx => playerHealth.RestoreHealth(20);
        playerControl.Land.GainExperience.performed += ctx => levelSystem.GainExperienceManual(20);
        Debug.Log("Assigned Controls to Player");

    }

    void Test(InputAction.CallbackContext context){
        cameraManager.switchCamera();
        Debug.Log("Switch Camera, First Person: " + cameraManager.isFirstPersonCameraActive());
    }

    void Scan(){
        playerUI.UpdateText(string.Empty);
        // Ray ray = Camera.main.ScreenPointToRay(Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue()));
        Ray ray = new Ray(cameraManager.firstPersonCam.transform.position, cameraManager.firstPersonCam.transform.forward);
        Debug.DrawRay(ray.origin, ray.direction * 50f);
        RaycastHit hitInfo;
        if (Physics.Raycast(ray, out hitInfo, 50f))
        {
            if(hitInfo.collider.GetComponent<Interactable>() != null)
            {   
                Interactable interactable = hitInfo.collider.GetComponent<Interactable>();
                Debug.Log(interactable);
                playerUI.UpdateText(interactable.name);
                if (inputManager.getPlayerControl().Land.Interact.triggered)
                {   
                    interactable.BaseInteract();
                }
            }
        }
    }

    private void Walk(){
        if(!cameraManager.isFirstPersonCameraActive()){
            ThirdPersonWalk();
        }
        else{
            FirstPersonWalk();
        //     playerMotor.ProcessMove(playerControl.Land.Walk.ReadValue<Vector3>());
        }
    }

    private void FirstPersonWalk(){
        characterController.enabled = true;
        playerMotor.ProcessMove(playerControl.Land.Walk.ReadValue<Vector3>());
    }

    private void ThirdPersonWalk(){
        
        characterController.enabled = false;
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
    }

    private void Pause(InputAction.CallbackContext context){
        Debug.Log("Pause");
        SceneManager.LoadScene("Pause");
    }

    void Update(){
        Walk();
        Scan();
    }

    public Vector3 GetInput(){
        return playerControl.Land.Walk.ReadValue<Vector3>();
    }
}
