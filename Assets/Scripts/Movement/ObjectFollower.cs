using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectFollower : MonoBehaviour
{
    [SerializeField]
    private Transform target;

    [SerializeField]
    private float speed = 5;

    [SerializeField]
    private bool ignoreX, ignoreY, ignoreZ;

    private void Update()
    {
        var targetposition = target.position;
        targetposition = RemoveIgnoredAxis(targetposition);
        MoveToTarget(targetposition);
    }

    private Vector3 RemoveIgnoredAxis(Vector3 target)
    {
        var myPosition = transform.position; 
        target.x = ignoreX ? myPosition.x : target.x;
        target.y = ignoreY ? myPosition.y : target.y;
        target.z = ignoreZ ? myPosition.z : target.z;
        return target;
    }

    private void MoveToTarget(Vector3 target)
    {
        var newPosition = Vector3.Lerp(transform.position, target, speed * Time.fixedDeltaTime);
        transform.position = newPosition;
    }

}
