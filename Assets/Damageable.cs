using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damageable : MonoBehaviour
{
    bool acidApplied = false;
    float acidDamageTimer = 0f;

    public void HandleCollision()
    {
        TakeDamage(10);
    }

    private void Update()
    {
        if (acidApplied)
        {
            if (acidDamageTimer < 0f)
            {
                TakeDamage(5);
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
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Acid") && acidApplied)
        {
            acidApplied = false;
        }
    }

    void TakeDamage(int damage)
    {
        gameObject.GetComponent<Health>().health -= damage;
        if (gameObject.GetComponent<Health>().health <= 0)
        {
            Destroy(gameObject);
        }
        else
        {
            StartCoroutine(FlashRed());
        }
    }

    IEnumerator FlashRed()
    {
        SpriteRenderer spriteR = GetComponent<SpriteRenderer>();
        Color origColor = spriteR.color;
        spriteR.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        spriteR.color = origColor;
        yield return new WaitForSeconds(0.1f);
        spriteR.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        spriteR.color = origColor;
    }
}
