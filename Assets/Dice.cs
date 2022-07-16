using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dice : MonoBehaviour
{
    [SerializeField] SetText valueDisplay;
    [SerializeField] GameObject explosionRadiusDebug;
    Rigidbody2D rb2d;
    CircleCollider2D collider;
    Vector3 initialSpeed;
    Vector2 targetSpeed = Vector2.zero;
    float currentTime = 0;
    float targetTime;
    float diceValue;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        collider = GetComponent<CircleCollider2D>();
    }

    private void Start()
    {
        diceValue = Random.Range(1, 20);
        valueDisplay.Set(diceValue.ToString());
    }

    private void Update()
    {
        //Debug.Log("Velocity" + rb2d.velocity.magnitude);
        //if (rb2d.velocity.magnitude <= 0.2)
        //{
        //    float radius = 0.1f * diceValue;
        //    CheckCollisions(radius);
        //    //Explode(radius);
        //}
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

    void Explode(float radius)
    {
        Instantiate(explosionRadiusDebug, transform.position, Quaternion.identity).GetComponent<ExplosionRadiusDebug>().SetRadius(radius);
        Destroy(gameObject);
    }
}
