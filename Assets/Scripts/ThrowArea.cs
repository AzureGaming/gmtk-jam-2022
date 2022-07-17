using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowArea : MonoBehaviour
{
    public static bool isValid = false;
    private void OnMouseEnter()
    {
        isValid = true;
    }

    private void OnMouseExit()
    {
        isValid = false;
    }
}
