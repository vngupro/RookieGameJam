using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T6_DeathWall : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "T6_Emoji")
        {
            T6_HealthEvent.deathZoneHit.Invoke(new HitEventData(other, gameObject));
        }
    }
}
