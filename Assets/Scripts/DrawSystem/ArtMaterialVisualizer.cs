using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArtMaterialVisualizer : MonoBehaviour
{
    [SerializeField] SpriteRenderer canvasObject;
    [SerializeField] MouseCursor cursor;
    private GameObject paintObject;

    public void ApplyItemAsArtMaterial(Item item)
    {
        switch (item.drawType)
        {
            case DrawType.canvas:
                ChangeCanvasSprite(item.artMaterial.canvasSprite);
                break;
            case DrawType.brush:
                ChangeBrushSprite(item.artMaterial.brushSprite);
                if (item.artMaterial.brushWithPaint)
                {
                    ChangePaint(item.artMaterial.paintPrefab);
                }
                break;
            case DrawType.paint:
                ChangePaint(item.artMaterial.paintPrefab);
                break;
            default:
                UnityEngine.Debug.LogWarning("item can't be used as art material because type doesn't apply!");
                break;
        }
    }
    void ChangeCanvasSprite(Sprite sprite)
    {
        canvasObject.sprite = sprite;
        canvasObject.GetComponent<Animator>().SetBool("isUp", true);
    }

    void ChangeBrushSprite(Sprite sprite)
    {
        cursor.SetBrushSprite(sprite);
    }

    void ChangePaint(GameObject paintPrefab)
    {
        if (paintObject != null)
        {
            Destroy(paintObject);
        }
        paintObject = Instantiate(paintPrefab, cursor.gameObject.transform);

    }
}
