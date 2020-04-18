using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawPath : MonoBehaviour {

    [SerializeField]
    private MouseRaycaster raycaster;

    [SerializeField]
    private float minimumChangeSize = 0.03f;

    private Vector3? lastPoint = null;

    private List<Vector3> path = new List<Vector3>();

    public event Action<List<Vector3>> OnPathChanged;
    public event Action<List<Vector3>> OnPathFinished;

    private void Update() {
        RaycastHit hit;

        if (Input.GetMouseButtonDown(0))
            path.Clear();

        if (Input.GetMouseButton(0) && raycaster.SendRay(out hit)) {

            if (lastPoint != null && Vector3.Distance((Vector3) lastPoint, hit.point) < minimumChangeSize)
                return;

            path.Add(hit.point);
            lastPoint = hit.point;
            OnPathChanged?.Invoke(path);
        } else if (Input.GetMouseButtonUp(0)) {
            lastPoint = null;
            OnPathFinished?.Invoke(path);
        }
    }

}