using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceTriggerAcid : DiceTrigger
{
    float radiusValue;
    float radius;

    [SerializeField] GameObject acidPrefab;
    [SerializeField] GameObject debugPrefab;
    Rigidbody2D rb2d;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (rb2d.velocity.magnitude < 0.1f)
        {
            radius = radiusValue * 0.1f;
            SpawnAcid(radius);
            OnResolve?.Invoke();
            Destroy(gameObject);
        }
    }

    public void SetRadius(float val)
    {
        radiusValue = val;
    }

    void SpawnAcid(float radius)
    {
        GameObject acid = Instantiate(acidPrefab, transform.position, Quaternion.identity);
        acid.transform.localScale = new Vector2(radius, radius);
    }
}
