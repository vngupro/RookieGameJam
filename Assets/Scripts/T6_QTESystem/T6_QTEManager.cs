using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class T6_QTEManager : MonoBehaviour
{
    [SerializeField] TMP_Text qteText;
    [SerializeField] Image darkScreen;

    private bool activeQte = false;
    private bool waitingForKey;
    private int correctKey;
    private int QTEGen;
    [SerializeField] int CountingDown;

    // Start is called before the first frame update
    void Start()
    {
        var tmp = darkScreen.color;
        tmp.a = 0;
        darkScreen.color = tmp;
        qteText.text = "";
        activeQte = false;
    }

    private void Update()
    {
        if(!waitingForKey)
        {
            var tmp = darkScreen.color;
            tmp.a = 0.5f;
            darkScreen.color = tmp;
            qteText.text = "";
            QTEGen = Random.Range(0, 5);
            CountingDown = 1;
            StartCoroutine(CountDown());
            switch (QTEGen)
            {
                case 0:
                    waitingForKey = true;
                    qteText.text = "[A]";
                    break;
                case 1:
                    waitingForKey = true;
                    qteText.text = "[Z]";
                    break;
                case 2:
                    waitingForKey = true;
                    qteText.text = "[E]";
                    break;
                case 3:
                    waitingForKey = true;
                    qteText.text = "[Q]";
                    break;
                case 4:
                    waitingForKey = true;
                    qteText.text = "[S]";
                    break;
                case 5:
                    waitingForKey = true;
                    qteText.text = "[D]";
                    break;
            }
        }

        Debug.Log(Input.anyKeyDown);

        if(QTEGen == 0)
        {
            if (Input.anyKeyDown)
            {
                if (Input.GetKeyDown(KeyCode.A))
                {
                    correctKey = 1;
                    StartCoroutine(KeyPressing());
                }
                else
                {
                    correctKey = 2;
                    StartCoroutine(KeyPressing());
                }
            }
        }

        if (QTEGen == 1)
        {
            if (Input.anyKeyDown)
            {
                if (Input.GetKeyDown(KeyCode.Z))
                {
                    correctKey = 1;
                    StartCoroutine(KeyPressing());
                }
                else
                {
                    correctKey = 2;
                    StartCoroutine(KeyPressing());
                }
            }
        }

        if (QTEGen == 2)
        {
            if (Input.anyKeyDown)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    correctKey = 1;
                    StartCoroutine(KeyPressing());
                }
                else
                {
                    correctKey = 2;
                    StartCoroutine(KeyPressing());
                }
            }
        }

        if (QTEGen == 3)
        {
            if (Input.anyKeyDown)
            {
                if (Input.GetKeyDown(KeyCode.Q))
                {
                    correctKey = 1;
                    StartCoroutine(KeyPressing());
                }
                else
                {
                    correctKey = 2;
                    StartCoroutine(KeyPressing());
                }
            }
        }

        if (QTEGen == 4)
        {
            if (Input.anyKeyDown)
            {
                if (Input.GetKeyDown(KeyCode.S))
                {
                    correctKey = 1;
                    StartCoroutine(KeyPressing());
                }
                else
                {
                    correctKey = 2;
                    StartCoroutine(KeyPressing());
                }
            }
        }

        if (QTEGen == 5)
        {
            if (Input.anyKeyDown)
            {
                if (Input.GetKeyDown(KeyCode.D))
                {
                    correctKey = 1;
                    StartCoroutine(KeyPressing());
                }
                else
                {
                    correctKey = 2;
                    StartCoroutine(KeyPressing());
                }
            }
        }
    }

    IEnumerator KeyPressing()
    {
        QTEGen = 6;
        if (correctKey == 1)
        {
            CountingDown = 2;
            yield return new WaitForSeconds(1.5f);
            correctKey = 0;
            qteText.text = "";
            var tmp = darkScreen.color;
            tmp.a = 0;
            darkScreen.color = tmp;
            qteText.text = "";
            yield return new WaitForSeconds(1.5f);
            waitingForKey = false;
            CountingDown = 1;
        }
    }

    IEnumerator CountDown()
    {
        yield return new WaitForSeconds(3.5f);
        if(CountingDown == 1)
        {
            QTEGen = 6;
            CountingDown = 2;
            Debug.Log("QTE Fail");
            yield return new WaitForSeconds(1.5f);
            correctKey = 0;
            qteText.text = "";
            var tmp = darkScreen.color;
            tmp.a = 0;
            darkScreen.color = tmp;
            qteText.text = "";
            yield return new WaitForSeconds(1.5f);
            waitingForKey = false;
            CountingDown = 1;
        }
    }

}
