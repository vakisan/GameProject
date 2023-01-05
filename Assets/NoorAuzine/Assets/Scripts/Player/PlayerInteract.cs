// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class PlayerInteract : MonoBehaviour
// {
//     private Camera camera;
//     [SerializeField]
//     private float rayDistance = 3f;
//     [SerializeField]
//     private LayerMask mask;
//     private PlayerUI playerUI;
//     private InputManager inputManager;
//     // Start is called before the first frame update
//     void Start()
//     {
//         camera = GetComponent<PlayerLook>().camera;
//         playerUI = GetComponent<PlayerUI>();
//         inputManager = GetComponent<InputManager>(); 
//     }

//     // Update is called once per frame
//     void Update()
//     {
//         playerUI.UpdateText(string.Empty);
//         Ray ray = new Ray(camera.transform.position, camera.transform.forward);
//         Debug.DrawRay(ray.origin, ray.direction * rayDistance);
//         RaycastHit hitInfo;
//         if (Physics.Raycast(ray, out hitInfo, rayDistance, mask))
//         {
//             if(hitInfo.collider.GetComponent<Interactable>() != null)
//             {
//                 Interactable interactable = hitInfo.collider.GetComponent<Interactable>();
//                 playerUI.UpdateText(interactable.promptMessage);
//                 if (inputManager.onFoot.Interact.triggered)
//                 {
//                     interactable.BaseInteract();
//                 }
//             }
//         }
//     }
// }