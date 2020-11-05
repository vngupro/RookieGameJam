/*using Microsoft.Unity.VisualStudio.Editor;*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class T6_StrengthChanger : MonoBehaviour
{
    public T6_SmileyStrengths listOfStrengths;
    public List<EmojiType> listEmoji;
    private Animator animator;
    [SerializeField] private UnityEngine.UI.Image rightImage;
    [SerializeField] private UnityEngine.UI.Image botImage;
    [SerializeField] private UnityEngine.UI.Image leftImage;

    [SerializeField] private Sprite angry;
    [SerializeField] private Sprite sad;
    [SerializeField] private Sprite fear;

    [SerializeField] private AudioSource myaudio;
    [SerializeField] private AudioSource passagePietionSon;

    EmojiType emoji;

    private void Awake()
    {
        T6_TimerEvent.milestoneTimer.AddListener(Milestone);
        animator = GetComponent<Animator>();
        ChangeStrengths();
    }
    private void ChangeStrengths()
    {
        listOfStrengths.angry.Clear();
        listOfStrengths.sad.Clear();
        listOfStrengths.happy.Clear();
        listOfStrengths.fear.Clear();
        listEmoji.Add(EmojiType.HAPPY);
        listEmoji.Add(EmojiType.ANGRY);
        listEmoji.Add(EmojiType.SAD);
        listEmoji.Add(EmojiType.FEAR);

        int i = Random.Range(1 , listEmoji.Count );
        
        listOfStrengths.happy.Add(listEmoji[i]);
        listEmoji.RemoveAt(i);
        
        switch (i)
        {
            case 1:
                i = Random.Range(1, 2);
                listOfStrengths.angry.Add(listEmoji[i]);
                rightImage.sprite = angry;
                emoji = listEmoji[i];
                break;
            case 2:
                i = Random.Range(1, 2);
                listOfStrengths.sad.Add(listEmoji[i]);
                rightImage.sprite = sad;
                emoji = listEmoji[i];
                break;
            case 3:
                i = Random.Range(1, 2);
                listOfStrengths.fear.Add(listEmoji[i]);
                rightImage.sprite = fear;
                emoji = listEmoji[i];
                break;
        }
        listEmoji.RemoveAt(i);
        i = 1;
        switch (emoji)
        {
            case EmojiType.ANGRY:
                listOfStrengths.angry.Add(listEmoji[i]);
                botImage.sprite = angry;
                emoji = listEmoji[i];
                break;
            case EmojiType.SAD:
                listOfStrengths.sad.Add(listEmoji[i]);
                botImage.sprite = sad;
                emoji = listEmoji[i];
                break;
            case EmojiType.FEAR:
                listOfStrengths.fear.Add(listEmoji[i]);
                botImage.sprite = fear;
                emoji = listEmoji[i];
                break;
        }
        listEmoji.RemoveAt(i);
        i = 0;

        switch (emoji)
        {
            case EmojiType.ANGRY:
                listOfStrengths.angry.Add(listEmoji[i]);
                leftImage.sprite = angry;
                emoji = listEmoji[i];
                break;
            case EmojiType.SAD:
                listOfStrengths.sad.Add(listEmoji[i]);
                leftImage.sprite = sad;
                emoji = listEmoji[i];
                break;
            case EmojiType.FEAR:
                listOfStrengths.fear.Add(listEmoji[i]);
                leftImage.sprite = fear;
                emoji = listEmoji[i];
                break;
        }

        listEmoji.Clear();
    }
  
    public void ChangeAnimation()
    {
        ChangeStrengths();
        animator.SetTrigger("ChangeTriForce");
        Time.timeScale = .1f;
    }

    public void NormalTime()
    {
        Time.timeScale = 1;
    }

    private void Milestone(MilestoneTimerData data)
    {
        StartCoroutine(MilestoneWait());
    }

    IEnumerator MilestoneWait()
    {
        yield return new WaitForSeconds(2);
        ChangeAnimation();
        myaudio.Play();
        passagePietionSon.Play();
    }
}
