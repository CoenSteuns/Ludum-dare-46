using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Timer))]
public class DragMeUI : MonoBehaviour
{
    [SerializeField]
    private GameObject graphicobject;

    [SerializeField]
    private DrawPath drawPath;

    private Timer timer;

    private void Awake() {
        timer = GetComponent<Timer>();
        graphicobject.SetActive(false);
        drawPath.OnIsDrawingChange += UpdateDrawing;
        timer.OnTimerFinished += (t) => graphicobject.SetActive(true);

        UpdateDrawing(false);
    }

    private void UpdateDrawing(bool isDrawing)
    {
        if (isDrawing == false)
        {
            timer.StartTimer();

        } 
        else
        {
            graphicobject.SetActive(false);
            timer.StopTimer();
        }
    }


}
