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

    public GameObject VictoryScreen;
    public float timeBeforeDisplayVictory = 5.0f;

    T6_GameManager pauseScript;
    [SerializeField] int rngFactor = 5;
    [Header("Debug")]
    [SerializeField] private bool victory = false;

    public AudioSource music;

    private void Awake()
    {
        maxTime = timer;
        pauseScript = GetComponent<T6_GameManager>();
        victory = false;
    }

    private void Update()
    {
        /*if (victory)
        {
            Debug.Log("invoke 1");
            Victory();
            T6_TimerEvent.victoryTimer.Invoke(new VictoryTimerData(timer));

        }*/
        if (!gameIsOver)
            timer -= Time.deltaTime;

        if (timer < timer - (timer - 2.5f) && !gameIsOver)
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

        //Bonus Gacha
        if(maxTime % timer == rngFactor)
        {
            T6_BonusEvent.timeLeftChange.Invoke(new BonusEventData(timer));
            rngFactor -= 25;
        }
    }

    public void Victory()
    {
        endAnim.SetActive(true);
        progressBar.gameIsOver = true;
        grabSmiley.enabled = false;
        animator.SetTrigger("Victory");
        grapin.SetActive(false);
        music.Stop();
        StartCoroutine(DisplayVictoryScreen());
    }

    IEnumerator DisplayVictoryScreen()
    {
        yield return new WaitForSeconds(timeBeforeDisplayVictory);
       
        VictoryScreen.SetActive(true);
        pauseScript.PauseGame();


    }
}