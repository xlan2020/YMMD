using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawBrush : MonoBehaviour
{
    public Camera myCamera;
    public GameObject brush;

    LineRenderer currentLineRenderer;
    Vector2 lastPos;


    void Update()
    {
        Draw();
    }
    void Draw()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            CreateBrush();
        }
        if (Input.GetKey(KeyCode.Mouse1))
        {
            Vector2 mousePos = myCamera.ScreenToWorldPoint(Input.mousePosition);
            if (mousePos != lastPos)
            {
                AddPoint(mousePos);
                lastPos = mousePos;
            }
        }
        else
        {
            currentLineRenderer = null;
        }
    }

    void CreateBrush()
    {
        GameObject brushInstance = Instantiate(brush);
        currentLineRenderer = brushInstance.GetComponent<LineRenderer>();

        Vector2 mousePos = myCamera.ScreenToWorldPoint(Input.mousePosition);

        currentLineRenderer.SetPosition(0, mousePos);
        currentLineRenderer.SetPosition(1, mousePos);
    }

    void AddPoint(Vector2 pointPos)
    {
        currentLineRenderer.positionCount++;
        int positionIndex = currentLineRenderer.positionCount - 1;
        currentLineRenderer.SetPosition(positionIndex, pointPos);
    }
}
