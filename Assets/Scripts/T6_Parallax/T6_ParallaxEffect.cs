using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class T6_ParallaxEffect : MonoBehaviour
{
    [SerializeField] private float movingSpeed = 0.1f;
    [SerializeField] public float parallaxEffect;
    private float lenght, startPosX;
    private Vector3 spriteSize;
    private float dist = 0.0f, temp = 0.0f;
    private void Start()
    {
        lenght = GetComponent<SpriteRenderer>().bounds.size.x;
        startPosX = transform.position.x;
    }
    private void Update()
    {
        temp = transform.position.x * (1 - parallaxEffect);
        dist = transform.position.x * parallaxEffect;
        //transform.position = new Vector3(transform.position.x - movingSpeed * Time.deltaTime, transform.position.y, transform.position.z);
        transform.position = new Vector3(transform.position.x - dist, transform.position.y, transform.position.z);
        if (temp > startPosX + lenght) startPosX += lenght;
        else if (temp < startPosX - lenght) startPosX -= lenght;
    }
}
