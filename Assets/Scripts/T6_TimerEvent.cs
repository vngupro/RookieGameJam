using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public static class T6_TimerEvent
{
    public static VictoryTimer victoryTimer = new VictoryTimer();
    public static MilestoneTimer milestoneTimer = new MilestoneTimer();
}

public class VictoryTimer : UnityEvent<VictoryTimerData> { }
public class MilestoneTimer : UnityEvent<MilestoneTimerData> { }

public class VictoryTimerData
{
    public float timer;
    public VictoryTimerData(float timer)
    {
        this.timer = timer;
    }
}

public class MilestoneTimerData
{
    public float milestoneTime;
    public int milestone;
    public MilestoneTimerData(float milestoneTime, int milestone)
    {
        this.milestoneTime = milestoneTime;
        this.milestone = milestone;
    }
}