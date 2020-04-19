using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    [SerializeField]
    private float speed;

    private void Update()
    {

        Vector3 movement = new Vector3(
            Input.GetAxis("Horizontal"), 
            0,
            Input.GetAxis("Vertical")
        );

        transform.position += movement * speed * Time.deltaTime;

    }

}
