using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T6_BackgroundManager : MonoBehaviour
{
    [SerializeField] List<Transform> backgroundList = new List<Transform>();
    [SerializeField] List<Transform> milestoneList = new List<Transform>();

    private bool endGame = false;


    public T6_Victory timer;
    private void Awake()
    {
        T6_TimerEvent.victoryTimer.AddListener(SpawnLastSprite);
        T6_TimerEvent.milestoneTimer.AddListener(SpawnMilestone);
    }

    private void Update()
    {
        if (endGame && backgroundList[backgroundList.Count-1].transform.position.x <= 0)
        {
            foreach (Transform background in backgroundList)
            {
                background.GetComponent<T6_ParallaxEffect>().movingSpeed = 0;
            }
        }
    }

    public void SpawnLastSprite(VictoryTimerData data)
    {
        backgroundList[backgroundList.Count - 1].gameObject.SetActive(true);
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

