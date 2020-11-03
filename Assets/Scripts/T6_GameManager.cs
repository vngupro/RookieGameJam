using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class T6_GameManager : MonoBehaviour
{
    public void LoadScene(string sceneToLoad)
    {
        SceneManager.LoadScene(sceneToLoad);
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
    }
    
    public void UnPauseGame()
    {
        Time.timeScale = 1;
    }
}
