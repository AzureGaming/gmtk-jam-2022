using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceValueSprite : MonoBehaviour
{
    public SpriteRenderer spriteR;
    [SerializeField] Sprite[] nums;

    public void SetNum(float num)
    {
        if (num - 1 < nums.Length && num - 1 >= 0)
        {
            spriteR.sprite = nums[(int)num - 1];
        }
    }
}
