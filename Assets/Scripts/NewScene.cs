using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewScene : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("tab")){
          SceneManager.LoadScene(SceneManager.GetActiveScene ().buildIndex + 1);
        }
    }
}
