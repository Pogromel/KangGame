using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    

    

    [SerializeField] private AudioSource collectionSoundEffect;



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Gold"))
        {
            collectionSoundEffect.Play();
            Destroy(collision.gameObject);
            //GameManager.updatecoin(coins);
            GameObject.Find("GameManager").GetComponent<GameManager>().increasecoins();
            GameObject.Find("GameManager").GetComponent<GameManager>().updatecoins();
           
            
        }
    }
}
