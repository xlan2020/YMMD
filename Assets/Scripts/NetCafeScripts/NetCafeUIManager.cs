using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class NetCafeUIManager : MonoBehaviour
{
    // 新闻面板
    public GameObject newsHomePage;
    public GameObject[] newsDetailPages;
    public Button[] newsTitleButtons;

    // 论坛面板
    public GameObject forumHomePage;
    public GameObject[] forumDetailPages;
    public Button[] forumTitleButtons;

    // 导航栏按钮
    public Button newsButton;
    public Button forumButton;
    public Button shutdownButton;


    // 关机弹窗
    public GameObject shutdownPopup;
    public Button shutdownConfirmButton;
    public Button shutdownCancelButton;

    // 前一场景名称
    public string prevSceneName = "MapScene";

    void Start()
    {
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
    }

    // 显示论坛首页
    void ShowForumHomePage()
    {
        newsHomePage.SetActive(false);
        forumHomePage.SetActive(true);
        HideAllDetailPages();
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
        SceneManager.LoadScene(prevSceneName);
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