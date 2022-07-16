using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseCursor : MonoBehaviour
{
    [SerializeField] Sprite[] sprites;
    Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        ThrowDetector.OnMouseDown += () => SetMouseDown(true);
        ThrowDetector.OnMouseUp += () => SetMouseDown(false);
    }

    private void OnDisable()
    {
        ThrowDetector.OnMouseDown -= () => SetMouseDown(true);
        ThrowDetector.OnMouseUp -= () => SetMouseDown(false);
    }

    private void Start()
    {
        Cursor.visible = false;
    }

    private void Update()
    {
        UpdatePosition();
        UpdateSprite();
    }

    void SetMouseDown(bool val)
    {
        anim.SetBool("IsMouseDown", val);
    }

    void UpdateSprite()
    {
        switch (DiceManager.type)
        {
            case DiceManager.DiceType.Explosive:
                anim.SetBool("IsExplosive", true);
                anim.SetBool("IsAcid", false);
                anim.SetBool("IsFreezing", false);
                break;
            case DiceManager.DiceType.Acid:
                anim.SetBool("IsExplosive", false);
                anim.SetBool("IsAcid", true);
                anim.SetBool("IsFreezing", false);
                break;
            case DiceManager.DiceType.Freezing:
                anim.SetBool("IsExplosive", false);
                anim.SetBool("IsAcid", false);
                anim.SetBool("IsFreezing", true);
                break;
            default:
                anim.SetBool("IsExplosive", false);
                anim.SetBool("IsAcid", false);
                anim.SetBool("IsFreezing", false);
                break;
        }
    }

    void UpdatePosition()
    {
        Vector2 cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = cursorPos;
    }
}
