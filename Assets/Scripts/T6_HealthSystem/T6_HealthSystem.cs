using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

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
        Debug.Log("Game Over");
        gameOverScreen.SetActive(true);
    }

    public void LifeUp(int value)
    {
        Debug.Log("Life Up");
        progressBar.timer += value;
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
