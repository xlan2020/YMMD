using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonHoverUnderline : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private Text buttonText;    // 手动指定的 Text 组件
    [SerializeField] private Image underlineImage; // 用作下划线的 Image 预制体
    [SerializeField] private float underlineHeight = 2f; // 下划线的高度
    [SerializeField] private float underlineOffset = 2f; // 下划线与文字之间的距离偏移

    void Start()
    {
        if (underlineImage != null)
        {
            underlineImage.enabled = false; // 初始状态下隐藏下划线
        }
        else
        {
            Debug.LogWarning("请手动分配下划线的 Image 组件！");
        }
    }

    // 当鼠标悬停时
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (buttonText != null && underlineImage != null)
        {
            UpdateUnderlinePositionAndWidth(); // 更新下划线的位置和宽度
            underlineImage.enabled = true;     // 显示下划线
        }
    }

    // 当鼠标离开时
    public void OnPointerExit(PointerEventData eventData)
    {
        if (underlineImage != null)
        {
            underlineImage.enabled = false;    // 隐藏下划线
        }
    }

    // 根据文本内容调整下划线的宽度和位置
    private void UpdateUnderlinePositionAndWidth()
    {

        // 获取文本框的宽度
        float textWidth = 0;

        if (buttonText.preferredWidth > buttonText.rectTransform.rect.width)
        {
            textWidth = buttonText.rectTransform.rect.width;

        }
        else
        {
            textWidth = buttonText.preferredWidth;
        }

        // 设置下划线的宽度为文本框的宽度
        RectTransform underlineRect = underlineImage.rectTransform;
        underlineRect.sizeDelta = new Vector2(textWidth, underlineHeight);

        // 确保下划线锚点与文本一致
        underlineRect.anchorMin = new Vector2(0, 0);  // 左下对齐
        underlineRect.anchorMax = new Vector2(0, 0);  // 左下对齐
        underlineRect.pivot = new Vector2(0, 0);      // 锚点在左下角

        // 计算下划线的位置：使其贴在文本框的底部，并根据 offset 调整
        float yOffset = -underlineOffset; // 保证下划线在文本框底部紧贴
        underlineRect.anchoredPosition = new Vector2(0, yOffset);
    }
}
