using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public static class T6_ScoreEvent {
    public static HitScoreEvent hitWeakEmoji = new HitScoreEvent();
}

public class HitScoreEvent : UnityEvent<HitScoreEventData> { }

public class HitScoreEventData
{
    public GameObject emojiHitter;
    public GameObject emojiHit;
    public float score;

    public HitScoreEventData(GameObject emojiHitter, GameObject emojiHit, float score)
    {
        this.emojiHitter = emojiHitter;
        this.emojiHit = emojiHit;
        this.score = score;
    }
}