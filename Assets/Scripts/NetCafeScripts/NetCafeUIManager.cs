using UnityEngine;
using UnityEngine.UI;

public class NetCafeUIManager : MonoBehaviour
{
    private NewsDetailScriptableObject[] newsArray;
    private NewsDetailScriptableObject newsHeadline;
    private PostScriptableObject[] postArray;
    private string newsAnnounce;
    private string forumAnnounce;

    [Header("UI Elements")]
    public GameObject netBar;
    public GameObject newsHomePage;
    public GameObject forumHomePage;
    public GameObject newsTitlePrefab;   // 新闻标题按钮预制体
    public GameObject forumTitlePrefab;  // 论坛标题按钮预制体

    // 论坛和新闻的标题容器
    public Transform newsHomeTitles;
    public Transform forumHomeTitles;

    // 新闻和论坛详情页的预制体
    public GameObject newsDetailPagePrefab;
    public GameObject forumDetailPagePrefab;

    public Transform newsDetailPages;
    public Transform forumDetailPages;

    // headline 是一种特殊的新闻页，功能上和其他新闻一样，但在UI上做区分
    public GameObject newsHeadLine;
    //public Transform headlineDetailPage;

    public Text newsBulletin;
    public Text forumBulletin;

    // 导航栏按钮
    public Button newsButton;
    public Button forumButton;
    public Button shutdownButton;

    // 关机弹窗
    public GameObject shutdownPopup;
    public Button shutdownConfirmButton;
    public Button shutdownCancelButton;

    [Header("Font Setter")]
    public SherryFontSetter fontSetter;

    // 设置内容的函数，用于外部传递数据
    public void SetContent(NetCafeContentScriptableObject contentScriptableObject)
    {
        newsArray = contentScriptableObject.newsArray;
        newsHeadline = contentScriptableObject.headline;
        postArray = contentScriptableObject.postArray;
        newsAnnounce = contentScriptableObject.newsAnnounce;
        Debug.Log(newsAnnounce);
        forumAnnounce = contentScriptableObject.forumAnnounce;
    }

    // 初始化 UI 的函数，在传递内容后调用
    public void InitializeUI()
    {
        // 初始化页面加载
        LoadNewsHomePage();
        LoadForumHomePage();

        // 绑定按钮事件
        newsButton.onClick.AddListener(ShowNewsHomePage);
        forumButton.onClick.AddListener(ShowForumHomePage);
        shutdownButton.onClick.AddListener(ShowShutdownPopup);

        shutdownConfirmButton.onClick.AddListener(ConfirmShutdown);
        shutdownCancelButton.onClick.AddListener(HideShutdownPopup);

        // 显示初始页面
        ShowNewsHomePage();
    }

    // 显示新闻首页
    void ShowNewsHomePage()
    {
        newsHomePage.SetActive(true);
        forumHomePage.SetActive(false);
        HideAllDetailPages();

        // 禁用新闻按钮，启用论坛按钮
        newsButton.interactable = false;
        forumButton.interactable = true;
    }

    // 显示论坛首页
    void ShowForumHomePage()
    {
        newsHomePage.SetActive(false);
        forumHomePage.SetActive(true);
        HideAllDetailPages();

        // 禁用论坛按钮，启用新闻按钮
        newsButton.interactable = true;
        forumButton.interactable = false;
    }

    // 隐藏所有详情页
    void HideAllDetailPages()
    {
        // 销毁现有的详情页内容
        foreach (Transform child in newsDetailPages)
        {
            Destroy(child.gameObject); // 销毁现有的内容
        }

        foreach (Transform child in forumDetailPages)
        {
            Destroy(child.gameObject); // 销毁现有的内容
        }
        
        HideShutdownPopup();
    }

    // 显示关机弹窗
    void ShowShutdownPopup()
    {
        shutdownPopup.SetActive(true);
    }

    // 隐藏关机弹窗
    public void HideShutdownPopup()
    {
        shutdownPopup.SetActive(false);
    }

    // 确认关机
    public void ConfirmShutdown()
    {
        //netBar.SetActive(false);
        Destroy(netBar);
    }

