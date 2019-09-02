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
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlaySound()
    {
        if(ClickPlaySound.m_LastPlayingEvent == null)
        {
            ClickPlaySound.m_LastPlayingEvent = m_SoundEvent;
        }
        else
        {
            Debug.Log("stopping " + ClickPlaySound.m_LastPlayingEvent.m_StopSoundEvent.Name);
            AkSoundEngine.PostEvent(ClickPlaySound.m_LastPlayingEvent.m_StopSoundEvent.Name, gameObject);
        }
        AkSoundEngine.PostEvent(m_SoundEvent.m_PlaySoundEvent.Name, gameObject);
    }
}
