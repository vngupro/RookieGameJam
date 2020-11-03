using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T6_PlayerMovement : MonoBehaviour
{
    int pos = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z) && pos < 2)
        {
            gameObject.transform.position = new Vector2(transform.position.x, transform.position.y + 3);
            pos++;
        }
        if (Input.GetKeyDown(KeyCode.S) && pos > -2)
        {
            gameObject.transform.position = new Vector2(transform.position.x, transform.position.y - 3);
            pos--;
        }
    }
}
