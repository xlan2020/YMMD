using UnityEngine;
using UnityEngine.UI;

public class NetCafeUIManager : MonoBehaviour
{
    [Header("Content Loaded")]
    [SerializeField] private NetCafeContentScriptableObject contentScriptableObject;
    private NewsDetailScriptableObject[] newsArray;
    private PostScriptableObject[] postArray;
    private NewsDetailScriptableObject newsheadline;

    [Header("UI Elements")]
    public GameObject netBar;
    public GameObject newsHomePage; // 同时作为新闻标题容器
    public GameObject forumHomePage; // 同时作为论坛标题容器

    public GameObject forumTitlePrefab;
    public GameObject newsTitlePrefab;

    public Transform newsHomeTitles;
    public Transform forumHomeTitles;

    // 论坛和新闻的详情页容器
    public Transform forumDetailPagesContainer;
    public Transform newsDetailPagesContainer;

    // 导航栏按钮
    public Button newsButton;
    public Button forumButton;
    public Button shutdownButton;

    // 关机弹窗
    public GameObject shutdownPopup;
    public Button shutdownConfirmButton;
    public Button shutdownCancelButton;

    // 私有变量：存储动态获取的元素
    private GameObject[] newsDetailPages;
    private GameObject[] forumDetailPages;
    private Button[] forumTitleButtons;
    private Button[] newsTitleButtons;


    void Awake()
    {
        newsArray = contentScriptableObject.newsArray;
        newsheadline = contentScriptableObject.headline;
        postArray = contentScriptableObject.postArray;
    }

    void Start()
    {
        // 动态获取论坛和新闻的标题按钮
        forumTitleButtons = forumHomePage.GetComponentsInChildren<Button>();
        newsTitleButtons = newsHomePage.GetComponentsInChildren<Button>();

        // 动态获取论坛和新闻详情页
        forumDetailPages = new GameObject[forumDetailPagesContainer.childCount];
        for (int i = 0; i < forumDetailPagesContainer.childCount; i++)
        {
            forumDetailPages[i] = forumDetailPagesContainer.GetChild(i).gameObject;
        }

        newsDetailPages = new GameObject[newsDetailPagesContainer.childCount];
        for (int i = 0; i < newsDetailPagesContainer.childCount; i++)
        {
            newsDetailPages[i] = newsDetailPagesContainer.GetChild(i).gameObject;
        }

        // 设置初始状态：显示新闻首页，隐藏其他页面
        ShowNewsHomePage();

        // 设置导航栏按钮的点击事件
        newsButton.onClick.AddListener(ShowNewsHomePage);
        forumButton.onClick.AddListener(ShowForumHomePage);
        shutdownButton.onClick.AddListener(ShowShutdownPopup);

        // 设置论坛标题按钮的点击事件
        for (int i = 0; i < forumTitleButtons.Length; i++)
        {
            int index = i; // 创建局部变量来存储当前索引，防止闭包问题
            forumTitleButtons[i].onClick.AddListener(() => ShowForumDetailPage(index));
        }

        // 设置新闻标题按钮的点击事件
        for (int i = 0; i < newsTitleButtons.Length; i++)
        {
            int index = i; // 同样，创建局部变量来存储当前索引
            newsTitleButtons[i].onClick.AddListener(() => ShowNewsDetailPage(index));
        }

        // 设置论坛详情页返回按钮的点击事件
        foreach (GameObject detailPage in forumDetailPages)
        {
            Button backButton = detailPage.GetComponentInChildren<Button>();
            if (backButton != null)
            {
                backButton.onClick.AddListener(ShowForumHomePage);
            }
        }

        // 设置新闻详情页返回按钮的点击事件
        foreach (GameObject detailPage in newsDetailPages)
        {
            Button backButton = detailPage.GetComponentInChildren<Button>();
            if (backButton != null)
            {
                backButton.onClick.AddListener(ShowNewsHomePage);
            }
        }

        // 设置关机弹窗按钮的点击事件
        shutdownConfirmButton.onClick.AddListener(ConfirmShutdown);
        shutdownCancelButton.onClick.AddListener(HideShutdownPopup);
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
        netBar.SetActive(false);
    }

