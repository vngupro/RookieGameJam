using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class T6_ParallaxEffect : MonoBehaviour
{
    public float movingSpeed = 0.1f;
    [SerializeField] private float id;
    [SerializeField] Transform before;
    private float length, startPosX;
    private float distance = 0.0f;
    private void Start()
    {
        length = GetComponent<SpriteRenderer>().bounds.size.x;
        startPosX = transform.position.x;
    }
    private void Update()
    {
        InfiniteBackground();
    }

    public void InfiniteBackground()
    {

        transform.position = new Vector3(transform.position.x - movingSpeed * Time.deltaTime, transform.position.y, transform.position.z);

        distance = transform.position.x - startPosX;
        if (distance < -length * id && transform.position.x != startPosX && id != 6)
        {
            transform.position = new Vector3(before.position.x + length - 0.5f, transform.position.y, transform.position.z);
        }
    }

}
