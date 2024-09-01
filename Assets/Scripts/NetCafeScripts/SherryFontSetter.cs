using UnityEngine;
using UnityEngine.UI;

public class SherryFontSetter : MonoBehaviour
{
    public Font targetFont; // 目标字体，用于UI的Text组件

    void Start()
    {
        if (targetFont != null)
        {
            // 遍历场景中的所有根对象
            foreach (GameObject rootGameObject in UnityEngine.SceneManagement.SceneManager.GetActiveScene().GetRootGameObjects())
            {
                // 对每个根对象递归调用SetFontRecursively方法
                SetFontRecursively(rootGameObject);
            }
        }
        else
        {
            Debug.LogWarning("请在Inspector中设置目标字体！");
        }
    }

    // 递归方法，用于设置Text组件的字体
    void SetFontRecursively(GameObject obj)
    {
        // 查找当前对象上的Text组件
        Text uiText = obj.GetComponent<Text>();
        if (uiText != null)
        {
            uiText.font = targetFont;
        }

        // 递归处理子对象
        foreach (Transform child in obj.transform)
        {
            SetFontRecursively(child.gameObject);
        }
    }
}