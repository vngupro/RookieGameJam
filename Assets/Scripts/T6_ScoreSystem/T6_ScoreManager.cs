using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using TMPro;
public class T6_ScoreManager : MonoBehaviour
{
    public static T6_ScoreManager instance = null;

    [SerializeField] TMP_Text text;
    [SerializeField] int score = 0;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }
    private void Update()
    {
        score++;
        text.text = score.ToString();
    }
}
