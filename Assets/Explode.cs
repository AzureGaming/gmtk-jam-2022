using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explode : MonoBehaviour
{
    [SerializeField] GameObject debugPrefab;
    Rigidbody2D rb2d;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (rb2d.velocity.x < 0.1f)
        {
            Debug();
        }
    }

    void Debug()
    {
        Instantiate(debugPrefab);
    }
}
