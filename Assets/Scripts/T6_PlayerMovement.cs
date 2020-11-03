using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T6_PlayerMovement : MonoBehaviour
{
    int pos = 0;
    float inputVertical = 0;
    float timer = 0.1f;
    float timeInput = 0.1f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        inputVertical = Input.GetAxisRaw("Vertical");

        //if (Input.GetKeyDown(KeyCode.Z) && pos < 2)
        //{
        //    gameObject.transform.position = new Vector2(transform.position.x, transform.position.y + 2);
        //    pos++;
        //}
        //if (Input.GetKeyDown(KeyCode.S) && pos > -2)
        //{
        //    gameObject.transform.position = new Vector2(transform.position.x, transform.position.y - 2);
        //    pos--;
        //}

        timer -= Time.deltaTime;
        if ( inputVertical == 1 && pos < 2 && timer < 0)
        {
            gameObject.transform.position = new Vector2(transform.position.x, transform.position.y + 2);
            pos++;
            timer = timeInput;
        }

        if ( inputVertical == -1 && pos > -2 && timer < 0)
        {
            gameObject.transform.position = new Vector2(transform.position.x, transform.position.y - 2);
            pos--;
            timer = timeInput;
        }
    }
}
