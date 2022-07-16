using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explode : DiceTrigger
{
    float radiusValue;
    float radius;

    [SerializeField] GameObject debugPrefab;
    Rigidbody2D rb2d;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (rb2d.velocity.magnitude < 0.1f)
        {
            radius = radiusValue * 0.1f;
            CheckCollisions(radius);
            OnResolve?.Invoke();
            Debug2();
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
                collision.GetComponent<Damageable>().HandleCollision();
            }
        }
    }

    void Debug2()
    {
        Instantiate(debugPrefab, transform.position, Quaternion.identity).GetComponent<ExplosionRadiusDebug>().SetRadius(radius);
    }
}
