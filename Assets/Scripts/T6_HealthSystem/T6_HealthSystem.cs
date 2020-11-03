using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class T6_HealthSystem : MonoBehaviour
{
    [SerializeField] int maxLife = 5;
    private int currentLife;

    [SerializeField] GameObject lifePrefab;
    [SerializeField] GameObject canvas;
    [SerializeField] GameObject gameOverScreen;
    [SerializeField] float offSetX = 1.0f;
    [SerializeField] float offSetY = 1.0f;
    [SerializeField] float SpaceBetweenHeart = 1.0f;
    List<GameObject> lifeList = new List<GameObject>();

    [Header("Debug")]
    [SerializeField] bool kill = false;
    private void Awake()
    {
        currentLife = maxLife;

        for (int i = 0; i < maxLife; i++)
        {
            GameObject life = Instantiate(lifePrefab, new Vector3(0,0,0), canvas.transform.rotation) as GameObject;
            life.transform.SetParent(canvas.transform, false);
            life.transform.position = new Vector3(life.transform.position.x + offSetX + SpaceBetweenHeart * i, life.transform.position.y - offSetY, life.transform.position.z);
            life.SetActive(true);
            lifeList.Add(life);
        }

        T6_HealthEvent.deathZoneHit.AddListener(DeathZoneHit);
    }

    private void Update()
    {
        if (kill)
        {
            DebugKill();
        }
    }
    public void DeathZoneHit(HitEventData data)
    {
        if(currentLife > 0)
        {
            TakeDamage();
        }
            
        if(currentLife <= 0)
        {
            DeathTrigger();
        }
    }

    public void TakeDamage()
    {
        lifeList[currentLife - 1].SetActive(false);
        currentLife--;   
    }

    public void DeathTrigger()
    {
        Debug.Log("Game Over");
        gameOverScreen.SetActive(true);
    }

    public void LifeUp()
    {
        Debug.Log("Life Up");
        currentLife++;
    }

    public void MaxLifeUp(int maxLifeAdd)
    {
        maxLife += maxLifeAdd;
    }

    private void DebugKill()
    {
        currentLife = 0;
        DeathTrigger();
    }

}
