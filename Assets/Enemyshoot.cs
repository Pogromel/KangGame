using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable] public class Done_Boundary { public float xMin, xMax, zMin, zMax; }
public class Enemyshoot  : MonoBehaviour
{
    public float speed; public float tilt; public Done_Boundary boundary;

    public Transform firePoint;
    public GameObject bulletPrefab;
    public float fireRate;

    private float nextFire;

    public Animator animator;

    void Start()
    {

        {
            nextFire = Time.time + fireRate;
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            GetComponent<AudioSource>().Play();
        }
    }
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        GetComponent<Rigidbody2D>().velocity = movement * speed;

        GetComponent<Rigidbody2D>().position = new Vector3
        (
            Mathf.Clamp(GetComponent<Rigidbody2D>().position.x, boundary.xMin, boundary.xMax),
            0.0f,
            Mathf.Clamp(GetComponent<Rigidbody2D>().position.z, boundary.zMin, boundary.zMax)
        );

        GetComponent<Rigidbody2D>().rotation = Quaternion.Euler(0.0f, 0.0f, GetComponent<Rigidbody2D>().velocity.z * -tilt);
    }


    void Fire()
    {
        animator.SetTrigger("shoot");
    }
}
