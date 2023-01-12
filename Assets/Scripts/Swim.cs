using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swim : MonoBehaviour
{
    private GameObject player;
    private MeshRenderer waterBlockerMesh;
    private GameObject waterBlocker;
    private Animation swimAnimation;

    private TMPro.TMP_Text swimButtonText;

    public bool canSwim = false;
    // Start is called before the first frame update
    void Awake()
    {   
        canSwim = false;
        player = GameObject.Find("Player");
        swimButtonText = GameObject.Find("SwimButton").GetComponent<TMPro.TMP_Text>();
        waterBlocker = GameObject.Find("LakeBlocker");
        waterBlockerMesh = waterBlocker.GetComponent<MeshRenderer>();
        swimAnimation = player.GetComponent<Animation>();
        // waterBlockerMesh.enabled = false;
    }

    void Start(){
        waterBlockerMesh.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {   
        if(!canSwim){
            // CanSwim();
            NoSwim();
        }
        else{
            CanSwim();
        }
    }

    void CanSwim(){
        //test
        waterBlocker.SetActive(false);
        swimAnimation.Play("PlayerSwim");
        swimButtonText.text = "Can Swim";
    }

    void NoSwim(){
        player.transform.localScale = Vector3.one;
        swimButtonText.text = "Cannot Swim";
    }

    public void ToggleSwim(){
        if(canSwim){
            canSwim = false;
        }
        else{
            canSwim = true;
        }
    }
}
