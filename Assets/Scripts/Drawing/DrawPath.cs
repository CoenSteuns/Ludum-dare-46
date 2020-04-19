using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawPath : MonoBehaviour {

    private const string FINISH_TAG = "DrawObstacle";

    [SerializeField]
    private MouseRaycaster raycaster;

    [SerializeField]
    private float minimumChangeSize = 0.03f;

    [SerializeField]
    private MouseOverCheck startPosition;

    [SerializeField]
    private float maxPathLength = 5;
    private float currentPathLength = 0;

    private Vector3? lastPoint = null;

    private List<Vector3> path = new List<Vector3>();

    public event Action<List<Vector3>> OnPathChanged;
    public event Action<List<Vector3>> OnPathFinished;

    public event Action<bool> OnIsDrawingChange;

    public List<Vector3> Path => path;
    public bool AllowDraw { get; set; } = true;
    public bool IsDrawing { get; private set; } = false;

    private void Update() {
        RaycastHit hit;
        if (Input.GetMouseButtonDown(0) && AllowDraw && (startPosition == null || startPosition.MouseOver) && !IsDrawing)
        {
            IsDrawing = true;
            OnIsDrawingChange?.Invoke(IsDrawing);
            ResetPath();
        }

        if (AllowDraw && Input.GetMouseButton(0) && raycaster.SendRay(out hit) && currentPathLength < maxPathLength) {

            if (lastPoint != null && Vector3.Distance((Vector3) lastPoint, hit.point) < minimumChangeSize) //Moved enough && not first point
                return;

            if (!IsDrawing && startPosition != null && !startPosition.MouseOver) // check for start position
                return;

            if (hit.collider.CompareTag(FINISH_TAG)) {
                IsDrawing = false;
                OnIsDrawingChange?.Invoke(IsDrawing);
                lastPoint = null;
                OnPathFinished?.Invoke(path);
                return;
            }

            path.Add(hit.point);

            if (lastPoint != null)
                currentPathLength += Vector3.Distance((Vector3)lastPoint, hit.point);//TODO fix over max path length

            lastPoint = hit.point;
            OnPathChanged?.Invoke(path);
        } else if ((Input.GetMouseButtonUp(0) || currentPathLength >= maxPathLength) && IsDrawing) {
            IsDrawing = false;
            OnIsDrawingChange?.Invoke(IsDrawing);
            lastPoint = null;
            OnPathFinished?.Invoke(path);
        }
    }

    public void ResetPath() {
        currentPathLength = 0;
        path.Clear();
        OnPathChanged?.Invoke(path);
    }

}