using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PathMover))]
[RequireComponent(typeof(Timer))]
public class MovementBooster : MonoBehaviour
{

    [SerializeField]
    private float boostMultiplier;

    private PathMover mover;
    private Timer timer;

    private float originalSpeed;

    public bool Isboosting { get; private set; } = false;

    private void Awake()
    {
        mover = GetComponent<PathMover>();
        timer = GetComponent<Timer>();
        timer.OnTimerStopped += (t) => Unboost();
    }

    public void Boost()
    {
        if (Isboosting)
            return;

        timer.StartTimer();
        Isboosting = true;
        originalSpeed = mover.Speed;
        mover.Speed *= boostMultiplier;
        
    }

    public void StopBoosing() {
        timer.StopTimer();
    }

    public void Unboost()
    {
        mover.Speed = originalSpeed;
        Isboosting = false;
    }


}
