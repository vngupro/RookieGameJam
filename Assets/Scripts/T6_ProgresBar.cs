using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

public class T6_ProgresBar : MonoBehaviour
{
    private Slider slider;
    [SerializeField] public float timer = 60.0f;
    public float maxTimer;
    private bool timerIsUpdating = false;
    public float updateTime = .5f;
    public Image fillImage;
    [SerializeField] private Color orange;
    [SerializeField] private Color red;
    [SerializeField] private Color green;
    public bool gameIsOver = false;

    [SerializeField] int rngFactor = 5;

    private void Start()
    {
        maxTimer = timer;
        slider = GetComponentInChildren<Slider>();
    }

    private void Update()
    {
        if (!gameIsOver)
        {
            timer -= Time.deltaTime;
        }else if (gameIsOver && timer < maxTimer)
        {
            timer += Time.deltaTime * 2;
        }

        if (!timerIsUpdating)
        {
            slider.value = timer / maxTimer;
            timerIsUpdating = true;
            StartCoroutine(UpdateTimerAfterSec());
        }

        if (slider.value < .5 && slider.value > .2)
        {
            fillImage.color = orange;
        }else if (slider.value < .2)
        {
            fillImage.color = red;
        }else if(slider.value > 0.5f)
        {
            fillImage.color = green;
        }


    }

    private void FixedUpdate()
    {
        //Bonus Gacha
        //if(timer < maxTimer / 4)
        //{
        //    T6_BonusEvent.batterieLeftChange.Invoke(new BonusEventData(timer));
        //}
        //else if (timer < maxTimer / 2)
        //{
        //    T6_BonusEvent.batterieLeftChange.Invoke(new BonusEventData(timer));
        //}
    }
    IEnumerator UpdateTimerAfterSec()
    {
        yield return new WaitForSecondsRealtime(updateTime);
        timerIsUpdating = false;
    }
}
