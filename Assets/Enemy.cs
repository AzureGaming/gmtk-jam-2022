using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public delegate void Score();
    public static Score OnScore;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("DamageZone")) {
            OnScore?.Invoke();
            Destroy(gameObject);
        }
    }
}
