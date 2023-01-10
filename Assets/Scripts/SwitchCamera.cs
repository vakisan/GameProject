using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;
using TMPro;

public class SwitchCamera : MonoBehaviour
{
    [SerializeField]
    private PlayerInput playerInput;
    private CinemachineVirtualCamera virtualCamera;
    private InputAction aimAction;
    [SerializeField]
    public Canvas aimCanvas;
    [SerializeField]
    public Canvas characterCanvas;

    private Transform cameraTransform;

    public TMP_Text uiText;
    
    [SerializeField]
    private int cameraPriority = 10;

    private float NPC_LOOK_AT_ROTATION_SPEED = 5f;

    [SerializeField]
    private Dictionary<int,CharacterNPC> kinematicCharacterNPCList;

    RaycastHit raycastHit;

    public Canvas messageCanvas;
    private CharacterNPC characterNPC;
    private CharacterAI characterAI;

    private void Awake(){
        virtualCamera = GetComponent<CinemachineVirtualCamera>();
        kinematicCharacterNPCList = new Dictionary<int, CharacterNPC>();
        aimAction = playerInput.actions["Aim"];
        aimCanvas.enabled = false;
        characterCanvas.enabled = true;
        cameraTransform = Camera.main.transform;
        uiText.text = "";
        messageCanvas.enabled = false;
    }

    void OnEnable(){
        aimAction.performed += _ => StartAim();
        aimAction.canceled += _ => CancelAim();
    }

    void OnDisable(){
        aimAction.performed -= _ => StartAim();
        aimAction.canceled -= _ => CancelAim(); 
    }

    private void StartAim(){
        Cursor.lockState = CursorLockMode.Locked;
        virtualCamera.Priority += cameraPriority;
        aimCanvas.enabled = true;
        characterCanvas.enabled = false;
    }

    void Update(){
        if(aimAction.inProgress){
            CheckObject();
        }
    }

    private void CheckObject(){
        if(Physics.Raycast(cameraTransform.position,cameraTransform.forward,out raycastHit, 20f)){
            if(raycastHit.collider.gameObject.GetComponent<CharacterNPC>() != null){
                this.characterNPC = raycastHit.collider.gameObject.GetComponent<CharacterNPC>();
                this.characterAI = characterNPC.GetComponent<CharacterAI>();
                // if(!kinematicCharacterNPCList.ContainsKey(characterNPC.GetInstanceID())){
                //     Debug.Log("Added");
                //     kinematicCharacterNPCList[characterNPC.GetInstanceID()] = characterNPC;
                // }
                messageCanvas.enabled = true;
                uiText.text = "\"" + characterNPC.characterModel.dialogue.Trim() + "\"";
                // characterAI.GetNavMeshAgent().speed = 0;
                LookAtPlayerSmooth(characterNPC);
            }
            else{
                uiText.text = "";
                messageCanvas.enabled = false;
            }
        }
        else{
            uiText.text = "";
            messageCanvas.enabled = false;
        }
    }

    private void LookAtPlayerSmooth(CharacterNPC characterNPC){
        characterNPC.transform.rotation = Quaternion.Slerp(characterNPC.transform.rotation, Quaternion.LookRotation(Camera.main.transform.position - characterNPC.transform.position), NPC_LOOK_AT_ROTATION_SPEED * Time.deltaTime);
    }

    private void CancelAim(){
        Debug.Log("Aim Cancelled");
        Cursor.lockState = CursorLockMode.None;
        virtualCamera.Priority -= cameraPriority;
        aimCanvas.enabled = false;
        characterCanvas.enabled = true;
        uiText.text = "";
        messageCanvas.enabled = false;
        // foreach(CharacterNPC characterNPC in kinematicCharacterNPCList.Values){
            // characterAI = characterNPC.GetComponent<CharacterAI>();
        // characterAI.GetNavMeshAgent().speed = characterAI.speed;
        // }
    }
}
