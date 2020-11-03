﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T6_EmojiControler : MonoBehaviour
{ 
    private Transform emojiTransform = null;
    public ParticleSystem particles;
    [SerializeField] GameObject emojiSpawner;
    //public float speed = 2.0f;

    private float minSpeed;
    private float maxSpeed;
    private float globalSpeed;
    private float randomSpeed;
    EmojiType type;
    List<T6_EmojiClass> emojiList;

    private void Start()
    {
        type = GetComponent<T6_EmojiInteractions>().emojiType;
        emojiList = emojiSpawner.GetComponent<T6_EmojiSpawner>().GetWave().GetEmojiList();
        for (int i = 0; i < emojiList.Count; i++)
        {
            if (emojiList[i].type == type)
            {
                minSpeed = emojiList[i].minSpeed;
                maxSpeed = emojiList[i].maxSpeed;
            }
        }

        globalSpeed = emojiSpawner.GetComponent<T6_EmojiSpawner>().GetWave().GetGlobalSpeed();

        emojiTransform = GetComponent<Transform>();
        //speed = Random.Range(1.5f , 2.5f) * Time.deltaTime;
        randomSpeed = Random.Range(minSpeed, maxSpeed) * globalSpeed * Time.deltaTime;

        Debug.Log(randomSpeed);

    }

    private void Update()
    {
        //emojiTransform.Translate(-speed, 0, 0);
        emojiTransform.Translate(-randomSpeed, 0, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("T6_EndLine"))
        {
            this.GetComponent<SpriteRenderer>().enabled = false;
            Instantiate(particles, this.gameObject.transform);
            //speed = 0;
            randomSpeed = 0;
            this.GetComponent<Collider2D>().enabled = false;
            Destroy(this.gameObject, .5f);
        }
    }
}