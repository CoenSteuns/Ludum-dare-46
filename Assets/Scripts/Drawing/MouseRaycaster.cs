using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class MouseRaycaster : MonoBehaviour
{


    [SerializeField]
    private LayerMask mask = -1;

    [SerializeField]
    private float maxDistance = Mathf.Infinity;

    private Camera camera;

    private void Awake()
    {
        camera = GetComponent<Camera>();
    }

    public bool SendRay(out RaycastHit hit)
    {
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);
        bool t = Physics.Raycast(ray, out hit, maxDistance, mask);
        return t;
    
    }

}
