using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EmojiType { HAPPY , SAD , ANGRY}

public class T6_EmojiInteractions : MonoBehaviour
{
    public EmojiType emojiType;
    public bool isBeingShot = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("T6_Emoji") && isBeingShot)
        {
            switch (emojiType)
            {
                case EmojiType.HAPPY:
                    switch (collision.gameObject.GetComponent<T6_EmojiInteractions>().emojiType)
                    {
                        case EmojiType.HAPPY:
                            break;
                        case EmojiType.SAD:
                            break;
                        case EmojiType.ANGRY:
                            Destroy(collision.gameObject);
                            Destroy(this.gameObject);
                            break;
                    }
                    break;

                case EmojiType.SAD:
                    switch (collision.gameObject.GetComponent<T6_EmojiInteractions>().emojiType)
                    {
                        case EmojiType.HAPPY:
                            Destroy(collision.gameObject);
                            Destroy(this.gameObject);
                            break;
                        case EmojiType.SAD:
                            break;
                        case EmojiType.ANGRY:
                            break;
                    }
                    break;

                case EmojiType.ANGRY:
                    switch (collision.gameObject.GetComponent<T6_EmojiInteractions>().emojiType)
                    {
                        case EmojiType.HAPPY:
                            break;
                        case EmojiType.SAD:
                            Destroy(collision.gameObject);
                            Destroy(this.gameObject);
                            break;
                        case EmojiType.ANGRY:
                            break;
                    }
                    break;
            }
        }
    }
}
