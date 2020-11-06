using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class T6_GameManager : MonoBehaviour
{
    [HideInInspector]
    public bool pause = false;
    #region Awake Update

    private void Awake()
    {
        pause = false;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (!pause)
            {
                PauseGame();
                
            }
            else
            {
                UnPauseGame();
                
            }
            
        }
    }
    #endregion
    public void LoadScene(int sceneToLoad)
    {
        SceneManager.LoadScene(sceneToLoad);
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        pause = true;
    }
    
    public void UnPauseGame()
    {
        Time.timeScale = 1;
        pause = false;
    }
}
