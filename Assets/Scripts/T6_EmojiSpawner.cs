using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using UnityEngine;
using UnityEngine.Jobs;

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
    [SerializeField] float stopSpawnTime = 5.0f;
    private float timer = 1.0f;
    private bool isSpawning = false;
    private bool canSpawn = true;

    GameObject obj;
    private int emoji = 0;
    private int line = 0;

    [SerializeField] GameObject gameOverScreen;

    public T6_SmileyStrengths smileyStrengths;

    [SerializeField] GameObject batterieBonus;
    private int spawnEmojiCount = 0;
    private int[] lastLineList = new int[3];
    private int lastLine = 0;
    private int lastLine2 = 0;

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
        canSpawn = true;
        
        T6_TimerEvent.milestoneTimer.AddListener(StopSpawning);
        T6_TimerEvent.milestoneTimer.AddListener(SpawnBatterieBonus);
        spawnEmojiCount = 0;
        lastLine = 0;

    }

    private void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0 && canSpawn)
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
        int lastEmoji = emoji;
        do
        {
            emoji = Random.Range(0, EmojiList.Count);
        } while (emoji == lastEmoji);

        GetLine();


        switch (emoji)
        {
            case 0:
                obj = Instantiate(happyEmoji, lines[line].transform);
                obj.GetComponent<T6_EmojiInteractions>().strength.Add(smileyStrengths.happy[0]);
                happyEmojiLimit--;
                break;
            case 1:
                obj = Instantiate(sadEmoji, lines[line].transform);
                obj.GetComponent<T6_EmojiInteractions>().strength.Add(smileyStrengths.sad[0]);
                sadEmojiLimit--;
                break;
            case 2:
                obj = Instantiate(angryEmoji, lines[line].transform);
                obj.GetComponent<T6_EmojiInteractions>().strength.Add(smileyStrengths.angry[0]);
                angryEmojiLimit--;
                break;
            case 3:
                obj = Instantiate(fearEmoji, lines[line].transform);
                obj.GetComponent<T6_EmojiInteractions>().strength.Add(smileyStrengths.fear[0]);
                fearEmojiLimit--;
                break;
        }
        timer = timeBetweenEmojiSpawn;
        isSpawning = false;
    }

    public void GetLine()
    {
        spawnEmojiCount++;
        if (spawnEmojiCount == 1)
        {
            line = Random.Range(0, LineList.Count);
            lastLine = line;
        }
        else if (spawnEmojiCount == 2)
        {
            do
            {
                line = Random.Range(0, LineList.Count);
            } while (line == lastLine);

            lastLine2 = line;
        }
        else
        {
            do
            {
                line = Random.Range(0, LineList.Count);
            } while ((line == lastLine) || (line == lastLine2));

            if (spawnEmojiCount % 2 == 0)
            {
                lastLine2 = line;
            }
            else if (spawnEmojiCount%2 == 1)
            {
                lastLine = line;
            }
        }
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

    public void StopSpawning(MilestoneTimerData data)
    {
        StartCoroutine(SpawnDelay());
    }

    IEnumerator SpawnDelay()
    {
        canSpawn = false;
        yield return new WaitForSecondsRealtime(stopSpawnTime);
        canSpawn = true;
    }

    public void SpawnBatterieBonus(MilestoneTimerData data)
    {
        StartCoroutine(SpawnBatterieDelay());
    }

    IEnumerator SpawnBatterieDelay()
    {
        yield return new WaitForSeconds(stopSpawnTime / 2);
        for (int i = 0; i < LineList.Count; i++)
        {
            obj = Instantiate(batterieBonus, lines[i].transform);
        }
    }
}
