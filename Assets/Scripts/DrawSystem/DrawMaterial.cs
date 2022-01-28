using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DrawMaterial : MonoBehaviour
{
    private Button button;
    public DrawMaterialManager manager;

    private void Awake()
    {
        button = gameObject.GetComponent<Button>();
        // once it's selected, it can't be selected anymore
        button.onClick.AddListener(delegate { manager.SetMaterialsInteractive(false); });
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public Button GetButton()
    {
        return button;
    }

    public void SetButtonInteractive(bool b)
    {
        button.interactable = b;

    }

}
