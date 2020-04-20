using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomClipController : AudioController
{
    [SerializeField]
    protected List<AudioClip> clips;

    public void Play()
    {
        source.clip = clips[Random.Range(0, clips.Count)];
        source.Play();
    }

    
}
