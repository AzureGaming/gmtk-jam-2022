using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowDetector : MonoBehaviour
{
    public delegate void MouseDown();
    public static MouseDown OnMouseDown;
    public delegate void MouseUp();
    public static MouseUp OnMouseUp;

    Vector3 oldMousePos;
    Vector3 screenPoint;
    Vector3 offset;
    Vector3 mouseSpeed;
    bool isMouseDown = false;

    GameObject prefabRef;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && !isMouseDown)
        {
            StartThrow();
        }
        else if (Input.GetMouseButtonUp(0) && isMouseDown)
        {
                Release();
        }
        else if (isMouseDown)
        {
            //MoveDiePrefab();
        }
    }

    private void StartThrow()
    {
        isMouseDown = true;
        OnMouseDown?.Invoke();

        oldMousePos = Input.mousePosition;
        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
    }

    private void MoveDiePrefab()
    {
        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) - offset;
        prefabRef.transform.position = Camera.main.ScreenToWorldPoint(curScreenPoint);
    }

    private void Release()
    {
        isMouseDown = false;
        OnMouseUp?.Invoke();

        mouseSpeed = (oldMousePos - Input.mousePosition);
        screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);

        Vector3 targetPos = Camera.main.ScreenToWorldPoint(curScreenPoint);

        //prefabRef = Instantiate(FindObjectOfType<DiceManager>().GetRandomDiePrefab(), targetPos, Quaternion.identity);
        //prefabRef.GetComponent<Rigidbody2D>().AddForce(mouseSpeed * 0.08f * -1, ForceMode2D.Impulse);

        //prefabRef.GetComponentInChildren<Dice>().enabled = true;
        //prefabRef = null;
    }
}
