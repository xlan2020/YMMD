using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseCursor : MonoBehaviour
{
    [SerializeField] private CursorSpritesScriptableObject cursorSprites;
    public static MouseCursor instance { get; private set; }
    //private Animator animator;
    private SpriteRenderer spriteRenderer;
    private bool _inGameMode = true;
    private bool _inFluidBrain = false;
    public Camera positionReferenceCamera; // has to be a camera that's overlay / doesn't move

    Sprite brush;
    Sprite dialogue;
    Sprite point;
    Sprite hand;
    Sprite grab;
    Sprite observe;
    Sprite arrow;
    Sprite talk;

    private Sprite prevSprite;

    void Awake()
    {
        Cursor.visible = false;
        // animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        // animator.SetBool("inGame", true);


        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        brush = cursorSprites.brush;
        dialogue = cursorSprites.dialogue;
        point = cursorSprites.point;
        hand = cursorSprites.hand;
        grab = cursorSprites.grab;
        observe = cursorSprites.observe;
        arrow = cursorSprites.arrow;
        talk = cursorSprites.talk;
    }

    void Update()
    {
        if (positionReferenceCamera == null)
        {
            positionReferenceCamera = GameObject.Find("UICameraOverlay").GetComponent<Camera>();
        }
        Vector2 cursorPos = positionReferenceCamera.ScreenToWorldPoint(Input.mousePosition);
        transform.position = cursorPos;
    }

    public void SetAnimationTrigger(string triggerName)
    {
        switch (triggerName)
        {
            case "default":
                SetAnimationDefault();
                break;
            case "point":
                spriteRenderer.sprite = point;
                break;
            case "hand":
                spriteRenderer.sprite = hand;
                break;
            case "observe":
                spriteRenderer.sprite = observe;
                break;
            case "dialogue":
                spriteRenderer.sprite = dialogue;
                break;
            case "arrow":
                spriteRenderer.sprite = arrow;
                break;
            case "talk":
                spriteRenderer.sprite = talk;
                break;
            default:
                break;
        }

    }
    public void SetAnimationBool(string boolName, bool b)
    {
        if (boolName == "grab")
        {
            if (b == true)
            {
                prevSprite = spriteRenderer.sprite;
                spriteRenderer.sprite = grab;
            }
            else if (prevSprite != null)
            {
                spriteRenderer.sprite = prevSprite;
                prevSprite = null;
            }
        }
    }

    public bool InGameMode()
    {
        return _inGameMode;
    }

    public void SetInGameMode(bool b)
    {
        _inGameMode = b;
    }

    public void SetAnimationDefault()
    {
        //animator.SetBool("grab", false);
        if (!_inGameMode)
        {
            spriteRenderer.sprite = arrow;
            return;
        }

        if (_inFluidBrain)
        {
            spriteRenderer.sprite = observe;
            return;
        }

        spriteRenderer.sprite = brush;
    }

    public void SetInFluidBrain(bool b)
    {
        _inFluidBrain = b;
        spriteRenderer.sprite = observe;
    }

    public void SetBrushSprite(Sprite sprite)
    {
        brush = sprite;
        cursorSprites.brush = sprite;
        spriteRenderer.sprite = sprite;
    }
}
