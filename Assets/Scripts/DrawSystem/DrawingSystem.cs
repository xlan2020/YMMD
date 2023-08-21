using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawingSystem : MonoBehaviour
{
    private Item canvas;
    private Item brush;
    private Item paint;

    public Sprite[] drawingResults;

    public void SetDrawItem(Item item)
    {
        switch (item.drawType)
        {
            case DrawType.notDraw:
                UnityEngine.Debug.LogWarning("item type 0 is not draw item. Can't use it for drawing!");
                break;
            case DrawType.canvas:
                canvas = item;
                break;
            case DrawType.brush:
                brush = item;
                break;
            case DrawType.paint:
                paint = item;
                break;
            default:
                break;
        }

        // check if material selection is complete
    }


    public Item GetCanvasItem()
    {
        return canvas;
    }
    public Item GetBrushItem()
    {
        return brush;
    }
    public Item GetPaintItem()
    {
        return paint;
    }
}
