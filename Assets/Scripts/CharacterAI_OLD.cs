// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class CharacterAI_OLD : MonoBehaviour
// {
//     [SerializeField]
//     private float movementSpeed = 20f;
//     [SerializeField]
//     private float rotationSpeed = 100f;
//     [SerializeField]
//     private bool isWandering = false;
//     [SerializeField]
//     private bool isRotatingLeft = false;
//     [SerializeField]
//     private bool isRotatingRight = false;

//     [SerializeField]
//     private bool isWalking = false;

//     [SerializeField]
//     private bool isGrounded = false;

//     new Rigidbody rigidbody;

//     [SerializeField]
//     private LevelSystem levelSystem;

//     private CharacterNPC characterNPC;

    
//    // Start is called before the first frame update
//     void Awake()
//     {
//         levelSystem = GameObject.Find("LevelSystem").GetComponent<LevelSystem>();
//         movementSpeed = levelSystem.GetDifficulty() + movementSpeed;
//         rotationSpeed = levelSystem.GetDifficulty() + rotationSpeed;
//         this.rigidbody = GetComponent<Rigidbody>();
//         this.characterNPC = GetComponent<CharacterNPC>();
        
//     }

//     IEnumerator Wander(){
//         int rotationTime = Random.Range(1,3);
//         int roatateWait = Random.Range(1,3);
//         int rotateDirection = Random.Range(1,2);
//         int walkWait = Random.Range(1,3);
//         int walkTime = Random.Range(1,3);

//         isWandering = true;

//         yield return new WaitForSeconds(walkWait);

//         isWalking = true;

//         yield return new WaitForSeconds(walkTime);

//         isWalking = false;

//         yield return new WaitForSeconds(roatateWait);

//         if(rotateDirection == 1){
//             isRotatingLeft = true;
//             yield return new WaitForSeconds(rotationTime);
//             isRotatingRight = false;
//         }

//         if(rotateDirection == 2){
//             isRotatingRight = true;
//             yield return new WaitForSeconds(rotationTime);
//             isRotatingLeft = false;
//         }

//         isWandering = false;

//     }

//     void OnCollisionEnter(Collision collision){
//         isGrounded = true;
//     }

//     void Update()
//     {
//         if(isGrounded && !characterNPC.isAimed){
//             if(!isWandering){
//                 StartCoroutine(Wander());
//             }

//             if(isRotatingRight){
//                 transform.Rotate(transform.up * Time.deltaTime * rotationSpeed);
//             }

//             if(isRotatingLeft){
//                 transform.Rotate(transform.up * Time.deltaTime * rotationSpeed);
//             }

//             if(isWalking){
//                 rigidbody.AddForce(transform.forward * movementSpeed);
//             }
//         }
//     }
// }
