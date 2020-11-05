using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

//To play a sound use T6_SoundEvent.playSound.Invoke(new SoundEventData([name]);
public class T6_SoundManager : MonoBehaviour
{
    public T6_Sound[] soundList;
    private void Awake()
    {
        foreach(T6_Sound sound in soundList)
        {
            sound.source = gameObject.AddComponent<AudioSource>();
            sound.source.clip = sound.clip;
            sound.source.volume = sound.volume;
            sound.source.pitch = sound.pitch;
        }

        T6_SoundEvent.playSound.AddListener(Play);
    }

    public void Play(SoundEventData data)
    {
        T6_Sound s = Array.Find(soundList, sound => sound.name == data.name);
        if(s == null)
        {
            Debug.LogWarning("Sound:" + data.name + " not found !");
            return;
        }
        s.source.Play();
    }
}
