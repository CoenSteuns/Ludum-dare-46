using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Timer : MonoBehaviour
{

    [SerializeField]
    private float startTime;

    private float timeLeft;
    private Coroutine timerRoutine;

    public event Action<Timer> OnTimerFinished;
    public event Action<Timer> OnTimerStopped;
    public event Action<Timer> OnTimerUpdated;
    public event Action<Timer> OnTimerStarted;

    public float StartTime => startTime;
    public float TimerLeft => timeLeft;

    public void StartTimer()
    {
        StopTimer();
        timeLeft = startTime;
        timerRoutine = StartCoroutine(RunTimer());
    }

    public void StopTimer()
    {
        if (timerRoutine == null)
            return;

        StopCoroutine(timerRoutine);
        timerRoutine = null;
        OnTimerStopped?.Invoke(this);
    }

    private IEnumerator RunTimer()
    {


        OnTimerStarted?.Invoke(this);
        while (timeLeft > 0)
        {
            yield return null;
            SetTimeLeft(timeLeft - Time.deltaTime);
        }
        OnTimerStopped?.Invoke(this);
        OnTimerFinished?.Invoke(this);
    } 

    private void SetTimeLeft(float timeLeft)
    {
        this.timeLeft = Math.Max(0, timeLeft);
        OnTimerUpdated?.Invoke(this);
    }
}
