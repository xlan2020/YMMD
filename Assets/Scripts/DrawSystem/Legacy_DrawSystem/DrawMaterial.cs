using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DrawMaterial : MonoBehaviour
{
    // private Button button;
    public DrawMaterialManager manager;
    private int choiceIndex;
    private DragDrop dragDrop;
    private Animator animator;
    private bool _submitted = false;

    public UnityEngine.Color StartDissolveColor;

    private void Awake()
    {
        // button = gameObject.GetComponent<Button>();
        // once it's selected, it can't be selected anymore
        // button.onClick.AddListener(delegate { manager.SetMaterialsInteractive(false); });
        dragDrop = gameObject.AddComponent<DragDrop>();
        animator = GetComponent<Animator>();

    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetInteractive(bool b)
    {
        dragDrop.enabled = b;
    }

    public int GetChoiceIndex()
    {
        return choiceIndex;
    }

    public void SetChoiceIndex(int i)
    {
        choiceIndex = i;
    }

    public void SubmitSelf()
    {
        // UnityEngine.Debug.Log("choice index is: " + this.GetChoiceIndex());
        // animator.SetTrigger("Submit");
        _submitted = true;
        this.SetInteractive(false);
        manager.ClearUnusedMaterials();
    }



    public bool Submitted()
    {
        return _submitted;
    }

    private void OnMouseEnter()
    {
        manager.SetCursorTrigger("hand");
    }
    private void OnMouseDown()
    {
        manager.SetCursorBool("grab", true);
    }

    private void OnMouseUp()
    {
        manager.SetCursorBool("grab", false);
    }

    private void OnMouseExit()
    {
        manager.SetCursorTrigger("default");
    }
}
