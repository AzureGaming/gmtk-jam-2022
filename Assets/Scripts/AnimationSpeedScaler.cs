using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationSpeedScaler : MonoBehaviour
{
    [SerializeField] Rigidbody2D originalObject;
    Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        UpdateSpeed(originalObject.velocity.x);
    }

    void UpdateSpeed(float horizontalVelocity)
    {
        anim.SetFloat("Speed Multiplier", horizontalVelocity);
    }
}
