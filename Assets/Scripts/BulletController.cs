using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{

    public GameObject bulletData;

    public float bulletLifetime = 3f;
    public float bulletSpeed = 50f;

    public Vector3 target {get ; set; }
    public bool hit {get; set;}
    // Start is called before the first frame update
    void OnEnable()
    {
        Destroy(gameObject,bulletLifetime);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, bulletSpeed * Time.deltaTime);
        if(!hit && Vector3.Distance(transform.position, target) < .01f){
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision other){
        ContactPoint contactPoint = other.GetContact(0);
        Debug.Log(contactPoint.ToString());
        GameObject bulletDecal = GameObject.Instantiate(bulletData, contactPoint.point + contactPoint.normal * .0001f, Quaternion.LookRotation(contactPoint.normal));
        Destroy(gameObject);
        Destroy(bulletDecal,bulletLifetime);
    }
}
