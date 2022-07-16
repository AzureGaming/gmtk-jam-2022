using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceTrigger : MonoBehaviour
{
    public delegate void Resolve();
    public static Resolve OnResolve;
    [SerializeField] AudioSource resolveSound;

    protected void Complete()
    {
        OnResolve?.Invoke();
        AudioSource.PlayClipAtPoint(resolveSound.clip, transform.position);
    }
}
