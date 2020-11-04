using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class T6_Victory : MonoBehaviour
{
    public float timer = 10;
    private bool gameIsOver = false;

    public T6_ProgresBar progressBar;

    public T6_EmojiSpawner emojiSpawner;

    public T6_GrabSmiley2 grabSmiley;

    public Animator animator;
    public GameObject grapin;
    public GameObject endAnim;

    private void Update()
    {
        if (!gameIsOver)
            timer -= Time.deltaTime;

        if(timer < timer - (timer - 2))
        {
            emojiSpawner.enabled = false;
        }
        if( timer < 0)
        {
            gameIsOver = true;
            Victory();
        }
    }

    private void Victory()
    {
        endAnim.SetActive(true);
        progressBar.gameIsOver = true;
        grabSmiley.enabled = false;
        animator.SetTrigger("Victory");
        grapin.SetActive(false);

    }
}
