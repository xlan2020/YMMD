using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragDrop : MonoBehaviour
{
    public delegate void DropDelegate(DragDrop dd);
    public DropDelegate dropCallback;


    private Vector3 mOffset;
    private SpriteRenderer sprite;
    private bool _onDrag = false;
    private bool _onDrop = false;
    public bool HasFreezeTransform = false;
    public bool FreezeX = false;
    public bool FreezeY = false;
    public bool FreezeZ = false;

    public bool DragAboveMask = false;
    private Vector3 snapPos;


    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        snapPos = transform.position;
    }

    void OnMouseDown()
    {
        // start dragging
        _onDrag = true;
        _onDrop = false;
        // UnityEngine.Debug.Log("Drag!");
        mOffset = gameObject.transform.position - GetMouseAsWorldPoint();

        if (DragAboveMask)
        {
            MoveAboveMask(true);
        }

    }

    private Vector3 GetMouseAsWorldPoint()
    {
        // Pixel coordinates of mouse (x,y)
        Vector3 mousePoint = Input.mousePosition;
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }

    void OnMouseDrag()
    {
        float prevX = transform.position.x;
        float prevY = transform.position.y;
        float prevZ = transform.position.z;


        transform.position = GetMouseAsWorldPoint() + mOffset;

        if (HasFreezeTransform)
        {
            float newX = transform.position.x;
            float newY = transform.position.y;
            float newZ = transform.position.z;

            if (FreezeX)
            {
                newX = prevX;
            }
            if (FreezeY)
            {
                newY = prevY;
            }
            if (FreezeZ)
            {
                newZ = prevZ;
            }

            transform.position = new Vector3(newX, newY, newZ);
        }

        // UnityEngine.Debug.Log("drag transform is: " + mOffset);
    }


    void OnMouseUp()
    {
        if (_onDrag)
        {
            Drop();
        }
    }

    private void Drop()
    {
        _onDrag = false;
        _onDrop = true;
        //UnityEngine.Debug.Log("Drop!");
        dropCallback(this);
    }

    public bool IsOnDrop()
    {
        return _onDrop;
    }

    public bool IsOnDrag()
    {
        return _onDrag;
    }

    private void MoveAboveMask(bool aboveMask)
    {
        if (sprite == null)
        {
            UnityEngine.Debug.Log("drag drop object has no sprite");
            return;
        }
        if (aboveMask)
        {
            sprite.sortingLayerName = "aboveSolvableMask";
        }
        else
        {
            sprite.sortingLayerName = "Solvable";
        }
    }

    public void Snap()
    {
        transform.position = snapPos;
    }

    public void SetSnapPosition(Vector3 nextPos)
    {
        snapPos = nextPos;
    }

    public void SnapBack()
    {
        transform.position = snapPos;
    }
}
