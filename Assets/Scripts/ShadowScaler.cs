using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowScaler : MonoBehaviour
{
    [SerializeField] Transform originalObject;

    private void Update()
    {
        UpdateScale(originalObject.localPosition.y);
    }

    public void UpdateScale(float zValue)
    {
        transform.localScale = new Vector2(GetScale(zValue), GetScale(zValue));
    }

    float GetScale(float z)
    {
        return -0.75f * z + 1;
    }
}
