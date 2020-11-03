using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public static class T6_HealthEvent
{
    public static HitEvent deathZoneHit = new HitEvent();
}

public class HitEvent : UnityEvent<HitEventData> { }

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