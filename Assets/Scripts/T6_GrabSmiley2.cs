﻿using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class T6_GrabSmiley2 : MonoBehaviour
{
    [Header("DEBUG Bool")]
    [SerializeField]bool canLaunch = true; // peut lancer le grab
    [SerializeField]bool canThrow = false; //peut lancer le smiley
    [SerializeField]bool hasEmoji = false; //si le grapin a un emoji
    [SerializeField] bool hasLauchHook = false; //si hasLaunch peut attraper un emoji
    [SerializeField] bool isComingBackHook = false;

    [Header("Debug Speed")]
    [SerializeField]float hookSpeed = 10.0f;

    [Header("Hook Parameters")]
    [SerializeField]float defaultForwardGrabSpeed = 10.0f;
    [SerializeField]float emojiThrowSpeed = 10.0f;
    [SerializeField]float timeDelay = 0.2f; //Délai pour éviter bug de reprend le smiley
    [SerializeField]string smileyTagName;

    [SerializeField]Transform maxGrabDistance;
    GameObject smileyObject;
    Rigidbody2D rb;
    Collider2D hookCollider;
    Vector3 startPosition;

    #region Awake and Start
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        hookCollider = GetComponent<Collider2D>();
        canLaunch = true;
        hasLauchHook = false;
        canThrow = false;
        hasEmoji = false;
    }
    void Start()
    {   
        startPosition = transform.position;
    }
    #endregion
    void Update()
    {
        HookBehaviour();

        //si on a un emoji
        if (hasEmoji == true)
        {
            EmojiComeBackWithHook();
            EmojiThrow();
        }
    }
    public void HookBehaviour()
    {
        LaunchHook();
        ComeBackHook();
        StopHook();
    }

    public void LaunchHook()
    {
        if (Input.GetAxis("Fire1") == 1 && canLaunch && canThrow == false && hasEmoji == false)
        {
            rb.velocity = new Vector2(hookSpeed, 0);
            canLaunch = false;
            hasLauchHook = true;
        }
    }

    public void ComeBackHook()
    {
        //No Emoji
        if (transform.position.x >= maxGrabDistance.position.x)
        {
            rb.velocity = new Vector2(-hookSpeed, 0);
            isComingBackHook = true;
            hasLauchHook = false;
        }

        //Got Emoji
        if (hasEmoji)
        {
            rb.velocity = new Vector2(-hookSpeed, 0);
            isComingBackHook = true;
            hasLauchHook = false;
        }
    }

    public void StopHook()
    {
        //No Emoji
        if (transform.position.x < startPosition.x && isComingBackHook && !hasEmoji)
        {
            rb.velocity = new Vector2(0, 0);
            isComingBackHook = false;
            canLaunch = true;

        }

        //Got Emoji
        if (transform.position.x < startPosition.x && isComingBackHook && hasEmoji)
        {
            rb.velocity = new Vector2(0, 0);
            isComingBackHook = false;
            canThrow = true;

        }
    }

    public void EmojiComeBackWithHook()
    {
        //ramène le smiley au joueur
        if (transform.position.x > startPosition.x)
        {
            smileyObject.transform.position = gameObject.transform.position;
        }
        //s'arrête avec le smiley quand il est arrivé, replacement du grab
        else
        {
            smileyObject.transform.position = transform.position;
        }
    }

    public void EmojiThrow()
    {
        if (Input.GetAxis("Fire1") == 1 && canThrow)
        {
            smileyObject.GetComponent<Rigidbody2D>().velocity = new Vector3(emojiThrowSpeed, 0); // on envoie le smiley droit devant
            smileyObject.GetComponent<T6_EmojiInteractions>().isBeingShot = true;
            StartCoroutine(delay(timeDelay));
        }
    }
    IEnumerator delay(float t)
    {
        yield return new WaitForSeconds(t);
        //canLaunch = true;
        hasEmoji = false;
        canThrow = false;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == smileyTagName && hasLauchHook)
        {
            smileyObject = collision.gameObject;
            smileyObject.transform.SetParent(transform);
            hasEmoji = true;
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        collision.gameObject.transform.parent = null;
    }

}
