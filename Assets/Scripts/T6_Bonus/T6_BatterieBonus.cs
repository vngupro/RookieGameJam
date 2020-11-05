using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class T6_BatterieBonus : MonoBehaviour
{
    private float value;
    private int rng;
    [SerializeField] float value1 = 10.0f;
    [SerializeField] float value2 = 30.0f;
    [SerializeField] float value3 = 50.0f;
    [SerializeField] float value4 = 100.0f;

    [SerializeField] float batterieSpeed = 0.1f; 
    // Start is called before the first frame update
    void Start()
    {
        rng = Random.Range(0, 100);
        
        if(rng <= 25)
        {
            value = value1;
        }else if(rng > 25 && rng <= 50)
        {
            value = value2;
        }else if(rng > 50 && rng <= 75)
        {
            value = value3;
        }else if(rng > 90)
        {
            value = value3;
        }
    }

    private void Update()
    {
        transform.Translate(-batterieSpeed, 0, 0);
    }

    public float GetBatterieBonusValue()
    {
        return value;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "T6_EndLine")
        {
            Destroy(gameObject);
        }
    }
}
