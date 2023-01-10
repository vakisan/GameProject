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

    private List<CharacterNPC> kinematicCharacterNPCList;

    public Canvas messageCanvas;

    private void Awake(){
        virtualCamera = GetComponent<CinemachineVirtualCamera>();
        kinematicCharacterNPCList = new List<CharacterNPC>();
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
        RaycastHit hit;
        if(Physics.Raycast(cameraTransform.position,cameraTransform.forward,out hit, 20f)){
            if(hit.collider.gameObject.GetComponent<CharacterNPC>() != null){
                CharacterNPC characterNPC = hit.collider.gameObject.GetComponent<CharacterNPC>();
                CharacterAI characterAI = characterNPC.GetComponent<CharacterAI>();
                messageCanvas.enabled = true;
                uiText.text = "\"" + characterNPC.characterModel.dialogue.Trim() + "\"";
                // transform.rotation = Quaternion.LookRotation(Vector3.RotateTowards(transform.forward,Camera.main.transform.forward,1f * Time.deltaTime, 0.0f));
                // characterNPC.transform.LookAt(Camera.main.transform,Vector3.up);
                characterAI.isRoaming = false;
                characterAI.GetNavMeshAgent().enabled = false;
                LookAtPlayerSmooth(characterNPC);
                // characterNPC.rigidbody.velocity = Vector3.zero;
                // characterNPC.rigidbody.angularVelocity = Vector3.zero;
                // characterNPC.rigidbody.isKinematic = true;
                kinematicCharacterNPCList.Add(characterNPC);

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
        Cursor.lockState = CursorLockMode.None;
        virtualCamera.Priority -= cameraPriority;
        aimCanvas.enabled = false;
        characterCanvas.enabled = true;
        uiText.text = "";
        messageCanvas.enabled = false;
        foreach(CharacterNPC characterNPC in kinematicCharacterNPCList){
            CharacterAI characterAI = characterNPC.GetComponent<CharacterAI>();
            characterAI.isRoaming = true;
            characterAI.GetNavMeshAgent().enabled = true;
            characterNPC.rigidbody.isKinematic = false;

        }
    }
}
