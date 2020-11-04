using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class T6_ParallaxEffect : MonoBehaviour
{
    [SerializeField] private float movingSpeed = 0.1f;
    private Vector3 spriteSize;
    private Vector3 originalPosition;
    private void Start()
    {
        spriteSize = GetComponent<SpriteRenderer>().bounds.size / 2;
        originalPosition = transform.position;
    }
    private void Update()
    {
        transform.position = new Vector3(transform.position.x - movingSpeed * Time.deltaTime, transform.position.y, transform.position.z);
    }
}