    // 加载新闻首页标题
    private void LoadNewsHomePage()
    {
        newsBulletin.text = newsAnnounce + "\n";

        // 清空现有新闻标题按钮
        foreach (Transform child in newsHomeTitles.transform)
        {
            Destroy(child.gameObject);
        }

        // 加载特殊新闻的 Headline
        LoadNewsHeadline(newsHeadline, newsHeadLine);

        // 遍历新闻数组，生成新闻标题按钮
        for (int i = 0; i < newsArray.Length; i++)
        {
            GameObject titleButton = Instantiate(newsTitlePrefab, newsHomeTitles.transform);

            // 显式激活生成的对象
            ActivateButtonAndComponents(titleButton);

            Button buttonComponent = titleButton.GetComponent<Button>();
            Text buttonText = FindText(titleButton, "Title");

            // 设置新闻标题文本
            buttonText.text = newsArray[i].title + "\n";

            // 将点击事件绑定到新闻详情页的显示
            int index = i; // 闭包问题解决
            buttonComponent.onClick.AddListener(() => ShowNewsDetailPage(index));

            // 强制更新布局，确保生成的标题按钮立即生效
            LayoutRebuilder.ForceRebuildLayoutImmediate(newsHomeTitles.GetComponent<RectTransform>());
        }

        // 再次更新整个 Canvas 确保布局完全更新
        Canvas.ForceUpdateCanvases();
    }

    private void LoadForumHomePage()
    {
        forumBulletin.text = forumAnnounce;
        // 清空现有论坛标题按钮
        foreach (Transform child in forumHomeTitles.transform)
        {
            Destroy(child.gameObject);
        }

        // 遍历论坛数组，生成论坛标题按钮
        for (int i = 0; i < postArray.Length; i++)
        {
            GameObject titleButton = Instantiate(forumTitlePrefab, forumHomeTitles.transform);

            // 显式激活生成的对象
            ActivateButtonAndComponents(titleButton);

            Button buttonComponent = titleButton.GetComponent<Button>();
            Text buttonText = FindText(titleButton, "Title");
            Text authorTime = FindText(titleButton, "AuthorTime");


            // 设置论坛标题文本
            buttonText.text = postArray[i].title + "\n";
            authorTime.text = postArray[i].author + " / " + postArray[i].lastEditTime + "\n";

            // 将点击事件绑定到论坛详情页的显示
            int index = i; // 闭包问题解决
            buttonComponent.onClick.AddListener(() => ShowForumDetailPage(index));

            // 强制更新布局
            LayoutRebuilder.ForceRebuildLayoutImmediate(forumHomeTitles.GetComponent<RectTransform>());
        }

        // 再次更新整个 Canvas 确保布局完全更新
        Canvas.ForceUpdateCanvases();
    }

    // 加载新闻 Headline
    private void LoadNewsHeadline(NewsDetailScriptableObject content, GameObject headlinePage)
    {
        Text headlineText = FindText(headlinePage, "HeadlineTitle");
        headlineText.text = content.title + "\n";

        Button headlineButton = headlinePage.GetComponentInChildren<Button>();
        headlineButton.onClick.AddListener(ShowHeadlinePage);

        // 确保所有组件都激活
        ActivateButtonAndComponents(headlinePage);

        // 强制更新布局，确保Headline布局正确
        LayoutRebuilder.ForceRebuildLayoutImmediate(newsHomeTitles.GetComponent<RectTransform>());
        Canvas.ForceUpdateCanvases();
    }

    // 显式激活 `Button`、`Text` 组件及其 `SizeFitter` 和 `LayoutGroup` 组件
    private void ActivateButtonAndComponents(GameObject buttonObj)
    {
        buttonObj.SetActive(true); // 激活按钮对象

        // 激活 Button 的子组件
        Button buttonComponent = buttonObj.GetComponent<Button>();
        if (buttonComponent != null)
        {
            buttonComponent.enabled = true; // 确保按钮激活
        }

        // 激活所有子级 Text 组件
        Text[] textComponents = buttonObj.GetComponentsInChildren<Text>(true);
        if (textComponents != null)
        {
            foreach (Text t in textComponents) {
                t.gameObject.SetActive(true);
                t.enabled = true;
                t.GetComponent<ContentSizeFitter>().enabled = true;
            }
            
        }

        // 激活 SizeFitter 和 LayoutGroup 组件
        ContentSizeFitter sizeFitter = buttonObj.GetComponent<ContentSizeFitter>();
        if (sizeFitter != null)
        {
            sizeFitter.enabled = true;
        }

        LayoutGroup layoutGroup = buttonObj.GetComponent<LayoutGroup>();
        if (layoutGroup != null)
        {
            layoutGroup.enabled = true;
        }
    }

