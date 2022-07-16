using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceTrigger : MonoBehaviour
{
    public delegate void Resolve();
    public static Resolve OnResolve;
}
