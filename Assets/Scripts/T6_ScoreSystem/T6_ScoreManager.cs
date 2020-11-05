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
    [SerializeField] int rngFactor = 5;
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

        T6_ScoreEvent.hitWeakEmoji.AddListener(HitWeakEmoji);
    }


    public void HitWeakEmoji(HitScoreEventData data)
    {
        score++;
        text.text = score.ToString();

        //Bonus Gacha
        if ( (score + 1) % rngFactor == 0)
        {
            T6_BonusEvent.scoreChange.Invoke(new BonusEventData(score));
        }
    }
}
