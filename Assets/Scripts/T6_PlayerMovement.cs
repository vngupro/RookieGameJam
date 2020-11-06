using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using UnityEngine;

public class T6_PlayerMovement : MonoBehaviour
{
    
    float inputVertical;
    float timer = 0.1f;
    [SerializeField] float timeInput = 0.1f;
    [SerializeField] List<Transform> playerLineList = new List<Transform>();
    private int currentLine = 2;
    private bool isMoving = false;

    private void Start()
    {
        transform.position = playerLineList[currentLine].position;
    }
    // Update is called once per frame
    void Update()
    {
        inputVertical = Input.GetAxisRaw("Vertical");

        //if (Input.GetKeyDown(KeyCode.Z) && pos < 2)
        //{
        //    gameObject.transform.position = new Vector2(transform.position.x, transform.position.y + 3);
        //    pos++;
        //}
        //if (Input.GetKeyDown(KeyCode.S) && pos > -2)
        //{
        //    gameObject.transform.position = new Vector2(transform.position.x, transform.position.y - 3);
        //    pos--;
        //}

        timer -= Time.deltaTime;
        if (inputVertical == 1 && timer < 0 && currentLine > 0 && !isMoving)
        {
            isMoving = true;
            currentLine--;
            transform.position = playerLineList[currentLine].position;
            timer = timeInput;
        }else if (inputVertical == -1 && timer < 0 && currentLine < playerLineList.Count - 1 && !isMoving)
        {
            isMoving = true;
            currentLine++;
            transform.position = playerLineList[currentLine].position;
            timer = timeInput;
        }else if (inputVertical == 0)
        {
            isMoving = false;
        }
    }
}
