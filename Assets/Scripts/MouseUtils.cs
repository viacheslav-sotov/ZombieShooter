// by Viacheslav Sotov
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseUtils : MonoBehaviour
{
    public static Vector2 GetMousePosition2d()
    {
        return (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
}
