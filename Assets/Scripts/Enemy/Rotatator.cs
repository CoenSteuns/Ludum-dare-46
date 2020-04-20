using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotatator : MonoBehaviour
{

    [SerializeField]
    private List<RotationTime> routines = new List<RotationTime>();

    [SerializeField]
    private bool startOnAwake = true;

    [SerializeField]
    private float rotationSpeed = 8;

    [ContextMenu("Add current rotation")]
    public void AddCurrentTotation()
    {
        print(transform.localRotation.eulerAngles);
        routines.Add(new RotationTime(1, transform.localRotation.eulerAngles));
    }

    private void Awake()
    {
        if (startOnAwake)
            StartCoroutine(LoopFullRoutine());
    }

    private IEnumerator LoopFullRoutine()
    {
        while (true)
        {
            yield return StartCoroutine(PlayFullRoutine());
        }
    }

    private IEnumerator PlayFullRoutine()
    {
        for (int i = 0; i < routines.Count; i++)
        {
            yield return StartCoroutine(PlayroutinePart(routines[i]));
        }
    }

    private IEnumerator PlayroutinePart(RotationTime routinePart)
    {
        float elapsedTime = 0;
        Coroutine rotRoutine = StartCoroutine(RotateTo(routinePart.QuaternionRotation));
        while (elapsedTime < routinePart.Time)
        {
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        if (rotRoutine != null)
            StopCoroutine(rotRoutine);
    }

    private IEnumerator RotateTo(Quaternion rotation)
    {
        while (Quaternion.Angle(transform.localRotation, rotation) > 1)
        {
            transform.localRotation = Quaternion.Lerp(transform.localRotation, rotation, rotationSpeed * Time.deltaTime);
            yield return null;
        }
    }


    [System.Serializable]
    private class RotationTime
    {
        [SerializeField]
        private Vector3 rotation;
        [SerializeField]
        private float time;

        public RotationTime(float time, Vector3 rotation)
        {
            this.time = time;
            this.rotation = rotation;
        }

        public Quaternion QuaternionRotation => Quaternion.Euler(rotation);
        public float Time => time;
        public Vector3 Rotation => rotation;
    }

}
