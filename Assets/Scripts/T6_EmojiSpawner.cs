using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T6_EmojiSpawner : MonoBehaviour
{
    [SerializeField] private GameObject happyEmoji;
    [SerializeField] private GameObject sadEmoji;
    [SerializeField] private GameObject angryEmoji;
    [SerializeField] private GameObject[] lines;

    private float timer = 3;
    private bool isSpawning = false;

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
                GameObject obj = Instantiate(happyEmoji, lines[line].transform);
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
}
