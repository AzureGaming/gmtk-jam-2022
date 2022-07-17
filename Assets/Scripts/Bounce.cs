using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounce : MonoBehaviour
{
    public bool isBuild = false;
    BounceAudio audio;
    float speed = 0f;

    private void Awake()
    {
        audio = GetComponent<BounceAudio>();
    }

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
            if (isBuild)
            {
                speed -= 0.001f;
            }
            else
            {
                speed -= 0.00001f;
            }
        }

        // add speed to altitude
        Vector3 newPos = transform.localPosition;
        newPos.y += speed;
        transform.localPosition = newPos;

        if (transform.localPosition.y <= 0) // if hit ground
        {
            // simulate bounce
            Vector3 reversedPos = transform.localPosition;
            reversedPos.y = -reversedPos.y;
            transform.localPosition = reversedPos;

            if (speed < -0.0006f) // stop playing audio when bounce is too small
            {
                audio.Play();
            }

            if (speed < 0)
            {
                // if falling down, reduce speed
                if (isBuild)
                {
                    speed = -speed * 0.8f - 0.001f;

                }
                else
                {
                    speed = -speed * 0.8f - 0.0008f;
                }
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
