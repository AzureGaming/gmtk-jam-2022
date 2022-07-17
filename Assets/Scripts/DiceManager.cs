using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceManager : MonoBehaviour
{
    public enum DiceType
    {
        Explosive,
        Acid,
        Freezing,
        None
    }
    public static DiceType type;

    private void Start()
    {
        SelectDiceType();
    }

    private void OnEnable()
    {
        ThrowDetector.OnMouseUp += ClearDiceType;
        DiceTrigger.OnResolve += SelectDiceType;
    }

    private void OnDisable()
    {
        ThrowDetector.OnMouseUp -= ClearDiceType;
        DiceTrigger.OnResolve -= SelectDiceType;
    }

    public void SelectDiceType()
    {
        //type = (DiceType)Random.Range(0, 3);
        type = DiceType.Explosive;
    }

    public void ClearDiceType()
    {
        type = DiceType.None;
    }
}
