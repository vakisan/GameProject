using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;

public class SwitchVCam : MonoBehaviour
{
    [SerializeField]
    private PlayerInput playerInput;
    [SerializeField]
    private int priorityBoostAmount = 10;
    [SerializeField]
    private Canvas thirdPersonCanvas;
    [SerializeField]
    private Canvas aimCanvas;


    private CinemachineVirtualCamera vCam;
    private InputAction aimAction;
    
    private void Awake()
    {
        vCam = GetComponent<CinemachineVirtualCamera>();
        aimAction = playerInput.actions["Aim"];
    }

    private void OnEnable()
    {
        aimAction.performed += _ => StartAim();
        aimAction.canceled += _ => CancelAim();
    }

    private void OnDisable()
    {
        aimAction.performed -= _ => StartAim();
        aimAction.canceled -= _ => CancelAim();
    }

    private void StartAim()
    {
        vCam.Priority += priorityBoostAmount;
        aimCanvas.enabled = true;
        thirdPersonCanvas.enabled = false;
    }

    private void CancelAim()
    {
        vCam.Priority -= priorityBoostAmount;
        aimCanvas.enabled = false;
        thirdPersonCanvas.enabled = true;
    }
}
