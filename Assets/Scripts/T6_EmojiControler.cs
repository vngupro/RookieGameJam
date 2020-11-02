using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T6_EmojiControler : MonoBehaviour
{
    private Transform emojiTransform = null;
    public float speed = 5f;

    private void Start()
    {
        emojiTransform = GetComponent<Transform>();
        speed = Random.Range(2 , 3.5f) * Time.deltaTime;
    }
    private void Update()
    {
        emojiTransform.Translate(-speed, 0, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //perdre un point de vie
        Destroy(this.gameObject);
    }
}
