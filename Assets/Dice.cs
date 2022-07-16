using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dice : MonoBehaviour
{
    [SerializeField] SetText valueDisplay;
    Rigidbody2D rb2d;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        StartCoroutine(RollValue());

        GetComponentInChildren<Bounce>().enabled = true;

        if (GetComponentInChildren<Explode>())
        {
            GetComponentInChildren<Explode>().enabled = true;
        }

        if (GetComponent<DiceTriggerAcid>())
        {
            GetComponent<DiceTriggerAcid>().enabled = true;
        }
    }

    IEnumerator RollValue()
    {
        while (rb2d.velocity.magnitude > 0.2f)
        {
            yield return new WaitForSeconds(0.2f);

            float diceValue = Random.Range(1, 20);
            valueDisplay.Set(diceValue.ToString());

            if (GetComponentInChildren<Explode>())
            {
                GetComponentInChildren<Explode>().SetRadius(diceValue);
            }
            if (GetComponent<DiceTriggerAcid>())
            {
                GetComponent<DiceTriggerAcid>().SetRadius(diceValue);
            }
        }
    }
}
