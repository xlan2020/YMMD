using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragDrop : MonoBehaviour
{
    private Vector3 mOffset;
    private bool _onDrag = false;
    private bool _onDrop = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnMouseDown()
    {
        _onDrag = true;
        _onDrop = false;
        // UnityEngine.Debug.Log("Drag!");
        mOffset = gameObject.transform.position - GetMouseAsWorldPoint();
    }

    private Vector3 GetMouseAsWorldPoint()
    {
        // Pixel coordinates of mouse (x,y)
        Vector3 mousePoint = Input.mousePosition;
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }

    void OnMouseDrag()
    {
        transform.position = GetMouseAsWorldPoint() + mOffset;
    }

    void OnMouseUp()
    {
        if (_onDrag)
        {
            _onDrag = false;
            _onDrop = true;
            // UnityEngine.Debug.Log("Drop!");
        }
    }

    public bool IsOnDrop()
    {
        return _onDrop;
    }

    public bool IsOnDrag()
    {
        return _onDrag;
    }
}
