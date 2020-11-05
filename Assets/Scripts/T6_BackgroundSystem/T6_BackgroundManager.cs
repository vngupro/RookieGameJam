using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T6_BackgroundManager : MonoBehaviour
{
    [SerializeField] List<Transform> backgroundList = new List<Transform>();
    [SerializeField] List<Transform> milestoneList = new List<Transform>();

    private bool endGame = false;

    private float length;
    public T6_Victory timer;
    private void Awake()
    {
        T6_TimerEvent.victoryTimer.AddListener(SpawnLastSprite);
        T6_TimerEvent.milestoneTimer.AddListener(SpawnMilestone);

        length = backgroundList[0].GetComponent<SpriteRenderer>().bounds.size.x;
        for (int i = 1; i < backgroundList.Count - 1; i++)
        {
            backgroundList[i].position = new Vector3((backgroundList[0].position.x + length) * i, backgroundList[0].position.y, backgroundList[0].position.z);
        }
    }

    private void Update()
    {
        if (endGame && backgroundList[backgroundList.Count-1].position.x <= 0)
        {
            foreach (Transform background in backgroundList)
            {
                background.GetComponent<T6_ParallaxEffect>().movingSpeed = 0;
            }
        }

    }

    public void SpawnLastSprite(VictoryTimerData data)
    {
        backgroundList[backgroundList.Count-1].gameObject.SetActive(true);
        endGame = true; 
    }

    public void SpawnMilestone(MilestoneTimerData data)
    {
        milestoneList[data.milestone].gameObject.SetActive(true);
        StartCoroutine(DeactivateMilestone(data.milestone));
    }

    IEnumerator DeactivateMilestone(int i)
    {
        yield return new WaitForSecondsRealtime(8);
        milestoneList[i].gameObject.SetActive(false);
    }
}

