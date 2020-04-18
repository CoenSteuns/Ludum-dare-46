using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkUIManager : MonoBehaviour {
    [SerializeField]
    private DrawPath path;

    [SerializeField]
    private PathMover movement;

    private void Awake() {
        movement.OnStoppedWalking += () => path.AllowDraw = true;
        movement.OnStoppedWalking += ResetPath;
        movement.OnStartedWalking += () => path.AllowDraw = false;
    }

    public void Walk() {
        movement.WalkPath(path.Path.ToArray());
    }

    public void ResetPath() {
        path.ResetPath();
    }

}