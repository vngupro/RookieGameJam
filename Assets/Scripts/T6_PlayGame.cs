using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T6_PlayGame : MonoBehaviour
{
    public GameObject game;
    public GameObject tuto;
    public void PlayGame()
    {
        Debug.Log("yes");
        tuto.SetActive(false);
        game.SetActive(true);
    }
}
