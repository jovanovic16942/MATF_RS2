using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmptySpace : MonoBehaviour
{
    public static event Action Pressed;

    private void OnMouseDown()
    {
        Pressed?.Invoke();
    }
}
