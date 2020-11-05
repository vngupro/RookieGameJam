using System.Collections;
using System.Collections.Generic;
/*using UnityEditorInternal;*/
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
    [SerializeField]Transform startPosition;
    GameObject smileyObject;
    Rigidbody2D rb;
    Collider2D hookCollider;
    [SerializeField] private AudioSource audio;
    [Header("Sound Name")]
    [SerializeField] private string hookLaunch = "";
    [SerializeField] private string hookGrab = "";
    [SerializeField] private string hookBack = "";
    [SerializeField] private string emojiThrow1 = "";
    [SerializeField] private string emojiThrow2 = "";
    [SerializeField] private string emojiThrow3 = "";
    [SerializeField] private string emojiThrow4 = "";
    private int soundCount = 1;


    #region Awake and Start
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        hookCollider = GetComponent<Collider2D>();

        canLaunch = true;
        hasLauchHook = false;
        canThrow = false;
        hasEmoji = false;
        T6_TimerEvent.milestoneTimer.AddListener(ResetHookParameters);
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
        else
        {
            canThrow = false;
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
            //audio.Play();
            rb.velocity = new Vector2(hookSpeed, 0);
            canLaunch = false;
            hasLauchHook = true;
            T6_SoundEvent.playSound.Invoke(new SoundEventData(hookLaunch));
            StartCoroutine(PlayHookBack());
        }
    }
    IEnumerator PlayHookBack()
    {
        
        yield return new WaitForSeconds(0.05f);
        T6_SoundEvent.playSound.Invoke(new SoundEventData(hookBack));
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
        if (transform.position.x < startPosition.position.x && isComingBackHook && !hasEmoji)
        {
            rb.velocity = new Vector2(0, 0);
            transform.position = startPosition.position;
            isComingBackHook = false;
            canLaunch = true;

        }

        //Got Emoji
        if (transform.position.x < startPosition.position.x && isComingBackHook && hasEmoji)
        {
            rb.velocity = new Vector2(0, 0);
            transform.position = startPosition.position;
            isComingBackHook = false;
            StartCoroutine(ThrowDelay(timeDelay));

        }
    }

    public void EmojiComeBackWithHook()
    {
        //ramène le smiley au joueur
        if (transform.position.x > startPosition.position.x)
        {
            if(smileyObject != null)
            {
                smileyObject.transform.position = gameObject.transform.position;
            }
            
        }
        //s'arrête avec le smiley quand il est arrivé, replacement du grab
        else
        {
            if(smileyObject != null)
                smileyObject.transform.position = transform.position;
        }
    }

    public void EmojiThrow()
    {
        if (Input.GetAxis("Fire1") == 1 && canThrow && smileyObject != null)
        {
            smileyObject.GetComponent<Rigidbody2D>().velocity = new Vector3(emojiThrowSpeed, 0); // on envoie le smiley droit devant
            smileyObject.GetComponent<T6_EmojiInteractions>().isBeingShot = true;
            StartCoroutine(delay(timeDelay));
            smileyObject.GetComponent<Collider2D>().isTrigger = false;
            //T6_EmojiEvent.hitEmojiEvent.Invoke();
            
            if(soundCount == 1)
            {
                T6_SoundEvent.playSound.Invoke(new SoundEventData(emojiThrow1));
                StartCoroutine(ChangeSound());
            }
            else if(soundCount == 2)
            {
                T6_SoundEvent.playSound.Invoke(new SoundEventData(emojiThrow2));
                StartCoroutine(ChangeSound());
            }
            else if(soundCount == 3)
            {
                T6_SoundEvent.playSound.Invoke(new SoundEventData(emojiThrow3));
                StartCoroutine(ChangeSound());

            }
            else if(soundCount == 4)
            {
                T6_SoundEvent.playSound.Invoke(new SoundEventData(emojiThrow4));
                StartCoroutine(ChangeSound());

            }


        }
    }

    IEnumerator ChangeSound()
    {
        yield return new WaitForSeconds(0.1f);
        if(soundCount == 4)
        {
            soundCount = 1;
        }
        else
        {
            soundCount++;
        }
       
    }
    public void ResetHookParameters(MilestoneTimerData data)
    {
        StartCoroutine(MilestoneDelay());
    }
    IEnumerator MilestoneDelay()
    {
        yield return new WaitForSeconds(2);
        canLaunch = true;
        hasLauchHook = false;
        canThrow = false;
        hasEmoji = false;

    }
    IEnumerator delay(float t)
    {
        yield return new WaitForSeconds(t);
        canLaunch = true;
        hasEmoji = false;
        canThrow = false;
    }

    IEnumerator ThrowDelay(float t)
    {
        yield return new WaitForSeconds(t);
        canThrow = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == smileyTagName && hasLauchHook)
        {
            if (!collision.GetComponent<T6_EmojiInteractions>().isBeingShot) //-------------------------
            {
                T6_SoundEvent.playSound.Invoke(new SoundEventData(hookGrab));
                smileyObject = collision.gameObject;
                smileyObject.transform.SetParent(transform);
                hasEmoji = true;
                collision.isTrigger = true;
                
            }
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if(collision != null)
        {
            collision.gameObject.transform.parent = null;
        }
        
    }

}
