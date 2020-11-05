using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.Events;

public static class T6_SoundEvent
{
    public static SoundEvent playSound = new SoundEvent();
}

public class SoundEvent : UnityEvent<SoundEventData> { };

public class SoundEventData
{
    public string name;

    public SoundEventData(string name)
    {
        this.name = name;
    }
}