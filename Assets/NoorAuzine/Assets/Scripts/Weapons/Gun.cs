using UnityEngine;

public class Gun : Weapon
{
    void Start()
    {
        inputManager = this.transform.parent.transform.parent.transform.parent.GetComponent<InputManager>();
        damage = 10f;
        range = 100f;
    }

    // Update is called once per frame
    void Update()
    {
        if (inputManager.onFoot.Shoot.triggered)
        {
            Debug.Log("Pressed left click");
            Shoot();
        }
    }

    void Shoot()
    {
        RaycastHit hitInfo;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hitInfo, range))
        {
            Debug.Log(hitInfo.transform.name);

            Target target = hitInfo.transform.GetComponent<Target>();
            if (target != null)
            {
                target.TakeDamage(damage);
            }
        }  
    }
}