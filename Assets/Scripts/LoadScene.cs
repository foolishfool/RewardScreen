using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public int SceneID;

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
               SceneManager.UnloadSceneAsync(scene.buildIndex);
               SceneManager.LoadScene(SceneID);
            }
        }
        
    }
}
