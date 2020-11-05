using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T6_PlayerGetBonus : MonoBehaviour
{
    bool gotBatterie = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "T6_BatterieBonus" && !gotBatterie)
        {
            T6_HealthEvent.lifeUp.Invoke(new LifeEventData(collision.gameObject.GetComponent<T6_BatterieBonus>().GetBatterieBonusValue()));
            Destroy(collision.gameObject);
            gotBatterie = true;
            StartCoroutine(Batterie());
        }
    }

    IEnumerator Batterie()
    {
        yield return new WaitForSecondsRealtime(.5f);
        gotBatterie = false;
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.tag == "T6_BatterieBonus")
    //    {
    //        T6_HealthEvent.lifeUp.Invoke(new LifeEventData(collision.gameObject.GetComponent<T6_BatterieBonus>().GetBatterieBonusValue()));
    //    }
    //}

}
