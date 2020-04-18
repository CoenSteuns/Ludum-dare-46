using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PathMover : MonoBehaviour {

    [SerializeField]
    private float speed = 0.05f;
    private Coroutine walkRoutine;

    public Vector3[] Path { get; private set; }

    public DrawPath path;

    private void Awake() {
        path.OnPathFinished += (path) => WalkPath(path.ToArray());
    }

    public void SetPath(Vector3[] path) {
        StopWalking();
        Path = path;
    }

    public void WalkPath(Vector3[] path) {
        SetPath(path);
        StartWalking();
    }

    public void StartWalking() {
        walkRoutine = StartCoroutine(WalkPathRoutine(Path));
    }

    public void StopWalking() {
        if (walkRoutine == null)
            return;
        StopCoroutine(walkRoutine);
        walkRoutine = null;
    }

    public IEnumerator WalkPathRoutine(Vector3[] path) {

        Vector3[] pathLeft = Path;
        float pathSize = CalculatePathSize();
        float walkedPath = 0;
        int currentPart = 0;

        while (walkedPath < pathSize) {

            float restPath;
            currentPart = FindCurrentPart(path, walkedPath, out restPath, currentPart);

            Vector3 dir = (Path[currentPart + 1] - Path[currentPart]).normalized;
            transform.position = Path[currentPart] + dir * restPath;

            walkedPath += speed;
            yield return null;
        }
    }

    public int FindCurrentPart(Vector3[] path, float walkedPath, out float restPathLeft, int startIndex = 0) {
        restPathLeft = walkedPath;
        for (int i = 1; i < Path.Length; i++) {
            float partDistance = Vector3.Distance(Path[i - 1], Path[i]);

            if (walkedPath - partDistance < 0)
                return (i - 1);

            walkedPath -= partDistance;
            restPathLeft = walkedPath;
        }
        return 0;
    }

    private float CalculatePathSize() {
        float size = 0;
        for (int i = 1; i < Path.Length; i++) {
            size += Vector3.Distance(Path[i - 1], Path[i]);
        }
        return size;
    }

}