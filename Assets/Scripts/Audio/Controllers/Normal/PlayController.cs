using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayController : AudioController
{
    
    public void PlaySound()
    {
        source.Play();
    }

    public void StopSound()
    {
        source.Stop();
    }

}
