using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T6_EmojiSpawner : MonoBehaviour
{
    [SerializeField] private GameObject happyEmoji;
    [SerializeField] private GameObject sadEmoji;
    [SerializeField] private GameObject angryEmoji;
    [SerializeField] private GameObject[] lines;
    [SerializeField] float scoreToAttain = 10.0f;
    [SerializeField] List<T6_WaveConfig> WaveList = new List<T6_WaveConfig>();
    private int currentWave = 0;

    private float timer = 3;
    private bool isSpawning = false;

    GameObject obj;

    private void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            isSpawning = true;
            SpawnEmoji();
        }
    }


    private void SpawnEmoji()
    {
        int emoji = Random.Range(0, 3);
        int line = Random.Range(0, 5);

        switch (emoji)
        {
            case 0:
                obj = Instantiate(happyEmoji, lines[line].transform);
                break;
            case 1:
                obj = Instantiate(sadEmoji, lines[line].transform);
                break;
            case 2:
                obj = Instantiate(angryEmoji, lines[line].transform);
                break;
        }
        timer = 3;
        isSpawning = false;
    }

    public T6_WaveConfig GetWave()
    {
        return WaveList[currentWave];
    }

}
