using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PostSO_", menuName = "ScriptableObjects/NetCafe/post")]
public class PostScriptableObject : ScriptableObject
{
    [TextAreaAttribute(2,1)]public string title;
    [TextAreaAttribute(2,1)]public string title_EN;

    [TextAreaAttribute(10, 3)]public string content;
    [TextAreaAttribute(10, 3)]public string content_EN;

    //由于lastEdit用的是string比较方便，就不自动sort了
    //输入进当天的NetCafe时要记得手动按照最后回复时间排列次序哦！
    public string lastEditTime;
    public string lastEditTime_EN;
}
