using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public enum EmojiType { HAPPY , SAD , ANGRY , FEAR }

public class T6_EmojiInteractions : MonoBehaviour
{
    public EmojiType emojiType;
    public bool isBeingShot = false;
    public ParticleSystem particles;
    public float point = 1.0f;
    public List<EmojiType> strength;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("T6_Emoji") && isBeingShot)
        {

            if (collision.gameObject.GetComponent<T6_EmojiInteractions>().emojiType == strength[0] /*|| collision.gameObject.GetComponent<T6_EmojiInteractions>().emojiType == strength[1]*/)
            { 
                Destroy(collision.gameObject);
                Destroy(this.gameObject, .5f);
                SpawnParticles();
                T6_ScoreEvent.hitWeakEmoji.Invoke(new HitScoreEventData(collision.gameObject, gameObject, point));
            }
            else
            {
                this.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
                collision.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            }
            isBeingShot = false;
        }
    }

    private void SpawnParticles()
    {
        this.GetComponent<SpriteRenderer>().enabled = false;
        Instantiate(particles, this.gameObject.transform);
        //this.GetComponent<T6_EmojiControler>().speed = 0;
        this.GetComponent<Collider2D>().enabled = false;
    }

}
