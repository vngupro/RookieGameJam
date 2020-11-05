using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public static class T6_BonusEvent
{
    public static BonusEvent scoreChange = new BonusEvent();
    public static BonusEvent comboCountChange = new BonusEvent();
    public static BonusEvent batterieLeftChange = new BonusEvent();
    public static BonusEvent timeLeftChange = new BonusEvent();
    public static BonusEvent damageCountChange = new BonusEvent();
    public static UnityEvent QTESuccessTrue = new UnityEvent();
}

public class BonusEvent : UnityEvent<BonusEventData> { }

public class BonusEventData
{
    public float value;

    public BonusEventData(float value)
    {
        this.value = value;
    }
}