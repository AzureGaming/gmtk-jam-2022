using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Acidable : MonoBehaviour
{
    [SerializeField] Moveable moveable;
    bool acidApplied = false;
    float acidDamageTimer = 0f;

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
