using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneBoss : MonoBehaviour
{

    public void LoadSceneByName(string sceneName)
    {
        SceneManager.LoadScene(sceneName); 
    }

    public void LoadNextScene()
    {
    }
    public void LoadLoseScene()
    {
    }
    public void LoadWinScene()
    {
    }
   
	
}
