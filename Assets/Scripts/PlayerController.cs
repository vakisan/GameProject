using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.AI;

[RequireComponent(typeof(CharacterController),typeof(PlayerInput))]
public class PlayerController : MonoBehaviour
{
    public static int coinCollected = 0;
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

    TMPro.TMP_Text messageCenterUI;

    public GameObject memoPrefab;

    public LevelSystem levelSystem;
    private void Awake()
    {
        controller = GetComponent<CharacterController>();
        playerInput = GetComponent<PlayerInput>();
        levelSystem = GameObject.Find("LevelSystem").GetComponent<LevelSystem>();
        moveAction = playerInput.actions["Move"];
        lookAction = playerInput.actions["Look"];
        jumpAction = playerInput.actions["Jump"];
        shootAction = playerInput.actions["Shoot"];
        cameraTransform = Camera.main.transform;

        messageCenterUI = GameObject.Find("CollectibleMessage").GetComponent<TMPro.TMP_Text>();
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
        if(Physics.Raycast(cameraTransform.position,cameraTransform.forward,out hit, Mathf.Infinity)){
            if(hit.collider.gameObject.GetComponent<CharacterNPC>()){
                CharacterModel characterModel = hit.collider.gameObject.GetComponent<CharacterNPC>().characterModel;
                hit.collider.gameObject.GetComponent<Light>().enabled = false;
                if(characterModel.coin <=0){
                    messageCenterUI.text = "Character has already gifted you!";
                }
                else{
                    messageCenterUI.text = "+" + characterModel.coin.ToString();
                    CollectiblePickup pickup = hit.collider.gameObject.GetComponent<CollectiblePickup>();
                    if(characterModel.memo){
                        Debug.Log("pickedupMemo");
                        Vector3 position = pickup.transform.position;
                        position.y = 10;
                        CollectiblePickup memoPickup = Instantiate(memoPrefab, position , pickup.transform.rotation).GetComponent<CollectiblePickup>();
                        memoPickup.collectible.collectibleType = CollectibleType.Memo;
                        Debug.Log(memoPickup.collectible.collectibleType);
                        memoPickup.collectible.collectibleName = CollectibleType.Memo.ToString();
                        memoPickup.collectible.description = characterModel.memoDetail;
                        Debug.Log(memoPickup.collectible.description);
                        memoPickup.pickupCollectible();
                        levelSystem.displayIncreasedLevelMessage(true);
                    }

                    GetComponent<Timer>().timeValue = 30 + 10 * levelSystem.GetLevel();

                    pickup.collectible.value = characterModel.coin;
                    pickup.pickupCollectible();
                    levelSystem.PlayerLevelUpdate(pickup.collectible.value);
                }

                if(characterModel.memo){
                    messageCenterUI.text = "You have passed the level!";
                }
                coinCollected += characterModel.coin;
                characterModel.coin = 0;
                messageCenterUI.GetComponent<Animation>().Play("TextFadeUp");
            }
            else if(hit.collider.gameObject.GetComponent<EnemyAI>()){
                // RecoilCamera();
                GameObject bulletObject = GameObject.Instantiate(bullet, gunTransform.position, Quaternion.identity,bulletParent);
                BulletController bulletController = bulletObject.GetComponent<BulletController>();
                bulletController.target = hit.point; 
                bulletController.hit = true;
                InflictDamageToEnemy(hit);
            }
        }
        // else{
        //     GameObject bulletObject = GameObject.Instantiate(bullet, gunTransform.position, Quaternion.identity,bulletParent);
        //     BulletController bulletController = bulletObject.GetComponent<BulletController>();
        //     bulletController.target = cameraTransform.position + cameraTransform.forward * bulletMissDistance;
        //     bulletController.hit = false;
        // }
    }

    IEnumerator RecoilCamera(){
        Camera.main.transform.Rotate(Vector3.up * 100,Space.Self);
        yield return new WaitForSeconds(0.5f);
        Camera.main.transform.Rotate(Vector3.down * 100,Space.Self);
    }

    void InflictDamageToEnemy(RaycastHit hit){
        EnemyAI enemyAI = hit.collider.gameObject.GetComponent<EnemyAI>();
        if(enemyAI != null){
            GameObject gameObject = hit.collider.gameObject;
            enemyAI.DisplayShotsToTakeDown();
            if(enemyAI.DamageEnemy()){
        
                Animation animation = gameObject.GetComponent<Animation>();
                animation.enabled = true;
                animation.Play();
                enemyAI.GetComponent<NavMeshAgent>().enabled = false;
                enemyAI.enabled = false;
                Destroy(hit.collider.gameObject,3f);
            }
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