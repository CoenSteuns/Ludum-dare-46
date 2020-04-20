using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomTimedPlayer : RandomClipController
{
    
    [SerializeField]
    private float minDelay, maxdelay;

    [SerializeField]
    private bool loop, startOnAwake;

    public bool Loop { get => loop; set => loop = value; }

    private void Awake()
    {
        if (startOnAwake)
            TimedPlay();
    }

    public void TimedPlay()
    {
        StartCoroutine(Playtimed());
    }


    private IEnumerator Playtimed()
    {
        do {
            yield return new WaitForSeconds(Random.Range(minDelay, maxdelay));
            Play();
        } while (loop);
        
    }

}
