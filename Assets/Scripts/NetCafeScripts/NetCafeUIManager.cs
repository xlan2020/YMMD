using UnityEngine;
using UnityEngine.UI;

public class NetCafeUIManager : MonoBehaviour
{

    public GameObject netBar;
    public GameObject newsHomePage; // 同时作为新闻标题容器
    public GameObject forumHomePage; // 同时作为论坛标题容器

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
            forumDetailPages[index].SetActive(true);
        }
    }

    // 显示指定的新闻详情页
    public void ShowNewsDetailPage(int index)
    {
        HideAllDetailPages();
        if (index >= 0 && index < newsDetailPages.Length)
        {
            newsDetailPages[index].SetActive(true);
        }
    }
}