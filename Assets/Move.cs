using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    Rigidbody2D rb2d;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Vector3 newPos = transform.position;
        newPos.y -= 0.001f;

        rb2d.MovePosition(newPos);
    }
}
