using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WineSelectManager : MonoBehaviour
{

    // Wine Data
    private List<Wine> wines; //为了如果需要restart-"再来一杯!"的功能，储存所有酒的信息；如果ink可以自己重启这个init那就不用了
    private List<Wine> remainingWines; //剩余的酒列表
    private int nextQuestion; // 下一个要问的问题

    // Start is called before the first frame update
    public void Start()
    {
        InitializeGame();
    }

    private void InitializeGame()
    {
        // Initialize wine data with attributes
        wines = new List<Wine>
        {
            new Wine("Deep Sea Special", new List<string> { "Dry", "Light", "Fruit" }, new List<string> { "Modern", "Sea", "Cold", "Nature", "Reality", "Lost" },
                "冰凉的、漆黑的、深不⻅底的。 *人⻥的眼泪、金酒、⻘柠皮、红茶、深海鱿⻥墨*"),

            new Wine("Hot Mama", new List<string> { "Dry", "Rich", "Fruit" }, new List<string> { "Modern", "Land", "Hot", "Artificial", "Reality", "Return" },
                "炽热而无法驯服，奂⻔人的精神客厅。 *波本威士忌、鲜姜利口酒、花椒、小米辣、热麻麻精品苹果醋*"),

            new Wine("Witch's Brew", new List<string> { "Dry", "Rich", "Flower" }, new List<string> { "Mythology", "Land", "Hot", "Artificial", "Dream", "Lost" },
                "一条腿的女巫住在⻓着⻦类脚爪的森林木屋里，引诱迷途的孩子。她的锅里煮着什么？ *女巫的宝石、⻰舌兰、接⻣木花利口酒、茴香、鸡蛋清*"),

            new Wine("Siren's Whisper", new List<string> { "Sweet", "Light", "Flower" }, new List<string> { "Mythology", "Sea", "Cold", "Nature", "Dream", "Lost" },
                "她的诡异旋律散在海⻛中。 *海妖之歌、朗姆、荔枝利口酒、木槿糖浆、海盐*"),

            new Wine("Sand Lady", new List<string> { "Sweet", "Rich", "Flower" }, new List<string> { "Mythology", "Land", "Hot", "Artificial", "Dream", "Lost" },
                "她游荡于沙漠，使旅人沉入永恒的梦境。 *沙漠之⻛、藏红花白兰地、菠萝汁、椰奶、洋甘菊利口酒、金粉*"),

            new Wine("Twinkling Stars", new List<string> { "Sweet", "Light", "Fruit" }, new List<string> { "Modern", "Sea", "Cold", "Nature", "Reality", "Return" },
                "为炎热夏日带来神秘的清爽感，隐藏着秘密与魔法。 *蝴蝶闪粉、伏特加、气泡蓝莓汁、薄荷糖浆、薰衣草苦精。*")
        };

        remainingWines = new List<Wine>(wines);
    }

    private void HandleWine(string choice)
    {
        // 根据当前问题的回答过滤酒品
        remainingWines = remainingWines.Where(w => w.Flavors.Contains(choice)).ToList();

        // 如果剩余的酒品数量大于1，则继续提问，否则显示结果
        if (remainingWines.Count > 1)
        {
            DetermineNextQuestion();
        }
        else
        {
            ShowResult();
        }
    }

    private void DetermineNextQuestion()
    {
        List<int> goodQuestions = new List<int> { };
        System.Random rnd = new();

        // 确定下一个要问的问题，确保每个选项都有至少一个酒品
        if (remainingWines.Any(w => w.Flavors.Contains("Sweet")) && remainingWines.Any(w => w.Flavors.Contains("Dry")))
        {
            goodQuestions.Add(1);
        }
        if (remainingWines.Any(w => w.Flavors.Contains("Light")) && remainingWines.Any(w => w.Flavors.Contains("Rich")))
        {
            goodQuestions.Add(2);
        }
        if (remainingWines.Any(w => w.Flavors.Contains("Fruit")) && remainingWines.Any(w => w.Flavors.Contains("Flower")))
        {
            goodQuestions.Add(3);
        }

        //在可以问的问题中随机选择一个提问
        nextQuestion = goodQuestions[rnd.Next(goodQuestions.Count)];

        // 将结果传递给Ink
    }

    private void ShowResult()
    {
        if (remainingWines.Count == 1)
        {
            var selectedWine = remainingWines[0];

            // 显示结果

        }
    }

    /*private void RestartGame()
    {
        remainingWines = new List<Wine>(wines);
        // 重启ink？

    }*/
}
