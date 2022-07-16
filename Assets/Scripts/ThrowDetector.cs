using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowDetector : MonoBehaviour
{
    Vector3 oldMousePos;
    Vector3 screenPoint;
    Vector3 offset;
    Vector3 mouseSpeed;
    bool isMouseDown = false;

    [SerializeField] GameObject prefab;
    GameObject prefabRef;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && !isMouseDown)
        {
            OnMouseDown();
        }
        else if (Input.GetMouseButtonUp(0) && isMouseDown)
        {
            OnMouseUp();
        }
        else if (isMouseDown)
        {
            OnMouseDrag();
        }
    }

    private void OnMouseDown()
    {
        isMouseDown = true;
        oldMousePos = Input.mousePosition;
        screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
        prefabRef = Instantiate(prefab, screenPoint, Quaternion.identity);
    }

    private void OnMouseDrag()
    {
        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) - offset;
        prefabRef.transform.position = Camera.main.ScreenToWorldPoint(curScreenPoint);
    }

    private void OnMouseUp()
    {
        isMouseDown = false;
        mouseSpeed = (oldMousePos - Input.mousePosition);
        prefabRef.GetComponent<Rigidbody2D>().AddForce(mouseSpeed * 0.08f * -1, ForceMode2D.Impulse);
        prefabRef.GetComponentInChildren<Bounce>().enabled = true;
    }
}
