﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T6_StrengthChanger : MonoBehaviour
{
    public T6_SmileyStrengths listOfStrengths;
    public List<EmojiType> listEmoji;

    private void Start()
    {
        listOfStrengths.angry.Clear();
        listOfStrengths.sad.Clear();
        listOfStrengths.happy.Clear();
        listOfStrengths.fear.Clear();
        listEmoji.Add(EmojiType.HAPPY);
        listEmoji.Add(EmojiType.ANGRY);
        listEmoji.Add(EmojiType.SAD);
        listEmoji.Add(EmojiType.FEAR);
        ChangeStrengths();
    }

    public void ChangeStrengths()
    {
        int i = Random.Range(1, 3);

        listOfStrengths.happy.Add(listEmoji[i]);
        listEmoji.RemoveAt(i);

        i = Random.Range(0, 2);
        while (listEmoji[i] == EmojiType.ANGRY)
        {
            i = Random.Range(0, 2);
        }
        listOfStrengths.angry.Add(listEmoji[i]);
        listEmoji.RemoveAt(i);

        i = Random.Range(0, 1);
        while (listEmoji[i] == EmojiType.SAD)
        {
            i = Random.Range(0, 1);
        }
        listOfStrengths.sad.Add(listEmoji[i]);
        listEmoji.RemoveAt(i);
        listOfStrengths.fear.Add(listEmoji[0]);
        listEmoji.Clear();

    }
}
