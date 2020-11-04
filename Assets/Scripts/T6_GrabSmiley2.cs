using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T6_GrabSmiley2 : MonoBehaviour
{
    private GameObject smileyObject;
    private Rigidbody2D rb; // rigidbody du grab
    public Transform maxGrabDistance;

    private bool canGrab; // peut lancer le grab
    private bool canThrow; //peut lancer le smiley
    [SerializeField]
    private bool hasEmoji; //si le grapin a un emoji
    private bool isFollowingGrab; //si l'émoji suit le grab

    [SerializeField]
    private float defaultForwardGrabSpeed;
    [SerializeField]
    private float emojiThrowSpeed;
    [SerializeField]
    private float timeDelay; // durée de temps pour un délais
    private float actualSpeed;

    [SerializeField] private string smileyTagName;

    private Vector3 startPosition;
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();

        canGrab = true;
        canThrow = false;
        hasEmoji = false;
        isFollowingGrab = false;

        actualSpeed = defaultForwardGrabSpeed;

        startPosition = gameObject.transform.position;
    }
    void Update()
    {
        //debug des bools
        //print("canGrab:" + canGrab);
        //print("canThrow:" + canThrow);
        //print("hasEmoji:" + hasEmoji);
        //print("isFollowingGrab:" + isFollowingGrab);

        //Lancer le grapin
        if (Input.GetAxis("Fire1") == 1 && canGrab && canThrow == false && hasEmoji == false)
        {
            LaunchGrab();
        }

        //fait revenir le grapin
        if (transform.position.x >= maxGrabDistance.position.x)
        {
            hasEmoji = false;
            rb.velocity = new Vector2(-actualSpeed, 0);
        }

        //fait arrêter le grapin quand il est à la position de base
        if (transform.position.x < startPosition.x && !hasEmoji && !canThrow)
        {
            canGrab = true;
            rb.velocity = new Vector2(0, 0);
        }


        //si on a un emoji
        if(hasEmoji == true)
        {
            //ramène le smiley au joueur
            if (transform.position.x > startPosition.x)
            {
                smileyObject.transform.position = gameObject.transform.position;
                rb.velocity = new Vector2(-actualSpeed, 0);
                gameObject.GetComponent<BoxCollider2D>().enabled = false; //desactiver collider grab
                smileyObject.GetComponent<Collider2D>().enabled = false; //desactiver collider smiley
            }
            //s'arrête avec le smiley quand il est arrivé, replacement du grab
            else
            {
                smileyObject.transform.position = gameObject.transform.position;
                rb.velocity = new Vector2(0, 0);
                canThrow = true;
            }
            //lance l'émoji
            if (Input.GetAxis("Fire1") == 1 && canThrow)
            {
                transform.position = new Vector2(startPosition.x, transform.position.y); //reset du grab
                smileyObject.GetComponent<Rigidbody2D>().velocity = new Vector3(emojiThrowSpeed,0); // on envoie le smiley droit devant
                smileyObject.GetComponent<CircleCollider2D>().enabled = true; //activer le collider du smiley
                smileyObject.GetComponent<T6_EmojiInteractions>().isBeingShot = true;
                StartCoroutine(delay(timeDelay));
                gameObject.GetComponent<BoxCollider2D>().enabled = true; // activer collider grab
                //smileyObject.transform.position = transform.position;
                
            }
        }
        

    }
    void LaunchGrab()
    {
        canGrab = false; // ne peut plus lancer le grapin
        rb.velocity = new Vector2(actualSpeed, 0); //le grapin fonce vers la droite 
    }

    IEnumerator delay(float t)
    {
        yield return new WaitForSeconds(t);
        canGrab = true;
        hasEmoji = false;
        canThrow = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == smileyTagName)
        {
            smileyObject = collision.gameObject;
            hasEmoji = true;
            smileyObject.transform.position = gameObject.transform.position;
            isFollowingGrab = true;
        }
    }

}
