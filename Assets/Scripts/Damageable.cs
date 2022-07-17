using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damageable : MonoBehaviour
{
    [SerializeField] AudioSource hurt;
    [SerializeField] AudioSource death;

    public void TakeDamage(int damage)
    {
        gameObject.GetComponent<Health>().health -= damage;
        if (gameObject.GetComponent<Health>().health <= 0)
        {
            if (death != null)
            {
                AudioSource.PlayClipAtPoint(death.clip, transform.position);
            }
            Destroy(gameObject);
        }
        else
        {
            if (hurt != null)
            {
                hurt.Play();
            }
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
