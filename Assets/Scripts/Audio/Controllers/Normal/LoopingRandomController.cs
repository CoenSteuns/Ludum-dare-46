using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopingRandomController : RandomClipController
{

    [SerializeField]
    private float minDelay, maxDelay;

    private Coroutine audioWalkRoutine;

    public void StartLoop()
    {
        audioWalkRoutine = StartCoroutine(PlayRandomClips());
    }

    public void StopLoop()
    {
        if (audioWalkRoutine != null)
            StopCoroutine(audioWalkRoutine);
    }

    private IEnumerator PlayRandomClips()
    {
        while (true)
        {
            Play();
            yield return new WaitForSeconds(Random.Range(minDelay, maxDelay));
        }
    }
}
