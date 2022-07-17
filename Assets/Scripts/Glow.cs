using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Glow : MonoBehaviour
{
    [SerializeField] SpriteRenderer spriteR;
    float origAlpha;
    float timer = 1.5f;
    float time = 0f;
    bool toggle = false;

    private void Start()
    {
        origAlpha = spriteR.color.a;
    }

    private void Update()
    {
        time += Time.deltaTime;
        if (time >= timer)
        {
            time = 0f;
            toggle = !toggle;
        }
        if (!toggle)
        {
            FadeOut();
        } else
        {
            FadeIn();
        }
    }

    void FadeIn()
    {
        float newAlpha = Mathf.Lerp(0f, origAlpha, (time / timer));
        Color newColor = spriteR.color;
        newColor.a = newAlpha;
        spriteR.color = newColor;
    }
     
    void FadeOut()
    {
        float newAlpha = Mathf.Lerp(origAlpha, 0f, (time / timer));
        Color newColor = spriteR.color;
        newColor.a = newAlpha;
        spriteR.color = newColor;
    }
}
