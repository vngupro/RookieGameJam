using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Events;

public static class T6_HealthEvent
{
    public static HitEvent deathZoneHit = new HitEvent();
    public static LifeEvent lifeUp = new LifeEvent();
}

public class HitEvent : UnityEvent<HitEventData> { }
public class LifeEvent : UnityEvent<LifeEventData> { }

public class HitEventData
{
    public Collider2D emojiHitter;
    public GameObject wallHit;

    public HitEventData(Collider2D emojiHitter, GameObject wallHit)
    {
        this.emojiHitter = emojiHitter;
        this.wallHit = wallHit;
    }
}

public class LifeEventData
{
    public float lifeValue;
    
    public LifeEventData(float lifeValue)
    {
        this.lifeValue = lifeValue;
    }
}