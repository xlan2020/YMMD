using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMenu : MonoBehaviour
{
    public MouseCursor cursor;
    private Button menuButton;
    // Start is called before the first frame update
    void Start()
    {
        menuButton = GetComponent<Button>();

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnMouseEnter()
    {
        cursor.SetAnimationTrigger("point");
    }

    void OnMouseExit()
    {
        cursor.SetAnimationTrigger("default");
    }
}
