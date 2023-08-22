using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartDrawingVisualizer : MonoBehaviour
{
    [SerializeField] private Image canvasIcon;
    [SerializeField] private Image brushIcon;
    [SerializeField] private Image paintIcon;
    [SerializeField] private Button startDrawingButton;

    void Start()
    {
        canvasIcon.color = Color.black;
        brushIcon.color = Color.black;
        paintIcon.color = Color.black;
        startDrawingButton.interactable = false;

    }

    public void ShowSelf(bool b)
    {
        gameObject.SetActive(b);
    }
    public void SetIconDone(DrawType type, bool b)
    {
        switch (type)
        {
            case DrawType.canvas:
                setIconToStateColor(canvasIcon, b);
                break;
            case DrawType.brush:
                setIconToStateColor(brushIcon, b);
                break;
            case DrawType.paint:
                setIconToStateColor(paintIcon, b);
                break;
            case DrawType.brushPaint:
                setIconToStateColor(brushIcon, b);
                setIconToStateColor(paintIcon, b);
                break;
            default:
                break;
        }
    }

    public void ShowStartDrawingButton(bool b)
    {
        startDrawingButton.interactable = b;
    }
    private void setIconToStateColor(Image iconImage, bool doneState)
    {
        if (doneState == true)
        {
            iconImage.color = Color.white;
        }
        else
        {
            iconImage.color = Color.black;
        }
    }
}
