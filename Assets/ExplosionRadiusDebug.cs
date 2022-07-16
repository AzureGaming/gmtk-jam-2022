using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionRadiusDebug : MonoBehaviour
{
    float timer = 0.25f;
    float radius;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        if (radius != default)
        {
            Gizmos.DrawWireSphere(transform.position, radius);
        }
    }

    private void Update()
    {
        if (timer <= 0f)
        {
            Destroy(gameObject);
        }
        timer -= Time.deltaTime;
    }

    public void SetRadius(float val)
    {
        radius = val;
    }
}
