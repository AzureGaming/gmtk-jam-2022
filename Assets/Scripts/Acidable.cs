using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Acidable : MonoBehaviour
{
    [SerializeField] Moveable moveable;
    Damageable damageable;
    bool acidApplied = false;
    float acidDamageTimer = 0f;

    private void Awake()
    {
        damageable = GetComponent<Damageable>();
    }

    private void Update()
    {
        if (acidApplied)
        {
            if (acidDamageTimer < 0f)
            {
                damageable.TakeDamage(5);
                acidDamageTimer = 0.5f;
            }
            acidDamageTimer -= Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Acid"))
        {
            acidApplied = true;
            moveable.speed *= 0.25f;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Acid") && acidApplied)
        {
            acidApplied = false;
            moveable.speed *= 4f;
        }
    }
}
