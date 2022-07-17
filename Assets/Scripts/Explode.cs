using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explode : DiceTrigger
{
    float radiusValue;
    float radius;

    [SerializeField] GameObject debugPrefab;
    [SerializeField] GameObject explosionPrefab;
    Rigidbody2D rb2d;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (rb2d.velocity.magnitude < 0.9f)
        {
            radius = radiusValue * 0.1f;
            CheckCollisions(radius);
            Debug2();
            int level = 1;
            if (radiusValue > 15)
            {
                level = 3;
            } else if (radiusValue > 5 && radiusValue <= 15)
            {
                level = 2;
            }
            Complete(level);
            Destroy(gameObject);
        }
    }

    public void SetRadius(float val)
    {
        radiusValue = val;
    }

    void CheckCollisions(float radius)
    {
        Collider2D[] collisions = Physics2D.OverlapCircleAll(transform.position, radius);
        foreach (Collider2D collision in collisions)
        {
            if (collision.GetComponent<Damageable>())
            {
                collision.GetComponent<Damageable>().TakeDamage(10);
            }
        }
    }

    void Debug2()
    {
        Instantiate(debugPrefab, transform.position, Quaternion.identity).GetComponent<ExplosionRadiusDebug>().SetRadius(radius);
    }
}