    // 隐藏所有详情页
    void HideAllDetailPages()
    {
        foreach (var page in forumDetailPages)
            page.SetActive(false);

        foreach (var page in newsDetailPages)
            page.SetActive(false);

        HideShutdownPopup();
    }

    // 显示指定的论坛详情页
    public void ShowForumDetailPage(int index)
    {
        HideAllDetailPages();
        if (index >= 0 && index < forumDetailPages.Length)
        {
            LoadForumContent(postArray[index], forumDetailPages[index]);
            forumDetailPages[index].SetActive(true);
        }
    }

    // 显示指定的新闻详情页
    public void ShowNewsDetailPage(int index)
    {
        HideAllDetailPages();
        if (index >= 0 && index < newsDetailPages.Length)
        {
            LoadNewsContent(newsArray[index], newsDetailPages[index]);
            newsDetailPages[index].SetActive(true);

            // 加载新闻内容
        }
    }

    // 加载内容到对应的文本框
    private void LoadNewsContent(NewsDetailScriptableObject content, GameObject detailPage)
    {
        // 在详情页中找到对应的 Text 组件
        Text titleText = FindText(detailPage, "NewsTitle");
        Text authorText = FindText(detailPage, "NewsAuthor");
        Text dateText = FindText(detailPage, "NewsTime");
        Text contentText = FindText(detailPage, "NewsText");

        // 将内容加载到 Text 组件中
        titleText.text = content.title;
        authorText.text = content.author;
        dateText.text = content.time;
        contentText.text = content.content;
    }

    private void LoadForumContent(PostScriptableObject content, GameObject detailPage)
    {
        // 在详情页中找到对应的 Text 组件
        Text titleText = FindText(detailPage, "Title");
        Text contentText = FindText(detailPage, "PostContent");

        // 将内容加载到 Text 组件中
        titleText.text = content.title + "\n";
        contentText.text = content.content + "\n";
    }

    private void LoadForumHomePage(PostScriptableObject content, GameObject homepage)
    {
        // 在详情页中找到对应的 Text 组件
        Text titleText = FindText(homepage, "Title");
        Text authorTimeText = FindText(homepage, "AuthorTime");

        // 将内容加载到 Text 组件中
        titleText.text = content.title + "\n";
        authorTimeText.text = content.author + " / " + content.lastEditTime;
    }

    private void LoadNewsHomePage()
    {
        foreach (Transform child in newsHomeTitles.transform)
        {
            Destroy(child.gameObject);
        }

        for (int i = 0; i < newsArray.Length; i++)
        {
            // 动态生成按钮，显示新闻标题
            GameObject titleButton = Instantiate(NewsTitlePrefab, newsHomePage.transform);
            Button buttonComponent = titleButton.GetComponent<Button>();
            Text buttonText = titleButton.GetComponentInChildren<Text>();

            // 设置按钮文本为新闻标题，并为按钮添加点击事件
            buttonText.text = newsArray[i].title;

            // 将每个按钮的点击事件绑定到显示新闻详情页的方法上
            int index = i; // 需要一个局部变量来存储当前索引，防止闭包问题
            buttonComponent.onClick.AddListener(() => ShowNewsDetailPage(index));
        }

        LoadNewsHeadline(newsheadline, newsHomePage);


    }

    private void LoadNewsHeadline(NewsDetailScriptableObject content, GameObject headlinePage)
    {
        Text headLine = FindText(headlinePage, "HeadlineTitle");
        headLine.text = content.title + "\n";
    }

    private Text FindText(GameObject detailPage, string name)
    {
        // 获取所有子对象中包含的 Text 组件
        Text[] allTextComponents = detailPage.GetComponentsInChildren<Text>(true);

        // 遍历所有 Text 组件，找到名称匹配的对象
        foreach (Text textComponent in allTextComponents)
        {
            if (textComponent.gameObject.name == name)
            {
                return textComponent; // 返回找到的 Text 组件
            }
        }

        return null;
    }
}