using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T6_EmojiControler : MonoBehaviour
{
    private Transform emojiTransform = null;
    public float speed = 2f;
    public ParticleSystem particles;

    private void Start()
    {
        emojiTransform = GetComponent<Transform>();
        speed = Random.Range(1.5f , 2.5f) * Time.deltaTime;
    }
    private void Update()
    {
        emojiTransform.Translate(-speed, 0, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("T6_EndLine"))
        {
            //defaite -------------------- perdre un point de vie
            this.GetComponent<SpriteRenderer>().enabled = false;
            Instantiate(particles, this.gameObject.transform);
            speed = 0;
            this.GetComponent<Collider2D>().enabled = false;
            Destroy(this.gameObject, .5f);
        }
    }
}
