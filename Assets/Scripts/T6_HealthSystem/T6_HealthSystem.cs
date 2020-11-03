using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class T6_HealthSystem : MonoBehaviour
{
    private void Awake()
    {
        T6_HealthEvent.deathZoneHit.AddListener(DeathZoneHit);
    }

    public void DeathZoneHit(HitEventData data)
    {
        Debug.Log(data.emojiHitter);
        Debug.Log(data.wallHit);
    }
}
