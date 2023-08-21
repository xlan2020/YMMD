using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawItemObject : MonoBehaviour
{
    private Item item;
    private SpriteRenderer spriteRenderer;
    private DragDrop dragDrop;
    private bool _atDestination = false;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        this.dragDrop = GetComponent<DragDrop>();
        //dragDrop.onDropEvent += DrawItemObject_OnDrop;
    }

    void Start()
    {
        this.dragDrop.dropCallback = OnDrop;
    }

    public void SetItem(Item newItem)
    {
        item = newItem;
        if (item != null)
        {
            spriteRenderer.sprite = item.spriteImage;
            //UnityEngine.Debug.Log("setting draw item object spri");
        }
        else
        {
            spriteRenderer.sprite = null;
            //UnityEngine.Debug.Log("setting draw item object sprite to null");
        }
    }

    public Item GetItem()
    {
        return item;
    }

    private void OnDrop(DragDrop dragDrop)
    {
        if (!_atDestination)
        {
            dragDrop.Snap();
        }
    }

    public void SetAtDestination(bool b)
    {
        _atDestination = b;
    }

    public void ResetSelf()
    {
        dragDrop.Snap();
    }
}
