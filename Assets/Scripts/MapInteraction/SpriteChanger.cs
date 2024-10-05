using UnityEngine;
using UnityEngine.UI;

public class SpriteChanger : MonoBehaviour
{
    // 当前对象的SpriteRenderer
    public SpriteRenderer spriteRenderer;

    // 要切换的两个Sprite
    public Sprite sprite1;
    public Sprite sprite2;

    // 按钮
    public Button changeSpriteButton;

    // 当前显示的Sprite
    private bool isUsingSprite1 = true;

    void Start()
    {
        // 将按钮的点击事件绑定到SwitchSprite方法
        if (changeSpriteButton != null)
        {
            changeSpriteButton.onClick.AddListener(SwitchSprite);
        }

        // 设置初始显示的sprite
        if (spriteRenderer != null)
        {
            spriteRenderer.sprite = sprite1;
        }
    }

    // 切换Sprite的方法
    void SwitchSprite()
    {
        if (spriteRenderer != null)
        {
            if (isUsingSprite1)
            {
                spriteRenderer.sprite = sprite2;
            }
            else
            {
                spriteRenderer.sprite = sprite1;
            }

            isUsingSprite1 = !isUsingSprite1;  // 反转当前的Sprite状态
        }
    }
}
