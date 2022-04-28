using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemyshoot : MonoBehaviour
{
    

    public Transform firePoint;
    public GameObject bulletPrefab;
    public float fireRate;

    private float nextFire;

    

    void FixedUpdate()
    {

        {

            if (Time.time > nextFire)
            {
                nextFire = Time.time + fireRate;
                Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
                GetComponent<AudioSource>().Play();
            }
            
            
        }
    }
    


    
}
