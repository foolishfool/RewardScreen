using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public int SceneID;
    public GameObject shakingItem;

    

    public void LoadLevel()
    {
        SceneManager.LoadScene(SceneID);
    }

    void Update()
    {
       
        //only in the start scene

        Scene scene = SceneManager.GetActiveScene();
      
        if (scene.buildIndex == 0)
        {
            if (Input.anyKey)
            {
               GetComponent<AudioSource>().Play();
               shakingItem.GetComponent<TweenScale>().enabled = true;
               shakingItem.GetComponent<TweenScale>().PlayForward();
               Invoke("EnterNextScene",0.8f);
        
            }
        }
        
    }

    private void EnterNextScene()
    {
        SceneManager.LoadScene(SceneID);
    }
}
