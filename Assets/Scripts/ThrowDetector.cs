using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowDetector : MonoBehaviour
{
    public delegate void MouseDown();
    public static MouseDown OnMouseDown;
    public delegate void MouseUp(bool throwing);
    public static MouseUp OnMouseUp;

    Vector3 oldMousePos;
    Vector3 screenPoint;
    Vector3 offset;
    Vector3 mouseSpeed;
    bool isMouseDown = false;

    [SerializeField] GameObject[] dicePrefabs;
    GameObject loadedPrefab;
    GameObject prefabRef;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && !isMouseDown && DiceManager.type != DiceManager.DiceType.None)
        {
            StartThrow();
        }
        else if (Input.GetMouseButtonUp(0) && isMouseDown)
        {
            Release();
        }
    }

    private void StartThrow()
    {
        isMouseDown = true;
        OnMouseDown?.Invoke();
        LoadDiePrefab();

        oldMousePos = Input.mousePosition;
        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
    }

    private void Release()
    {
        isMouseDown = false;

        mouseSpeed = (oldMousePos - Input.mousePosition);
        Debug.Log(mouseSpeed.magnitude);
        if (mouseSpeed.magnitude == 0f)
        {
            OnMouseUp?.Invoke(false);
        }
        else
        {
            OnMouseUp?.Invoke(true);
            screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
            Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);

            Vector3 targetPos = Camera.main.ScreenToWorldPoint(curScreenPoint);
            prefabRef = Instantiate(loadedPrefab, targetPos, Quaternion.identity);
            prefabRef.GetComponent<Rigidbody2D>().AddForce(mouseSpeed * 0.08f * -1, ForceMode2D.Impulse);

            prefabRef.GetComponentInChildren<Dice>().enabled = true;
            prefabRef = null;
        }
    }

    void LoadDiePrefab()
    {
        switch (DiceManager.type)
        {
            case DiceManager.DiceType.Explosive:
                loadedPrefab = dicePrefabs[0];
                break;
            case DiceManager.DiceType.Acid:
                loadedPrefab = dicePrefabs[1];
                break;
            case DiceManager.DiceType.Freezing:
                loadedPrefab = dicePrefabs[2];
                break;
            default:
                loadedPrefab = null;
                break;
        }
    }
}
