using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceManager : MonoBehaviour
{
    public enum DiceType
    {
        Explosive,
        Acid,
        Freezing
    }
    public static DiceType type;

    private void Start()
    {
        SelectDiceType();
    }

    public void SelectDiceType()
    {
        //type = (DiceType)Random.Range(0, 2);
        type = DiceType.Explosive;
    }
}
