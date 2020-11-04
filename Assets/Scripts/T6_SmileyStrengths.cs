using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "T6_Strengths")]

public class T6_SmileyStrengths : ScriptableObject
{
    public List<EmojiType> happy;
    public List<EmojiType> sad;
    public List<EmojiType> angry;
    public List<EmojiType> fear;
}
