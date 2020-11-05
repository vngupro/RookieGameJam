﻿using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;
using TMPro;

public class T6_HealthSystem : MonoBehaviour
{
    //private float currentLife;

    //[SerializeField] GameObject lifePrefab;
    //[SerializeField] GameObject canvas;
    //[SerializeField] float offSetX = 1.0f;
    //[SerializeField] float offSetY = 1.0f;
    //[SerializeField] float SpaceBetweenHeart = 1.0f;
    //List<GameObject> lifeList = new List<GameObject>();

    [SerializeField] GameObject gameOverScreen;
    [SerializeField] float damageValue = 1.0f;

    [SerializeField] TMP_Text textBatterieValue;
    Vector3 originalTextBatteriePos;
    [SerializeField] float timeShowBValue = 1.0f;
    private bool isLifeAdding = false;
    [SerializeField] float speedShowBValue = 0.5f;

    [Header("Debug")]
    [SerializeField] bool kill = false;
    T6_ProgresBar progressBar;
    private void Awake()
    {
        progressBar = GetComponent<T6_ProgresBar>();
        //for (int i = 0; i < maxLife; i++)
        //{
        //    GameObject life = Instantiate(lifePrefab, new Vector3(0,0,0), canvas.transform.rotation) as GameObject;
        //    life.transform.SetParent(canvas.transform, false);
        //    life.transform.position = new Vector3(life.transform.position.x + offSetX + SpaceBetweenHeart * i, life.transform.position.y - offSetY, life.transform.position.z);
        //    life.SetActive(true);
        //    lifeList.Add(life);
        //}

        originalTextBatteriePos = textBatterieValue.transform.position;
        textBatterieValue.text = "";
        isLifeAdding = false;
        T6_HealthEvent.deathZoneHit.AddListener(DeathZoneHit);
        T6_HealthEvent.lifeUp.AddListener(LifeAdd);
    }

    private void Update()
    {
        if (kill)
        {
            DebugKill();
        }

        if (isLifeAdding)
        {
            textBatterieValue.transform.Translate(Vector3.up * speedShowBValue);
        }
    }
    public void DeathZoneHit(HitEventData data)
    {
        if(progressBar.timer > 0)
        {
            TakeDamage();
        }
            
        if(progressBar.timer <= 0)
        {
            DeathTrigger();
        }
    }

    public void TakeDamage()
    {

        //lifeList[currentLife - 1].SetActive(false);
        progressBar.timer -= damageValue;  
        
    }

    public void DeathTrigger()
    {
        gameOverScreen.SetActive(true);
    }

    public void LifeAdd(LifeEventData data)
    {
        progressBar.timer += data.lifeValue;
        isLifeAdding = true;
        StartCoroutine(ShowBatterieValue(data.lifeValue));


    }


    IEnumerator ShowBatterieValue(float value)
    {
        
        textBatterieValue.text = "+" + value.ToString();
        yield return new WaitForSeconds(timeShowBValue);
        textBatterieValue.text = "";
        textBatterieValue.transform.position = originalTextBatteriePos;
        isLifeAdding = false;
    }
    //public void MaxLifeUp(int maxLifeAdd)
    //{
    //    maxLife += maxLifeAdd;
    //}

    private void DebugKill()
    {
        progressBar.timer = 0;
        DeathTrigger();
    }

}
