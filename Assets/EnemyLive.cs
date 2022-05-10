using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLive : MonoBehaviour
{

    public GameObject blocklocation;
    private Rigidbody2D rb;
    public GameObject block;
    public int width = 10;
    public int height = 4;



    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Die();
        }

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Die();
        }

    }

    private void Die()
    {
        rb.bodyType = RigidbodyType2D.Static;
        Instantiate(block, blocklocation.transform.position, Quaternion.identity);
        Destroy(gameObject);
        print("death");

       
    }

}
