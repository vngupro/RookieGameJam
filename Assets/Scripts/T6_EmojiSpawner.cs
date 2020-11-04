using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using UnityEngine;

public class T6_EmojiSpawner : MonoBehaviour
{
    public static T6_EmojiSpawner instance = null;

    [SerializeField] private GameObject happyEmoji;
    [SerializeField] private GameObject sadEmoji;
    [SerializeField] private GameObject angryEmoji;
    [SerializeField] private GameObject fearEmoji;
    [SerializeField] private GameObject[] lines;

    [SerializeField] List<T6_WaveConfig> WaveList = new List<T6_WaveConfig>();
    private List<T6_EmojiClass> EmojiList = new List<T6_EmojiClass>();
    private List<bool> LineList = new List<bool>();
    private float scoreForNextWave;
    private float timeBeforeNextWave;
    private float waveDuration;
    private int happyEmojiLimit;
    private int sadEmojiLimit;
    private int angryEmojiLimit;
    private int fearEmojiLimit;

    private int currentWave = 0;

    [SerializeField] float timeBetweenEmojiSpawn = 1.0f;
    private float timer = 1.0f;
    private bool isSpawning = false;

    GameObject obj;
    private int emoji = 0;
    private int line = 0;

    [SerializeField] GameObject gameOverScreen;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }else if(instance != this)
        {
            Destroy(gameObject);
        }

        GetWaveParameters();
       
    }

    private void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            isSpawning = true;
            SpawnEmoji();
        }

        waveDuration -= Time.deltaTime;
        if( (waveDuration <= 0 || (angryEmojiLimit == 0 && sadEmojiLimit == 0 && happyEmojiLimit == 0 && fearEmojiLimit == 0)) && currentWave < WaveList.Count - 1)
        {
            GetNextWave();
        }

        if(currentWave >= WaveList.Count - 1)
        {
            Debug.Log("Game Over");
            gameOverScreen.SetActive(true);
        }
       
    }


    private void SpawnEmoji()
    {
        emoji = Random.Range(0, EmojiList.Count);
        do
        {
            line = Random.Range(0, 5);
        } while (!LineList[line]);

        switch (emoji)
        {
            case 0:
                if(happyEmojiLimit > 0)
                {
                    obj = Instantiate(happyEmoji, lines[line].transform);
                    happyEmojiLimit--;
                }
                break;
            case 1:
                if (sadEmojiLimit > 0)
                {
                    obj = Instantiate(sadEmoji, lines[line].transform);
                    sadEmojiLimit--;
                }
                break;
            case 2:
                if (angryEmojiLimit > 0)
                {
                    obj = Instantiate(angryEmoji, lines[line].transform);
                    angryEmojiLimit--;
                }
                break;
            case 3:
                if (fearEmojiLimit > 0)
                {
                    obj = Instantiate(fearEmoji, lines[line].transform);
                    fearEmojiLimit--;
                }
                break;
        }
        timer = timeBetweenEmojiSpawn;
        isSpawning = false;
    }

    public T6_WaveConfig GetWave()
    {
        return WaveList[currentWave];
    }
    public void GetWaveParameters()
    {
        scoreForNextWave = WaveList[currentWave].GetScoreForNextWave();
        timeBeforeNextWave = WaveList[currentWave].GetTimeBeforeNextWave();
        waveDuration = WaveList[currentWave].GetWaveDuration();
        EmojiList = WaveList[currentWave].GetEmojiList();
        LineList = WaveList[currentWave].GetLineList();

        for (int i = 0; i < EmojiList.Count; i++)
        {
            if (EmojiList[i].type == happyEmoji.GetComponent<T6_EmojiInteractions>().emojiType)
            {
                happyEmojiLimit = EmojiList[i].limitNumber;
            }
            else if (EmojiList[i].type == sadEmoji.GetComponent<T6_EmojiInteractions>().emojiType)
            {
                sadEmojiLimit = EmojiList[i].limitNumber;
            }
            else if (EmojiList[i].type == angryEmoji.GetComponent<T6_EmojiInteractions>().emojiType)
            {
                angryEmojiLimit = EmojiList[i].limitNumber;
            }
            else if (EmojiList[i].type == fearEmoji.GetComponent<T6_EmojiInteractions>().emojiType)
            {
                fearEmojiLimit = EmojiList[i].limitNumber;
            }
        }
    }
    public void GetNextWave()
    {
        Debug.Log("Start Next Wave");
        while (timeBeforeNextWave > 0)
        {
            timeBeforeNextWave -= Time.deltaTime;
        }
        currentWave++;
        GetWaveParameters();
    }
}
