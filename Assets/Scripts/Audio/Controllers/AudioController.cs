using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public abstract class AudioController : MonoBehaviour
{

    [SerializeField]
    protected AudioSource source;

    private void Reset()
    {
        source = GetComponent<AudioSource>();
    }


}
