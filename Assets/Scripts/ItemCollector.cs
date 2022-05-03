using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    private int coins = 0;

    [SerializeField] private Text coinstext;

    [SerializeField] private AudioSource collectionSoundEffect;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Gold"))
        {
            collectionSoundEffect.Play();
            Destroy(collision.gameObject);
            coins = coins + 1;
            //GameManager.updatecoin(coins);
            GameObject.Find("GameManager").GetComponent<GameManager>().updatecoins(coins);
            //coinstext.text = "coins " + coins;
        }
    }
}
