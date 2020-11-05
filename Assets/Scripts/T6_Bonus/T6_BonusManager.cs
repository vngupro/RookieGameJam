using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T6_BonusManager : MonoBehaviour
{
    private float score;
    private float comboCount;
    private float batterieLeft;
    private float timeLeft;
    private float damageCount;
    private bool QTESuccess;

    private float rng;
    private bool hasBonus;
    private void Awake()
    {
        T6_BonusEvent.scoreChange.AddListener(ScoreGacha);
        T6_BonusEvent.comboCountChange.AddListener(ComboCountGacha);
        T6_BonusEvent.batterieLeftChange.AddListener(BatterieLeftGacha);
        T6_BonusEvent.timeLeftChange.AddListener(TimeLeftGacha);
        T6_BonusEvent.damageCountChange.AddListener(DamageCountGacha);
        T6_BonusEvent.QTESuccessTrue.AddListener(QTESuccessGacha);
    }

    private void ScoreGacha(BonusEventData data)
    {
        if (!hasBonus)
        {
            GetBonus(data.value);
        }
        
        Debug.Log("SCORE RNG = " + rng);
    }

    private void ComboCountGacha(BonusEventData data)
    {
        if (!hasBonus)
        {
            GetBonus(data.value);
        }
        Debug.Log("Combo RNG = " + rng);
    }

    private void BatterieLeftGacha(BonusEventData data)
    {
        if (!hasBonus)
        {
            GetBonus(data.value);
        }
        Debug.Log("Batterie RNG = " + rng);
    }

    private void TimeLeftGacha(BonusEventData data)
    {
        if (!hasBonus)
        {
            GetBonus(data.value);
        }
        Debug.Log("Time RNG = " + rng);
    }

    private void DamageCountGacha(BonusEventData data)
    {
        if (!hasBonus)
        {
            GetBonus(data.value);
        }
        Debug.Log("Damage RNG = " + rng);
    }

    private void QTESuccessGacha()
    {
        rng = Random.Range(0, 200);

        if(rng < 10)
        {

        }else if(rng < 50)
        {

        }else if(rng < 90)
        {

        }
    }

    private void GetBonus(float value)
    {
        rng = Random.Range(0, 50);

        if (rng < value / 4)
        {
            Debug.Log("Get One Hit Kill Bonus");
        }
        else if (rng < value / 2)
        {
            Debug.Log("Get Three Hit Kill Bonus");
        }
        else if (rng < value)
        {
            Debug.Log("Get One Line Hit Bonus");
        }

        hasBonus = true;
    }
}
