using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceTriggerFreeze : DiceTrigger
{
    float radiusValue;
    float radius;

    [SerializeField] GameObject debugPrefab;
    [SerializeField] GameObject indicatorPrefab;
    Rigidbody2D rb2d;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (rb2d.velocity.magnitude < 0.9f)
        {
            radius = radiusValue * 0.1f;
            Freeze(radius);
            int level = 1;
            if (radiusValue > 15)
            {
                level = 3;
            }
            else if (radiusValue > 5 && radiusValue <= 15)
            {
                level = 2;
            }
            Complete(level, radiusValue);
            Destroy(gameObject);
        }
    }

    public void SetRadius(float val)
    {
        radiusValue = val;
    }

    void Freeze(float radius)
    {
        GameObject indicator = Instantiate(indicatorPrefab, transform.position, Quaternion.identity);
        indicator.transform.localScale = new Vector2(radius, radius) * 1.15f;
    }
}
