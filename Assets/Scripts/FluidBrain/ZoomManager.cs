using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomManager : MonoBehaviour
{
    private int currZoomIndex = 0;
    public ZoomObject[] Left;
    public ZoomObject[] Right;


    public void ZoomTo(int index)
    {
        currZoomIndex = index;
        SetViewActive(index);
    }

    public int GetCurrZoomIndex()
    {
        return currZoomIndex;
    }
    private void SetViewActive(int index)
    {

    }
}
