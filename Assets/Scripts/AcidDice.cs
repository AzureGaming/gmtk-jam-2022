using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcidDice : MonoBehaviour
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
        Debug.Log("Velocity" + rb2d.velocity.magnitude);
        if (rb2d.velocity.magnitude <= 0.2)
        {
            float radius = 0.1f * diceValue;
            Explode(radius);
        }
        //if (initialSpeed != null && rb2d.velocity != targetSpeed)
        //{
        //    rb2d.velocity = Vector3.Lerp(initialSpeed, targetSpeed, (currentTime / targetTime));
        //    currentTime += Time.deltaTime;
        //}
    }
    public void SlowDown()
    {
        initialSpeed = rb2d.velocity;
        currentTime = 0;
        targetTime = initialSpeed.magnitude;
        Debug.Log($"initial speed {initialSpeed}. Target time: {targetTime}");
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
