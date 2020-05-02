using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PathMover : MonoBehaviour {

    [SerializeField]
    private Animator animator;

    [SerializeField]
    private CombatPlayer combatPlayer;

    [SerializeField]
    private float speed = 0.05f;
    private Coroutine walkRoutine;

    public Vector3[] Path { get; private set; }

    public bool ignoreX = false;
    public bool ignoreY = false;
    public bool ignoreZ = false;

    public event Action OnStartedWalking;
    public event Action OnStoppedWalking;

    public float Speed { get => speed; set => speed = value; } 

    public void SetPath(Vector3[] path) {
        StopWalking();
        Path = path;
    }

    public void WalkPath(Vector3[] path) {
        if (path.Length == 0)
            return;
        SetPath(path);
        StartWalking();
    }

    public void StartWalking() {
        combatPlayer.OnBattleStart += StopWalking;
        walkRoutine = StartCoroutine(WalkPathRoutine(Path));
    }

    public void StopWalking() {
        if (walkRoutine == null)
            return;

        animator.SetBool("isWalking", false);
        OnStoppedWalking?.Invoke();
        StopCoroutine(walkRoutine);
        walkRoutine = null;
    }

    public IEnumerator WalkPathRoutine(Vector3[] path) {

        if (path.Length > 0)
        {
            path[0] = transform.position;

            float walkedPath = 0;
            int currentPart = 0;

            if (path.Length == 0)
                yield break;

            OnStartedWalking?.Invoke();
            animator.SetBool("isWalking", true);

            while (true)
            {

                float restPath;
                currentPart = FindCurrentPart(path, walkedPath, out restPath, currentPart);

                if (restPath < 0)
                {
                    SetPosition(path[currentPart]);
                    break;
                }

                Vector3 dir = (path[currentPart + 1] - path[currentPart]).normalized;
                SetPosition(path[currentPart] + dir * restPath);

                walkedPath += speed * Time.deltaTime;
                yield return null;
            }
            animator.SetBool("isWalking", false);
            OnStoppedWalking?.Invoke();
        }
    }

    private int FindCurrentPart(Vector3[] path, float walkedPath, out float restPathLeft, int startIndex = 0) {
        restPathLeft = walkedPath;
        for (int i = 1; i < Path.Length; i++) {
            float partDistance = Vector3.Distance(Path[i - 1], Path[i]);

            if (walkedPath - partDistance < 0)
                return (i - 1);

            walkedPath -= partDistance;
            restPathLeft = walkedPath;
        }
        restPathLeft = -1;
        return Path.Length - 1;
    }

    private void SetPosition(Vector3 newPosition) {
        newPosition.x = ignoreX ? transform.position.x : newPosition.x;
        newPosition.y = ignoreY ? transform.position.y : newPosition.y;
        newPosition.z = ignoreZ ? transform.position.z : newPosition.z;
        transform.position = newPosition;
    }

}