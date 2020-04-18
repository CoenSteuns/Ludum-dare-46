using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawPath : MonoBehaviour {

    [SerializeField]
    private MouseRaycaster raycaster;

    [SerializeField]
    private float minimumChangeSize = 0.03f;

    [SerializeField]
    private MouseOverCheck startPosition;

    private Vector3? lastPoint = null;

    private List<Vector3> path = new List<Vector3>();

    public event Action<List<Vector3>> OnPathChanged;
    public event Action<List<Vector3>> OnPathFinished;

    public bool AllowDraw { get; set; } = true;
    public bool IsDrawing { get; private set; } = false;

    private void Update() {
        RaycastHit hit;
        if (Input.GetMouseButtonDown(0) && AllowDraw && startPosition == null || startPosition.MouseOver && !IsDrawing)
            path.Clear();

        if (AllowDraw && Input.GetMouseButton(0) && raycaster.SendRay(out hit)) {

            if (lastPoint != null && Vector3.Distance((Vector3) lastPoint, hit.point) < minimumChangeSize) //Moved enough && not first point
                return;

            if (!IsDrawing && startPosition != null && !startPosition.MouseOver) // check for start position
                return;

            IsDrawing = true;
            path.Add(hit.point);
            lastPoint = hit.point;
            OnPathChanged?.Invoke(path);
        } else if (Input.GetMouseButtonUp(0) && IsDrawing) {
            IsDrawing = false;
            lastPoint = null;
            OnPathFinished?.Invoke(path);
        }
    }

}