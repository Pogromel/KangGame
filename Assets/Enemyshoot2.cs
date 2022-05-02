using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemyshoot2 : MonoBehaviour
{


        public Transform firePoint;
        public Transform firePoint2;
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
                    Instantiate(bulletPrefab, firePoint2.position, firePoint2.rotation);

            }


            }
        }

        void Update()
        {
            if (transform.position.y < -7)
            {
                Destroy(this.gameObject);
            }
        }
    }