    // 显示新闻详情页
    public void ShowNewsDetailPage(int index)
    {
        HideAllDetailPages();
        GameObject detailPage = Instantiate(newsDetailPagePrefab, newsDetailPages.transform);

        // 显式激活生成的对象 //headlineDetailPage
        detailPage.SetActive(true);

        LoadNewsContent(newsArray[index], detailPage);

        // 设置Back按钮的点击事件
        SetBackButtonFunction(detailPage, ShowNewsHomePage);

        // 应用字体设置到新生成的页面
        if (fontSetter != null)
        {
            fontSetter.SetFontRecursively(detailPage); // 应用字体
        }

        // 强制更新布局，确保详情页显示正确
        LayoutRebuilder.ForceRebuildLayoutImmediate(newsDetailPages.GetComponent<RectTransform>());
        Canvas.ForceUpdateCanvases();
    }

    // 显示 Headline 的详情页
    public void ShowHeadlinePage()
    {
        HideAllDetailPages();
        GameObject detailPage = Instantiate(newsDetailPagePrefab, newsDetailPages.transform);

        // 显式激活生成的对象
        detailPage.SetActive(true);

        LoadNewsContent(newsHeadline, detailPage);

        // 设置Back按钮的点击事件
        SetBackButtonFunction(detailPage, ShowNewsHomePage);

        // 强制更新布局，确保详情页显示正确
        LayoutRebuilder.ForceRebuildLayoutImmediate(newsDetailPages.GetComponent<RectTransform>());
        Canvas.ForceUpdateCanvases();
    }

    // 显示论坛详情页
    public void ShowForumDetailPage(int index)
    {
        HideAllDetailPages();
        GameObject detailPage = Instantiate(forumDetailPagePrefab, forumDetailPages.transform);

        // 显式激活生成的对象
        detailPage.SetActive(true);

        LoadForumContent(postArray[index], detailPage);

        // 设置Back按钮的点击事件
        SetBackButtonFunction(detailPage, ShowForumHomePage);

        // 应用字体设置到新生成的页面
        if (fontSetter != null)
        {
            fontSetter.SetFontRecursively(detailPage); // 应用字体
        }

        // 强制更新布局，确保详情页显示正确
        LayoutRebuilder.ForceRebuildLayoutImmediate(forumDetailPages.GetComponent<RectTransform>());
        Canvas.ForceUpdateCanvases();
    }

    // 设置Back按钮的点击事件
    private void SetBackButtonFunction(GameObject detailPage, UnityEngine.Events.UnityAction backAction)
    {
        Button backButton = detailPage.GetComponentInChildren<Button>(true); // 假设Back按钮已经存在并且有Button组件
        if (backButton != null)
        {
            backButton.onClick.RemoveAllListeners(); // 清除之前的监听器
            backButton.onClick.AddListener(() =>
            {
                Destroy(detailPage); // 销毁当前详情页
                backAction.Invoke(); // 返回到首页
            });
        }
    }

    // 加载新闻内容到详情页
    private void LoadNewsContent(NewsDetailScriptableObject content, GameObject detailPage)
    {
        Text titleText = FindText(detailPage, "NewsTitle");
        Text authorText = FindText(detailPage, "NewsAuthor");
        Text dateText = FindText(detailPage, "NewsTime");
        Text contentText = FindText(detailPage, "NewsText");

        // 设置详情页内容
        titleText.text = content.title + "\n";
        authorText.text = content.author + "\n";
        dateText.text = content.time + "\n";
        contentText.text = content.content + "\n";
    }

    // 加载论坛内容到详情页
    private void LoadForumContent(PostScriptableObject content, GameObject detailPage)
    {
        Text titleText = FindText(detailPage, "Title");
        Text contentText = FindText(detailPage, "PostContent");

        // 设置论坛内容
        titleText.text = content.title + "\n";
        contentText.text = content.content + "\n";
    }

    // 查找指定名称的 Text 组件
    private Text FindText(GameObject detailPage, string name)
    {
        Text[] allTextComponents = detailPage.GetComponentsInChildren<Text>(true);
        foreach (Text textComponent in allTextComponents)
        {
            if (textComponent.gameObject.name == name)
            {
                return textComponent;
            }
        }
        return null;
    }
}
