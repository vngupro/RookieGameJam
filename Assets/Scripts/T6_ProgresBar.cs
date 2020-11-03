using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class T6_ProgresBar : MonoBehaviour
{
    private Slider slider;
    [SerializeField] private float timer = 60;
    private float maxTimer;
    private bool timerIsUpdating = false;
    public float updateTime = .5f;
    public Image fillImage;
    [SerializeField] private Color orange;
    [SerializeField] private Color red;

    private void Start()
    {
        maxTimer = timer;
        slider = GetComponentInChildren<Slider>();
    }

    private void Update()
    {
        timer -= Time.deltaTime;
        if (!timerIsUpdating)
        {
            slider.value = timer / maxTimer;
            Debug.Log(timer);
            timerIsUpdating = true;
            StartCoroutine(UpdateTimerAfterSec());
        }
        if (slider.value < .4 && slider.value > .2)
        {
            fillImage.color = orange;
        }else if (slider.value < .2)
        {
            fillImage.color = red;
        }
    }

    IEnumerator UpdateTimerAfterSec()
    {
        yield return new WaitForSecondsRealtime(updateTime);
        timerIsUpdating = false;
    }
}
