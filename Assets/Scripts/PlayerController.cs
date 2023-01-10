using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController),typeof(PlayerInput))]
public class PlayerController : MonoBehaviour
{
    private CharacterController controller;
    private PlayerInput playerInput;
    private Vector3 playerVelocity;
    private bool groundedPlayer;

     [SerializeField]
    private float playerSpeed = 2.0f;
     [SerializeField]
    private float jumpHeight = 1.0f;
     [SerializeField]
    private float gravityValue = -9.81f;
    public float playerRotationSpeed = 2f;

    private InputAction moveAction;
    private InputAction lookAction;
    private InputAction jumpAction;
    private InputAction shootAction;

    private Transform cameraTransform;

    public float bulletMissDistance;

    
    public GameObject bullet;
    public Transform gunTransform;

    public Transform bulletParent;


    private void Awake()
    {
        controller = GetComponent<CharacterController>();
        playerInput = GetComponent<PlayerInput>();
        moveAction = playerInput.actions["Move"];
        lookAction = playerInput.actions["Look"];
        jumpAction = playerInput.actions["Jump"];
        shootAction = playerInput.actions["Shoot"];
        cameraTransform = Camera.main.transform;
    }

    
    void OnEnable(){
        shootAction.performed += _ => Shoot();
    }

    void OnDisable(){
        shootAction.performed -= _ => Shoot();
    }

    void Update()
    {
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        Vector2 input = moveAction.ReadValue<Vector2>(); 
        Vector3 move = new Vector3(input.x,0,input.y);
        move = getPlayerDirectionRelativetoCamera(move);
        controller.Move(move * Time.deltaTime * playerSpeed);

        // Changes the height position of the player..
        if (jumpAction.triggered && groundedPlayer)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);

        rotatePlayerToCameraDirection();
    }

    private void Shoot(){
        RaycastHit hit;
        GameObject bulletObject = GameObject.Instantiate(bullet, gunTransform.position, Quaternion.identity,bulletParent);
        BulletController bulletController = bulletObject.GetComponent<BulletController>();
        if(Physics.Raycast(cameraTransform.position,cameraTransform.forward,out hit, Mathf.Infinity)){
            bulletController.target = hit.point; 
            bulletController.hit = true;
        }
        else{
            bulletController.target = cameraTransform.position + cameraTransform.forward * bulletMissDistance;
            bulletController.hit = false;
        }
    }

    Vector3 getPlayerDirectionRelativetoCamera(Vector3 playerMovement){
        Vector3 output = playerMovement.x * cameraTransform.right.normalized + playerMovement.z * cameraTransform.forward.normalized;
        output.y = 0f;
        return output;
    }

    void rotatePlayerToCameraDirection(){
        Quaternion cameraRotation = Quaternion.Euler(0,cameraTransform.eulerAngles.y,0); 
        transform.rotation = Quaternion.Lerp(transform.rotation, cameraRotation,  playerRotationSpeed * Time.deltaTime);

    }
}