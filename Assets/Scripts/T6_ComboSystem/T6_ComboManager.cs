using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class T6_ComboManager : MonoBehaviour
{
    [SerializeField] TMP_Text comboText;
    [SerializeField] TMP_Text comboCountText;
    private int comboCount = 0;
    [SerializeField] string comboText1 = "Not Bad";
    [SerializeField] string comboText2 = "Good";
    [SerializeField] string comboText3 = "Great";
    [SerializeField] string comboText4 = "Awesome";
    [SerializeField] string comboText5 = "God";
    [SerializeField] int combo1 = 10;
    [SerializeField] int combo2 = 20;
    [SerializeField] int combo3 = 30;
    [SerializeField] int combo4 = 40;
    [SerializeField] int combo5 = 50;
    [SerializeField] float comboTextTime = 1.5f;
    [SerializeField] int rngFactor = 5;

    private void Awake()
    {
        T6_HealthEvent.deathZoneHit.AddListener(ResetCombo);
        T6_ScoreEvent.hitWeakEmoji.AddListener(ComboPlus);

        comboText.text = "";
        comboCount = 0;
        comboCountText.text = "";
    }

    public void ResetCombo(HitEventData data)
    {
        comboCount = 0;
        comboCountText.text = "";
    }
    public void ComboPlus(HitScoreEventData data)
    {
        comboCount++;
        comboCountText.text = comboCount.ToString();

        if(comboCount == combo1)
        {
            comboText.text = comboText1;
        }else if(comboCount == combo2)
        {
            comboText.text = comboText2;
        }
        else if(comboCount == combo3)
        {
            comboText.text = comboText3;
        }
        else if(comboCount == combo4)
        {
            comboText.text = comboText4;
        }
        else if(comboCount == combo5)
        {
            comboText.text = comboText5;
        }

        StartCoroutine(ComboTextDisplay());

        //Bonus Gacha
        if( (comboCount + 1) % rngFactor == 0)
        {
            T6_BonusEvent.comboCountChange.Invoke(new BonusEventData(comboCount));
        }
    }

    IEnumerator ComboTextDisplay()
    {

        yield return new WaitForSeconds(comboTextTime);
        comboText.text = "";
    }
}
