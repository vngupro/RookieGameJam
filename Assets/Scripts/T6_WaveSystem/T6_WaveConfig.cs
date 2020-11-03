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
            number = 3,
            minSpeed = 0.5f,
            maxSpeed = 2.5f
        },

        new T6_EmojiClass{ 
            type = EmojiType.SAD, 
            number = 3,
            minSpeed = 0.5f,
            maxSpeed = 2.5f
        },

        new T6_EmojiClass
        {
            type = EmojiType.ANGRY,
            number = 3,
            minSpeed = 0.5f,
            maxSpeed = 2.5f
        }
    };

    [Header("Wave Parameteters")]
    [SerializeField] float timeBeforeNextWave = 2.0f;
    [SerializeField] float waveTime = 10.0f;
    [SerializeField] float globalSpeed = 1.0f;

    public List<bool> GetActiveLine() {
        List<bool> ActiveLineList = new List<bool>();
        ActiveLineList.Add(line1);
        ActiveLineList.Add(line2);
        ActiveLineList.Add(line3);
        ActiveLineList.Add(line4);
        ActiveLineList.Add(line5);
        return ActiveLineList;
    }
    public List<T6_EmojiClass> GetEmojiList() { return emojiList; }
    public float GetWaveTime() { return waveTime; }
    public float GetGlobalSpeed() { return globalSpeed; }
    


}

