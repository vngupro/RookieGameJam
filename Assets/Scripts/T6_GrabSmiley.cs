using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class T6_GrabSmiley : MonoBehaviour
{
    bool canGrab = true;
    bool hasGrabbedSmiley, canThrow, isFollowGrab = false;
    private Rigidbody2D rb2D;
    public float grabSpeed;
    public float returnGrabSpeed, throwSpeed;
    private GameObject smileyGrabbed;
    private Vector3 startPos;
    public string emojiTag;
    private void Start()
    {
        rb2D = gameObject.GetComponent<Rigidbody2D>();
        startPos = gameObject.GetComponent<Transform>().position;
        startPos = transform.position;
    }
    void Update()
    {
        print(canThrow);
        if (isFollowGrab) { smileyGrabbed.transform.position = gameObject.transform.position; }
        if (Input.GetKeyDown(KeyCode.Mouse0) && canGrab && hasGrabbedSmiley == false)
        {  
            Grab(); //lancer le grapin
        }
        if (hasGrabbedSmiley && canThrow == false)
        {
            if (gameObject.transform.position.x >= startPos.x)
            {
                rb2D.velocity = new Vector2(-returnGrabSpeed, 0); // retour du grapin
                if(smileyGrabbed.gameObject != null)
                {
                    smileyGrabbed.gameObject.GetComponent<Collider2D>().enabled = false;
                }
            }
            else
            {
                smileyGrabbed.gameObject.GetComponent<Collider2D>().enabled = true;
                rb2D.velocity = new Vector2(0, 0);
                canThrow = true;
            }
        }
        if (Input.GetKeyDown(KeyCode.Mouse0) && canThrow) // si clic gauche...
        {
            //jette le smiley
            isFollowGrab = false;
            canGrab = true;
            hasGrabbedSmiley = false;
            print("throw");
            /*smileyGrabbed.GetComponent<Rigidbody2D>().velocity = new Vector2(throwSpeed, 0);*/
            smileyGrabbed.GetComponent<Rigidbody2D>().AddForce(transform.right * throwSpeed);
            smileyGrabbed = null;
        }
    }
    public void Grab()
    {
        canGrab = false;
        rb2D.velocity = new Vector2(grabSpeed, 0); //va tout droit jusqu'a ce qu'il touche un smiley
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == emojiTag)
        {
            hasGrabbedSmiley = true;
            smileyGrabbed = collision.gameObject;
            smileyGrabbed.transform.position = gameObject.transform.position; //le smiley s'attache au grapin
            isFollowGrab = true;
        }
    }
}
