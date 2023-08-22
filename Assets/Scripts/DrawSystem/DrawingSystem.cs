using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawingSystem : MonoBehaviour
{
    [SerializeField] InkDialogueManager dialogueManager;
    [SerializeField] UIDraw_Inventory uIDraw_Inventory;
    [SerializeField] ArtMaterialVisualizer artMaterialVisualizer;
    [SerializeField] StartDrawingVisualizer startDrawingVisualizer;
    private Item canvas;
    private Item brush;
    private Item paint;

    public Sprite[] drawingResults;

    void Start()
    {
        uIDraw_Inventory.ShowSelf(false);
        startDrawingVisualizer.ShowSelf(false);
    }

    public void SetDrawItem(Item item)
    {
        //UnityEngine.Debug.Log("drawing system apply material: " + item.itemName);
        switch (item.drawType)
        {
            case DrawType.notDraw:
                UnityEngine.Debug.LogWarning("item type 0 is not draw item. Can't use it for drawing!");
                break;
            case DrawType.canvas:
                canvas = item;
                artMaterialVisualizer.ApplyItemAsArtMaterial(item);
                break;
            case DrawType.brush:
                if (brush != null && brush.drawType == DrawType.brushPaint)
                {
                    paint = null;
                    artMaterialVisualizer.WithdrawArtMaterialByType(DrawType.paint);
                }
                brush = item;
                artMaterialVisualizer.ApplyItemAsArtMaterial(item);
                break;
            case DrawType.paint:
                if (paint != null && paint.drawType == DrawType.brushPaint)
                {
                    brush = null;
                    artMaterialVisualizer.WithdrawArtMaterialByType(DrawType.brush);
                }
                paint = item;
                artMaterialVisualizer.ApplyItemAsArtMaterial(item);
                break;
            case DrawType.brushPaint:
                brush = item;
                paint = item;
                artMaterialVisualizer.ApplyItemAsArtMaterial(item);
                break;
            default:
                break;
        }

        startDrawingVisualizer.SetIconDone(DrawType.canvas, canvas != null);
        startDrawingVisualizer.SetIconDone(DrawType.brush, brush != null);
        startDrawingVisualizer.SetIconDone(DrawType.paint, paint != null);

        // check if material selection is complete
        if (canvas != null && brush != null && paint != null)
        {
            startDrawingVisualizer.ShowStartDrawingButton(true);
        }
        else
        {
            startDrawingVisualizer.ShowStartDrawingButton(false);
        }
    }

    private bool TypeHasAppliedItem(DrawType type)
    {
        switch (type)
        {
            case DrawType.canvas:
                return canvas != null;
            case DrawType.brush:
                return brush != null;
            case DrawType.paint:
                return paint != null;
            case DrawType.brushPaint:
                return (brush != null && paint != null);
            default:
                return false;
        }
    }
    public void StartMaterialSelection()
    {
        uIDraw_Inventory.ShowSelf(true);
        artMaterialVisualizer.InitializeMaterialSelection();
        startDrawingVisualizer.ShowSelf(true);
    }
    public void StartDrawing()
    {
        // check durability, might remove item from inventory



        // set can continue
        dialogueManager.SetCanContinueToNextLine(true);
        dialogueManager.ContinueStory();

        // update ui
        uIDraw_Inventory.ShowSelf(false);
        startDrawingVisualizer.ShowSelf(false);

    }
    public Item GetItemByDrawType(DrawType drawType)
    {
        switch (drawType)
        {
            case DrawType.canvas:
                return canvas;
            case DrawType.brush:
                return brush;
            case DrawType.paint:
                return paint;
            case DrawType.brushPaint:
                return brush;
            default:
                return null;
        }
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
