using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterAnimate : MonoBehaviour
{
    [SerializeField] GameObject target;
    public void Destroy()
    {
        if (target != null)
        {
            Destroy(target);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
