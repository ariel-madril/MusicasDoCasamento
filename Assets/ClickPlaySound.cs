using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AK.Wwise;
using System;

[Serializable]
public class WwiseEventPair
{
    public AK.Wwise.Event m_PlaySoundEvent;

    public AK.Wwise.Event m_StopSoundEvent;
}
public class ClickPlaySound : MonoBehaviour
{
    public static WwiseEventPair m_LastPlayingEvent;

    [SerializeField]
    WwiseEventPair m_SoundEvent;
    // Start is called before the first frame update
    void Start()
    {
        ClickPlaySound.m_LastPlayingEvent = null;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlaySound()
    {
        StartCoroutine(PlayNext());
    }

    IEnumerator PlayNext()
    {
        float waitTime = 2;
        if (ClickPlaySound.m_LastPlayingEvent == null)
        {
            ClickPlaySound.m_LastPlayingEvent = m_SoundEvent;
            waitTime = 0;
        }
        else
        {
            AkSoundEngine.PostEvent(ClickPlaySound.m_LastPlayingEvent.m_StopSoundEvent.Name, gameObject);
        }
        ClickPlaySound.m_LastPlayingEvent = m_SoundEvent;
        yield return new WaitForSeconds(waitTime);
        AkSoundEngine.PostEvent(m_SoundEvent.m_PlaySoundEvent.Name, gameObject);
    }
}
