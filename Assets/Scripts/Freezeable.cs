using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Freezeable : MonoBehaviour
{
    [SerializeField] Moveable moveable;
    [SerializeField] SpriteRenderer spriteR;
    [SerializeField] GameObject freezeObj;
    public float timer = 4f;
    float startSpeed;
    Color startColor;
    bool isFrozen = false;

    private void Start()
    {
        startSpeed = moveable.speed;
        startColor = spriteR.color;
        freezeObj.SetActive(false);
    }

    private void Update()
    {
        if (isFrozen)
        {
            timer -= Time.deltaTime;
        }

        if (timer < 0f)
        {
            UnFreeze();
        }
    }

    public void Freeze()
    {
        isFrozen = true;
        freezeObj.SetActive(true);
        moveable.speed = 0f;
        spriteR.color = Color.blue;
    }

    void UnFreeze()
    {
        isFrozen = false;
        freezeObj.SetActive(false);
        moveable.speed = startSpeed;
        spriteR.color = startColor;
    }
}
