using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawPath : MonoBehaviour
{

    [SerializeField]
    private MouseRaycaster raycaster;

    private List<Vector3> path = new List<Vector3>();

    public event Action<List<Vector3>> OnPathChanged;

    private void Update()
    {
        RaycastHit hit;
        if (Input.GetMouseButton(0) && raycaster.SendRay(out hit))
        {
            path.Add(hit.point);
            OnPathChanged?.Invoke(path);
        }
        else if (Input.GetMouseButtonUp(0))
        {
            path.Clear();
            OnPathChanged?.Invoke(path);
        }
    }

}
