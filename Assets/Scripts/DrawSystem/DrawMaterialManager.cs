using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawMaterialManager : MonoBehaviour
{

    public DrawMaterial[] materials;
    public MouseCursor cursor;
    // Start is called before the first frame update
    void Start()
    {
        // the choice index is set in the material controller
        for (int i = 0; i < materials.Length; i++)
        {
            materials[i].SetChoiceIndex(i);
        }
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
            m.SetInteractive(b);
        }
    }


    public void ClearUnusedMaterials()
    {
        foreach (DrawMaterial m in materials)
        {
            if (!m.Submitted())
            {
                m.SetInteractive(false);
                m.gameObject.SetActive(false);

            }
        }
    }

    public void SetCursorTrigger(string triggerType)
    {
        cursor.SetAnimationTrigger(triggerType);
    }

    public void SetCursorBool(string name, bool b)
    {
        cursor.SetAnimationBool(name, b);
    }

}
