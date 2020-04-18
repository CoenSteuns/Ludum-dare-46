using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseOverCheck : MonoBehaviour {

    public bool MouseOver { get; private set; }

    void OnMouseOver() {
        MouseOver = true;
    }

    void OnMouseExit() {
        MouseOver = false;
    }
}