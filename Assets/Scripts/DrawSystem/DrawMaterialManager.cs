using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawMaterialManager : MonoBehaviour
{

    public DrawMaterial[] materials;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public DrawMaterial[] getMaterials()
    {
        return materials;
    }

    public void SetMaterialsInteractive(bool b)
    {
        foreach (DrawMaterial m in materials)
        {
            m.SetButtonInteractive(b);
        }
    }

}
