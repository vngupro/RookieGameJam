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
    public float randomSpeed;
    //[SerializeField] float factorSpeed = 0.1f;

    EmojiType type;
    List<T6_EmojiClass> emojiList;

    private void Awake()
    {
        T6_TimerEvent.milestoneTimer.AddListener(DestroyAllSpawnEmoji);
        T6_TimerEvent.victoryTimer.AddListener(DestroyAllSpawnEmojiVictory);
    }
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

        randomSpeed = Random.Range(minSpeed, maxSpeed) * globalSpeed * Time.deltaTime;


    }

    private void Update()
    {
        emojiTransform.Translate(-randomSpeed, 0, 0);
    }

    public void DestroyEmoji()
    {
        this.GetComponent<SpriteRenderer>().enabled = false;
        Instantiate(particles, this.gameObject.transform);
        randomSpeed = 0;
        this.GetComponent<Collider2D>().enabled = false;
        Destroy(this.gameObject, .5f);
    }

    public void DestroyAllSpawnEmoji(MilestoneTimerData data)
    {
        if(gameObject != null)
        {
            StartCoroutine(WaitBeforeDestroyAll());
        }
    }
    
    public void DestroyAllSpawnEmojiVictory(VictoryTimerData data)
    {
        if(gameObject != null)
        {
            StartCoroutine(WaitBeforeDestroyAll());
        }
    }

    IEnumerator WaitBeforeDestroyAll()
    {
        T6_EmojiEvent.hitEmojiEvent.Invoke();
        yield return new WaitForSeconds(2.0f);
        DestroyEmoji();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("T6_EndLine"))
        {
            DestroyEmoji();
        }

        if (collision.CompareTag("T6_LimitLine"))
        {
            DestroyEmoji();
        }
    }
}
