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

    private bool pathFinished = false;

    private Vector3? lastPoint = null;

    private List<Vector3> path = new List<Vector3>();

    private bool isDrawing = false;

    public event Action<List<Vector3>> OnPathChanged;
    public event Action<List<Vector3>> OnPathFinished;

    public event Action<bool> OnIsDrawingChange;

    public List<Vector3> Path => path;
    public bool AllowDraw { get; set; } = true;
    public bool IsDrawing
    {
        get { return isDrawing; }
        private set {
            if (isDrawing == value)
                return;

            isDrawing = value;
            OnIsDrawingChange?.Invoke(value);
        }
    }

    public float MaxPathLenth => maxPathLength;
    public float CurrentPathLength => currentPathLength;

    public void ResetPath()
    {
        currentPathLength = 0;
        path.Clear();
        OnPathChanged?.Invoke(path);
    }

    private void Update() {

        if (pathFinished && Input.GetMouseButton(0))
            return;

        pathFinished = false;
        RaycastHit hit;
        bool rayHit = raycaster.SendRay(out hit);
        if (Input.GetMouseButtonDown(0) && AllowDraw && (startPosition == null || startPosition.MouseOver) && !IsDrawing)
        {
            IsDrawing = true;
            ResetPath();
        }

        if (AllowDraw && Input.GetMouseButton(0) && rayHit && currentPathLength < maxPathLength) {

            Vector3 newPathPosition = hit.point;
            if (!IsFirstPoint() && MovedEnough(newPathPosition)) //Moved enough && not first point
                return;

            if (!IsDrawing && ReadyForStart()) // check for start position
                return;

            if (HitObstacle(hit.collider)) {
                FinishPath();
                return;
            }

            newPathPosition = ScalePath(newPathPosition);

            AddPointToPath(newPathPosition);
        } else if ((Input.GetMouseButtonUp(0) || currentPathLength >= maxPathLength) && IsDrawing || IsDrawing && !rayHit) {
            FinishPath();
        }
    }

    private  Vector3 ScalePath(Vector3 newPathPosition)
    {
        if (lastPoint != null)
        {
            float addedPathLength = Vector3.Distance((Vector3)lastPoint, newPathPosition);
            if (currentPathLength + addedPathLength > maxPathLength)
            {
                float overMax = currentPathLength + addedPathLength - maxPathLength;
                float allowedAdd = addedPathLength - overMax;
                Vector3 dir = (newPathPosition - (Vector3)lastPoint).normalized;
                newPathPosition = (Vector3)lastPoint + dir * allowedAdd;
                currentPathLength += allowedAdd;
                return newPathPosition;
            }
            else
            {
                currentPathLength += addedPathLength;
            }
        }
        return newPathPosition;
    }

    private void AddPointToPath(Vector3 newPathPosition)
    {
        
        path.Add(newPathPosition);
        lastPoint = newPathPosition;
        OnPathChanged?.Invoke(path);
    }

    private void FinishPath()
    {
        pathFinished = true;
        IsDrawing = false;
        lastPoint = null;
        OnPathFinished?.Invoke(path);
    }

    private bool MovedEnough(Vector3 newPos)
    {
        return  Vector3.Distance((Vector3)lastPoint, newPos) < minimumChangeSize;
    } 

    private bool IsFirstPoint()
    {
        return lastPoint == null;
    }

    private bool ReadyForStart()
    {
        return startPosition != null && !startPosition.MouseOver;
    }

    private bool HitObstacle(Collider hit)
    {
        return hit.CompareTag(FINISH_TAG);
    }

}