using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class T6_Victory : MonoBehaviour
{
    public float timer = 10;
    private float maxTime;
    public int milestone = 3;
    private bool gameIsOver = false;

    public T6_ProgresBar progressBar;

    public T6_EmojiSpawner emojiSpawner;

    public T6_GrabSmiley2 grabSmiley;

    public Animator animator;
    public GameObject grapin;
    public GameObject endAnim;

    private void Awake()
    {
        maxTime = timer;
    }

    private void Update()
    {
        if (!gameIsOver)
            timer -= Time.deltaTime;

        if (timer < timer - (timer - 2.5f))
        {
            emojiSpawner.enabled = false;
            T6_TimerEvent.victoryTimer.Invoke(new VictoryTimerData(timer));
        }

        if (timer < (maxTime / 5) * (milestone +1) && milestone >= 0)
        {
            T6_TimerEvent.milestoneTimer.Invoke(new MilestoneTimerData(timer, milestone));
            milestone--;
        }

        if (timer < 0)
        {
            gameIsOver = true;
            Victory();
        }
    }

    public void Victory()
    {
        endAnim.SetActive(true);
        progressBar.gameIsOver = true;
        grabSmiley.enabled = false;
        animator.SetTrigger("Victory");
        grapin.SetActive(false);
    }
}