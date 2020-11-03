using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T6_DeathWall : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "emoji")
        {
            Debug.Log("Health Minus");
            T6_HealthEvent.deathZoneHit.Invoke(new HitEventData(other, gameObject));
        }
    }
}
