using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArtMaterialVisualizer : MonoBehaviour
{
    [SerializeField] Image canvasObject;
    [SerializeField] MouseCursor cursor;
    [SerializeField] CursorSpritesScriptableObject cursorSprites;
    private GameObject paintObject;

    public void ApplyItemAsArtMaterial(Item item)
    {
        //UnityEngine.Debug.Log("visualizer apply material: " + item.itemName);
        switch (item.drawType)
        {
            case DrawType.canvas:
                ChangeCanvasSprite(item.artMaterial.canvasSprite);
                break;
            case DrawType.brush:
                ChangeBrushSprite(item.artMaterial.brushSprite);
                break;
            case DrawType.brushPaint:
                ChangeBrushSprite(item.artMaterial.brushSprite);
                ChangePaint(item.artMaterial.paintPrefab);
                break;
            case DrawType.paint:
                ChangePaint(item.artMaterial.paintPrefab);
                break;
            default:
                UnityEngine.Debug.LogWarning("item can't be used as art material because type doesn't apply!");
                break;
        }
    }
    public void WithdrawArtMaterialByType(DrawType drawType)
    {
        switch (drawType)
        {
            case DrawType.canvas:
                canvasObject.GetComponent<Animator>().SetBool("isUp", false);
                break;
            case DrawType.brush:
                cursor.SetBrushSprite(cursorSprites.hand);
                break;
            case DrawType.paint:
                if (paintObject != null)
                {
                    Destroy(paintObject);
                }
                break;
            default:
                break;

        }
    }

    public void InitializeMaterialSelection()
    {
        cursor.SetBrushSprite(cursorSprites.hand);
    }
    void ChangeCanvasSprite(Sprite sprite)
    {
        if (sprite == null)
        {
            UnityEngine.Debug.LogWarning("Draw Type is wrong, or development not done! ");
            showDevNotDoneSign();
            return;
        }
        canvasObject.sprite = sprite;
        canvasObject.GetComponent<Animator>().SetBool("isUp", true);
    }

    void ChangeBrushSprite(Sprite sprite)
    {
        if (sprite == null)
        {
            UnityEngine.Debug.LogWarning("Draw Type is wrong, or development not done! ");
            showDevNotDoneSign();
            return;
        }
        cursor.SetBrushSprite(sprite);
    }

    void ChangePaint(GameObject paintPrefab)
    {
        if (paintObject != null)
        {
            Destroy(paintObject);
        }
        if (paintPrefab == null)
        {
            UnityEngine.Debug.LogWarning("Draw Type is wrong, or development not done! ");
            showDevNotDoneSign();
            return;
        }
        paintObject = Instantiate(paintPrefab, cursor.gameObject.transform);

    }
    public void ChangeCursorBrushDefault()
    {
        cursor.SetBrushSprite(cursorSprites.defaultBrush);
    }
    private void showDevNotDoneSign()
    {
        DrawingSystem drawingSystem = this.GetComponent<DrawingSystem>();
        if (drawingSystem == null)
        {
            return;
        }
        GameObject sign = drawingSystem.GetDrawInventory().devNotDoneSign;
        sign.SetActive(true);
    }
}
