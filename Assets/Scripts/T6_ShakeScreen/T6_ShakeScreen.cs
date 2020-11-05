using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T6_ShakeScreen : MonoBehaviour
{
    [SerializeField] Animator camAnim;

    private void Awake()
    {
        T6_EmojiEvent.hitEmojiEvent.AddListener(CamShake);
    }
    public void CamShake()
    {
        int rand = Random.Range(0, 4);
        if(rand == 0)
        {
            camAnim.SetTrigger("isShaking");
        }
        else if(rand == 1)
        {
            camAnim.SetTrigger("shake2");
        }
        else if(rand == 2)
        {
            camAnim.SetTrigger("shake3");
        }
        else if(rand == 3 || rand == 4)
        {
            camAnim.SetTrigger("shake4");
        }
    }
}
