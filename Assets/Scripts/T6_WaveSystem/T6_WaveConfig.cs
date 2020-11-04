using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


[CreateAssetMenu(menuName ="T6_Wave")]
public class T6_WaveConfig : ScriptableObject
{
    [SerializeField] string nameOfWave = "Wave ";
    [TextArea(5, 5)]
    [SerializeField] string description = "Wave on 5 lines with angry, sad and happy";

    [Header("Active Line")]
    [SerializeField] bool line1 = true;
    [SerializeField] bool line2 = true;
    [SerializeField] bool line3 = true;
    [SerializeField] bool line4 = true;
    [SerializeField] bool line5 = true;

    [Header("Emoji Parameters")]
    [SerializeField] List<T6_EmojiClass> emojiList = new List<T6_EmojiClass>{
        new T6_EmojiClass{
            type = EmojiType.HAPPY,
            limitNumber = 100,
            minSpeed = 0.5f,
            maxSpeed = 2.5f
        },

        new T6_EmojiClass{ 
            type = EmojiType.SAD, 
            limitNumber = 100,
            minSpeed = 0.5f,
            maxSpeed = 2.5f
        },

        new T6_EmojiClass
        {
            type = EmojiType.ANGRY,
            limitNumber = 100,
            minSpeed = 0.5f,
            maxSpeed = 2.5f
        },

        new T6_EmojiClass
        {
            type = EmojiType.FEAR,
            limitNumber = 100,
            minSpeed = 0.5f,
            maxSpeed = 2.5f
        }

    };

    [Header("Wave Parameteters")]
    //[SerializeField] bool ActivateScoreForNextWave = false;
    [SerializeField] float scoreForNextWave = 10.0f;
    [SerializeField] float timeBeforeNextWave = 2.0f;
    //[SerializeField] bool ActivateWaveDuration = true;
    [SerializeField] float waveDuration = 1000.0f;
    [SerializeField] float globalSpeed = 1.0f;

    public List<bool> GetLineList() {
        List<bool> LineList = new List<bool>();
        LineList.Add(line1);
        LineList.Add(line2);
        LineList.Add(line3);
        LineList.Add(line4);
        LineList.Add(line5);
        return LineList;
    }
    public List<T6_EmojiClass> GetEmojiList() { return emojiList; }
    //public bool GetActivateWaveDuration() { return ActivateWaveDuration; }
    public float GetWaveDuration() { return waveDuration; }
    public float GetGlobalSpeed() { return globalSpeed; }
    //public bool GetActivateScoreForNextWave() { return ActivateScoreForNextWave; }
    public float GetTimeBeforeNextWave() { return timeBeforeNextWave; }
    public float GetScoreForNextWave() { return scoreForNextWave; }
    


}

