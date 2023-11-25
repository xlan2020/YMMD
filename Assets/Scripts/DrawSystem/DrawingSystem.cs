using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DrawingSystem : MonoBehaviour
{
    [Header("UI Objects")]
    [SerializeField] InkDialogueManager dialogueManager;
    [SerializeField] UIDraw_Inventory uIDraw_Inventory;
    [SerializeField] ArtMaterialVisualizer artMaterialVisualizer;
    [SerializeField] StartDrawingVisualizer startDrawingVisualizer;
    [SerializeField] DrawResultVisualizer drawResultVisualizer;
    [SerializeField] SubmitDrawing drawingSubmitter;
    [SerializeField] ObserveeManager observeeManager;
    [SerializeField] Scrollbar binaryValDisplay;

    [Header("Client and Game")]
    [SerializeField] GameManager gameManager;
    public ClientSpecialScriptableObject clientSpecial;
    // threshold: 0-100 rate how ____ something is; for the case of 8-2, that's the trust

    private Item canvas;
    private Item brush;
    private Item paint;

    private int binaryVal = 0;


    void Start()
    {
        uIDraw_Inventory.ShowSelf(false);
        uIDraw_Inventory.ShowApplyButton(false);
        startDrawingVisualizer.ShowSelf(false);
        drawResultVisualizer.ShowSelf(false);
        binaryValDisplay.value = binaryVal * 0.01f;
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

    public void ShowMaterialSelectionWindow()
    {
        uIDraw_Inventory.ShowSelf(true);
        uIDraw_Inventory.SetDrawTypeFilter(FilterType.all);
        artMaterialVisualizer.InitializeMaterialSelection();

    }
    public void StartMaterialSelection()
    {
        uIDraw_Inventory.ShowSelf(true);
        artMaterialVisualizer.InitializeMaterialSelection();
        uIDraw_Inventory.ShowApplyButton(true);
        startDrawingVisualizer.ShowSelf(true);
    }
    public void StartDrawing()
    {
        // check durability, might remove item from inventory
        checkDurability();

        // set can continue
        dialogueManager.SetCanContinueToNextLine(true);
        dialogueManager.ContinueStory();

        // update ui
        uIDraw_Inventory.ShowSelf(false);
        startDrawingVisualizer.ShowSelf(false);

    }

    private void checkDurability()
    {
        canvas.durability--;
        brush.durability--;
        paint.durability--;

        if (canvas.durability <= 0)
        {
            UnityEngine.Debug.Log("durability is zero, delete item: " + canvas.itemName);
            gameManager.RemoveItem(canvas);
        }
        if (brush.durability <= 0)
        {
            UnityEngine.Debug.Log("durability is zero, delete item: " + brush.itemName);
            gameManager.RemoveItem(brush);
            if (brush.drawType == DrawType.brushPaint)
            {
                // no need to check paint, is already deleted
                return;
            }
        }
        if (paint.durability <= 0)
        {
            UnityEngine.Debug.Log("durability is zero, delete item: " + paint.itemName);
            gameManager.RemoveItem(paint);
        }
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

    public void HandleObserveeChoices()
    {
        drawingSubmitter.SetCanSubmit(true);
        observeeManager.UpdateCollectedObserveeWhenCanSubmit();
    }

    public void SubmitToDrawing(Observee obsv)
    {
        // make choice in dialogue
        dialogueManager.MakeChoice(obsv.choiceIndex);
    }

    public void ShowDrawResult()
    {
        // decide result
        ResultDrawingScriptableObject resDraw = CalculateResultDrawing();

        // set window active
        drawResultVisualizer.ShowSelf(true);

        // update res draw info
        drawResultVisualizer.DisplayResultDrawingInfo(resDraw);

        // update res draw visuals
        drawResultVisualizer.DisplayResultDrawingVisuals(resDraw);

        // set material icons
        drawResultVisualizer.mat1.sprite = canvas.spriteImage;
        drawResultVisualizer.mat2.sprite = brush.spriteImage;
        drawResultVisualizer.mat3.sprite = paint.spriteImage;

        // theme score is alreay displayed as part of the draw res info
        // calculate total score: total_score = mat_score + theme_score
        float total_score = CalculateAndDisplayMatScore() + resDraw.themeScore;
        drawResultVisualizer.DisplayTotalScore(total_score);

        // multiply reputation - part of the player stats
        // put 1 here for now
        float reputation = 1f;

        // calculate gain
        drawResultVisualizer.SetTargetGain(total_score * reputation);
        // visualizer will add to actual money to GM once the graphic display is done



    }

    private ResultDrawingScriptableObject CalculateResultDrawing()
    {
        if (binaryVal < clientSpecial.resultStandard[1])
        {
            return clientSpecial.resultDrawings[0];
        }
        else if (binaryVal < clientSpecial.resultStandard[2])
        {
            return clientSpecial.resultDrawings[1];
        }
        else
        {
            return clientSpecial.resultDrawings[2];
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

    private float CalculateAndDisplayMatScore()
    {
        int expr_raw = canvas.draw_experimental + brush.draw_experimental + paint.draw_experimental;
        int orgn_raw = canvas.draw_organic + brush.draw_organic + paint.draw_organic;
        int prem_raw = canvas.draw_premium + brush.draw_premium + paint.draw_premium;
        drawResultVisualizer.DisplayMatVals(expr_raw, orgn_raw, prem_raw);
        UnityEngine.Debug.Log("prem 3 vals: " + canvas.draw_premium + "," + brush.draw_premium + "," + paint.draw_premium);
        UnityEngine.Debug.Log("prem_raw: " + prem_raw);

        int expr_mul = TranslateToMultiplier(clientSpecial.experimental_attitude);
        int orgn_mul = TranslateToMultiplier(clientSpecial.organic_attitude);
        int prem_mul = TranslateToMultiplier(clientSpecial.premium_attitude);
        drawResultVisualizer.DisplayMatPrefMultiplier(expr_mul, orgn_mul, prem_mul);

        int sum = expr_raw * expr_mul + orgn_raw * orgn_mul + prem_raw * prem_mul;
        drawResultVisualizer.DisplayMatSum(sum);

        // calculate stability
        float stability_mul = CalculateStabilityMultiplier(canvas.draw_stable + brush.draw_stable + paint.draw_stable);
        drawResultVisualizer.DisplayMatStabilityMultiplier(stability_mul);

        // calculate material result score
        float mat_score = sum * stability_mul;
        drawResultVisualizer.DisplayMatResult(mat_score);

        return mat_score;

    }

    private float CalculateStabilityMultiplier(int sum)
    {
        if (sum >= DrawSystemConstant.STABILITY_GOOD_LIMIT)
        {
            return 2f;
        }
        else if (sum >= DrawSystemConstant.STABILITY_NORM_LIMIT)
        {
            return 1f;
        }
        else
        {
            return 0.5f;
        }
    }

    private int TranslateToMultiplier(PreferenceAttitude attd)
    {
        if (attd == PreferenceAttitude.preferred)
        {
            return 3;
        }
        else if (attd == PreferenceAttitude.disliked)
        {
            return -1;
        }
        return 1;
    }

    private void addBinaryVal(int num)
    {
        binaryVal += num;
        UnityEngine.Debug.Log("binary val changed! now is: " + binaryVal);
        binaryValDisplay.value = binaryVal * 0.01f;
        UnityEngine.Debug.Log("binary val display value is: " + binaryValDisplay.value);
    }

    public int GetBinaryVal()
    {
        return binaryVal;
    }

    public void HandleInkDialogueTagValue(string tagValue)
    {

        string[] splitTag = tagValue.Split("_");

        switch (splitTag[0])
        {
            case "showMaterialWindow":
                ShowMaterialSelectionWindow();
                break;
            case "selectMaterial":
                StartMaterialSelection();
                dialogueManager.SetCanContinueToNextLine(false);
                break;
            case "showDrawResult":
                ShowDrawResult();
                break;
            case "addBinaryVal":
                addBinaryVal(int.Parse(splitTag[1]));
                break;
            default:
                UnityEngine.Debug.LogWarning("try to handle drawing system tag but tag '" + tagValue + "' doesn't exist!");
                break;
        }
    }
}
