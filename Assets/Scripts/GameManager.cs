using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
  public static GameManager instance = null;
   public Text coinstext;
   private int coins = 0;
    //Awake is always called before any Start functions
    void Awake()
  {
      //Check if instance already exists
      if (instance == null)
      {
          //if not, set instance to this
          instance = this;
      }
      //If instance already exists and it's not this:
      else if (instance != this)
      {
         Destroy(gameObject);
      }


      //Sets this to not be destroyed when reloading scene
      DontDestroyOnLoad(gameObject);

  }
  void Update()
  {
    //Checks if build index is greater than ("#") 
    if (SceneManager.GetActiveScene ().buildIndex > 7)
    {
      Destroy(GameObject.FindWithTag("GameManager"));
    }
  }

   public void updatecoins()

    {
        coinstext.text = "coins " + coins;

    }

    public void increasecoins()
    { 
        coins = coins + 1; 
    }
}
