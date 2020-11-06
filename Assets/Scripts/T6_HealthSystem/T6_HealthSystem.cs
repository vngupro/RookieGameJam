using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UI;
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
    bool hasTakeDamage = false;

    [SerializeField] TMP_Text textBatterieValue;
    Vector3 originalTextBatteriePos;
    [SerializeField] float timeShowBValue = 1.0f;
    private bool isLifeAdding = false;
    [SerializeField] float speedShowBValue = 0.5f;

    [SerializeField] Image redScreen;
    [SerializeField] Image greenScreen;
    [SerializeField] float screenTransparency = 0.5f;
    [SerializeField] bool activeScreenAnim = true;
    [SerializeField] float timeScreenFade = 10.0f;
    [Header("Debug")]
    [SerializeField] bool kill = false;
    T6_ProgresBar progressBar;

    [SerializeField] int rngFactor = 5;
    private int damageCount = 0;
    [Header("Sound Name")]
    [SerializeField]private string batterieUp;
    [SerializeField] T6_GameManager gameManager;

    public AudioSource music;
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
        hasTakeDamage = false;
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
            if (activeScreenAnim)
            {
                GreenScreenFade();
            }

        }

        if (hasTakeDamage)
        {
            if (activeScreenAnim)
            {
                RedScreenFade();
            }
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
        damageCount++;
        
        //Screen Animation
        if (activeScreenAnim)
        {
            RedScreenAnim();
        }

        //Bonus Gacha
        if ( (damageCount + 1) % rngFactor == 0)
        {
            //Debug.Log((damageCount + 1) % rngFactor);
            T6_BonusEvent.damageCountChange.Invoke(new BonusEventData(damageCount));
        }
    }

    public void DeathTrigger()
    {
        gameOverScreen.SetActive(true);
        music.Stop();
        gameManager.PauseGame();

    }

    public void LifeAdd(LifeEventData data)
    {
        
        progressBar.timer += data.lifeValue;
        T6_SoundEvent.playSound.Invoke(new SoundEventData(batterieUp));
        if (progressBar.timer > progressBar.maxTimer)
        {
            progressBar.timer = progressBar.maxTimer;
        }
        isLifeAdding = true;
        if (progressBar.timer > progressBar.maxTimer)
        {
            progressBar.timer = progressBar.maxTimer;
        }

        if (activeScreenAnim)
        {
            GreenScreenAnim();
        }


        StartCoroutine(ShowBatterieValue(data.lifeValue));


    }

    public void RedScreenAnim()
    {
        var tempColor = redScreen.color;
        tempColor.a = screenTransparency;
        redScreen.color = tempColor;
        hasTakeDamage = true;
    }

    public void GreenScreenAnim()
    {
        var tempColor = greenScreen.color;
        tempColor.a = screenTransparency;
        greenScreen.color = tempColor;
    }

    public void RedScreenFade()
    {
        var tempColor = redScreen.color;
        tempColor.a -= screenTransparency / timeScreenFade;
        redScreen.color = tempColor;
        if (tempColor.a == 0)
        {
            hasTakeDamage = false;
        }
    }

    public void GreenScreenFade()
    {
        var tempColor = greenScreen.color;
        tempColor.a -= screenTransparency / timeScreenFade;
        greenScreen.color = tempColor;
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
