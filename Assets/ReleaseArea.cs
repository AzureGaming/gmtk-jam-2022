using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReleaseArea : MonoBehaviour
{
    public static bool isValid = false;
    private void OnMouseEnter()
    {
        Debug.Log("Release valid");
        isValid = true;
    }

    private void OnMouseExit()
    {
        Debug.Log("Release invalid");
        isValid = false;
    }
}
