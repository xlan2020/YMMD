using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignBrush : MonoBehaviour
{
    public Camera myCamera;
    public GameObject brush;

    LineRenderer currentLineRenderer;
    Vector2 lastPos;
    public LoadingScene loadingScene;
    public string nextSceneId;
    public bool canSign = false;
    private bool signing = false;

    void Update()
    {
        Draw();
    }
    void Draw()
    {
        if (signing && canSign && Input.GetKeyUp(KeyCode.Mouse0)){
            // 没出边，松手了
            loadingScene.LoadScene(nextSceneId);
            return;
        }

        if (signing && !canSign){
            // 出边了，不管松没松手，也算签完了
            loadingScene.LoadScene(nextSceneId);
            return;
        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            // check if mouse is in place
            if (canSign){
                CreateBrush();
                signing = true;
            }
        } 
        if (signing && Input.GetKey(KeyCode.Mouse0))
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
