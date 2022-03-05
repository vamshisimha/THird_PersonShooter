using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunShooting : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private float fireRate;
    [SerializeField]
    private int damage;
    private float timer=0;
    [SerializeField]
    private Transform firePoint;
    public GameObject bullet;
    public float bulletSpeed;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= fireRate)
        {
            timer = 0;
            if(Input.GetButton("Fire1"))
            {
               GameObject BulletInst = Instantiate(bullet,firePoint.transform.position, firePoint.transform.rotation) as GameObject;
                Rigidbody bulletInstRigid = BulletInst.GetComponent<Rigidbody>();
                bulletInstRigid.AddForce(BulletInst.transform.forward * bulletSpeed);

               /*Ray ray = new Ray(firePoint.position, firePoint.forward);
                RaycastHit hitinfo;
                
                //raycast
                if(Physics.Raycast(ray,out hitinfo,100.0f))
                {
                    var health = hitinfo.collider.GetComponent<enemy>();
                    if(health !=null)
                    {
                        health.TakeDamage(damage);

                    }
                }*/
            }

        }
    }
}
