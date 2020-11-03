﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public enum EmojiType { HAPPY , SAD , ANGRY }

public class T6_EmojiInteractions : MonoBehaviour
{
    public EmojiType emojiType;
    public bool isBeingShot = false;
    public ParticleSystem particles;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("T6_Emoji") && isBeingShot)
        {
            switch (emojiType)
            {
                case EmojiType.HAPPY:
                    switch (collision.gameObject.GetComponent<T6_EmojiInteractions>().emojiType)
                    {
                        case EmojiType.HAPPY:
                            break;
                        case EmojiType.SAD:
                            break;
                        case EmojiType.ANGRY:
                            Destroy(collision.gameObject);
                            Destroy(this.gameObject, .5f);
                            SpawnParticles();
                            
                            break;
                    }
                    break;

                case EmojiType.SAD:
                    switch (collision.gameObject.GetComponent<T6_EmojiInteractions>().emojiType)
                    {
                        case EmojiType.HAPPY:
                            Destroy(collision.gameObject);
                            Destroy(this.gameObject, .5f);
                            SpawnParticles();
                            break;
                        case EmojiType.SAD:
                            break;
                        case EmojiType.ANGRY:
                            break;
                    }
                    break;

                case EmojiType.ANGRY:
                    switch (collision.gameObject.GetComponent<T6_EmojiInteractions>().emojiType)
                    {
                        case EmojiType.HAPPY:
                            break;
                        case EmojiType.SAD:
                            Destroy(collision.gameObject);
                            Destroy(this.gameObject, .5f);
                            SpawnParticles();
                            break;
                        case EmojiType.ANGRY:
                            break;
                    }
                    break;
            }
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
