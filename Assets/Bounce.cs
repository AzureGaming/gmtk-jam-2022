using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounce : MonoBehaviour
{
    float speed = 0f;

    private void Start()
    {
        Vector3 startPos = transform.localPosition;
        startPos.y = 1f;
        transform.localPosition = startPos;
    }

    private void Update()
    {
        if (transform.localPosition.y > 0) // apply gravity if midair
        {
            speed -= 0.000005f;
        }

        // add speed to altitude
        Vector3 newPos = transform.localPosition;
        newPos.y += speed;
        transform.localPosition = newPos;

        if (transform.localPosition.y < 0) // if hit ground
        {
            // simulate bounce
            Vector3 reversedPos = transform.localPosition;
            reversedPos.y = -reversedPos.y;
            transform.localPosition = reversedPos;

            if (speed < 0)
            {
                // if falling down, reduce speed
                speed = -speed * 0.8f - 0.0008f;
            }

            //if (speed < 1) // if speed is below threshold, snap to ground
            //{
            //    Vector3 landingPos = transform.localPosition;
            //    landingPos.y = 0f;
            //    transform.localPosition = landingPos;
            //    speed = 0f;
            //    Debug.Log("LAND");
            //}
        }
    }
}
