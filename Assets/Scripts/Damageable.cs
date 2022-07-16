using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damageable : MonoBehaviour
{
    public void HandleCollision()
    {
        TakeDamage(10);
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
