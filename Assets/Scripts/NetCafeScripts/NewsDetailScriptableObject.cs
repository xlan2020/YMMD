using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewsDetailSO_", menuName = "ScriptableObjects/NetCafe/newsDetail")]
public class NewsDetailScriptableObject : ScriptableObject
{
    [TextAreaAttribute(2,1)]public string title;
    [TextAreaAttribute(2,1)]public string title_EN;
    public string author; // format: 直接写名字，“作者：”的前缀用manager统一加
    public string author_EN;
    public string time;
    public string time_EN;
    [TextAreaAttribute(10, 3)]public string content;
    [TextAreaAttribute(10, 3)]public string content_EN;

}
