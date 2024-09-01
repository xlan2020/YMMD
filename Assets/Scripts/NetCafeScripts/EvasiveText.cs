using UnityEngine;
using UnityEngine.UI;

public class EvasiveText : MonoBehaviour
{
    public RectTransform adPanel;      // 广告 Panel 的 RectTransform
    public RectTransform adText;       // 广告 Text 的 RectTransform
    public float safeDistance = 24f;   // 鼠标与 Text 保持的安全距离
    public float hideDistance = 20f;
    public float moveSpeed = 250f;     // Text 移动速度
    public float bounceDistance = 100f; // Text 被逼到边缘时弹开的距离
    public Camera mainCamera;          // 主摄像机，负责渲染 Canvas（World Space 模式下）
    private bool isTextHidden = false; // 记录 Text 是否被隐藏
    private bool mouseIsNear = false;  // 记录鼠标是否接近 Text

    void Start()
    {
        if (mainCamera == null)
        {
            mainCamera = Camera.main;
        }
    }

    void Update()
    {
        // 获取鼠标在屏幕上的位置
        Vector3 mousePosition = Input.mousePosition;

        // 将鼠标位置转换为 Panel 的本地坐标（无论鼠标是否在 Panel 内部）
        Vector2 localMousePosition;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(adPanel, mousePosition, mainCamera, out localMousePosition);

        // 计算广告 Text 到鼠标的距离
        Vector2 directionToMouse = (Vector2)adText.localPosition - localMousePosition;

        // 检测鼠标是否接近
        if (directionToMouse.magnitude < safeDistance)
        {
            mouseIsNear = true;
        }
        else
        {
            mouseIsNear = false;
        }

        // 检查鼠标是否和 Text 重叠
        if (directionToMouse.magnitude < hideDistance)
        {
            HideText();
        }
        else
        {
            ShowText();
        }



        // 如果 Text 被逼到 Panel 边缘，则触发弹开逻辑
        if (IsTextAtEdge())
        {
            // 不考虑鼠标位置直接弹开
            BounceAwayFromEdge();
        }
        else if (mouseIsNear)
        {
            // 正常移动逻辑，当鼠标接近且 Text 没有被逼到边缘时
            Vector2 moveDirection = directionToMouse.normalized;
            adText.localPosition += (Vector3)(moveDirection * moveSpeed * Time.deltaTime);
        }

        // 确保 Text 不会移出 Panel 范围
        adText.localPosition = ClampToPanel(adText.localPosition);
    }

    // 检查 Text 是否在 Panel 的边缘
    private bool IsTextAtEdge()
    {
        Vector2 localPosition = adText.localPosition;

        bool atEdgeX = localPosition.x <= adPanel.rect.xMin + adText.rect.width / 2 || localPosition.x >= adPanel.rect.xMax - adText.rect.width / 2;
        bool atEdgeY = localPosition.y <= adPanel.rect.yMin + adText.rect.height / 2 || localPosition.y >= adPanel.rect.yMax - adText.rect.height / 2;

        return atEdgeX || atEdgeY;
    }

    // 直接从边缘弹开
    private void BounceAwayFromEdge()
    {
        Vector2 bounceDirection = GetBounceDirection(adText.localPosition);
        adText.localPosition += (Vector3)(bounceDirection * bounceDistance * Time.deltaTime);
    }

    // 计算从边缘弹开的方向
    private Vector2 GetBounceDirection(Vector2 textPosition)
    {
        Vector2 direction = Vector2.zero;

        // 根据 Text 的位置选择弹开方向
        if (textPosition.x <= adPanel.rect.xMin + adText.rect.width / 2)
            direction.x = 1;  // 向右弹开
        else if (textPosition.x >= adPanel.rect.xMax - adText.rect.width / 2)
            direction.x = -1; // 向左弹开

        if (textPosition.y <= adPanel.rect.yMin + adText.rect.height / 2)
            direction.y = 1;  // 向上弹开
        else if (textPosition.y >= adPanel.rect.yMax - adText.rect.height / 2)
            direction.y = -1; // 向下弹开

        return direction.normalized;
    }

    // 确保 Text 在 Panel 范围内
    private Vector2 ClampToPanel(Vector2 position)
    {
        position.x = Mathf.Clamp(position.x, adPanel.rect.xMin + adText.rect.width / 2, adPanel.rect.xMax - adText.rect.width / 2);
        position.y = Mathf.Clamp(position.y, adPanel.rect.yMin + adText.rect.height / 2, adPanel.rect.yMax - adText.rect.height / 2);
        return position;
    }

    // 隐藏 Text
    private void HideText()
    {
        if (!isTextHidden)
        {
            adText.GetComponent<CanvasRenderer>().SetAlpha(0f);
            isTextHidden = true;
        }
    }

    // 显示 Text
    private void ShowText()
    {
        if (isTextHidden)
        {
            adText.GetComponent<CanvasRenderer>().SetAlpha(1f);
            isTextHidden = false;
        }
    }
}