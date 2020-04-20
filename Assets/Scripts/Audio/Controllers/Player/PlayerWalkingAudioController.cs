using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWalkingAudioController : AudioController
{
    [SerializeField]
    private List<AudioClip> clips;

    [SerializeField]
    private float minDelay, maxDelay;

    private Coroutine audioWalkRoutine;

    public void StartWalking()
    {
        audioWalkRoutine = StartCoroutine(PlayRandomClips());
    }

    public void StopWalking()
    {
        if (audioWalkRoutine != null)
            StopCoroutine(audioWalkRoutine);
    }

    private IEnumerator PlayRandomClips()
    {
        while (true)
        {
            AudioClip clip = clips[Random.Range(0, clips.Count)];
            source.PlayOneShot(clip);
            yield return new WaitForSeconds(Random.Range(minDelay, maxDelay));
        }
    }

}
