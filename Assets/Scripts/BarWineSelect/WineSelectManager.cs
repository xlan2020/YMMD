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
            new Wine("Deep Sea Special", new List<string> { "Dry", "Light", "Fruit" }, new List<string> { "Modern", "Sea", "Cold", "Nature", "Reality", "Lost" }),

            new Wine("Hot Mama", new List<string> { "Dry", "Rich", "Fruit" }, new List<string> { "Modern", "Land", "Hot", "Artificial", "Reality", "Return" }),

            new Wine("Witch's Brew", new List<string> { "Dry", "Rich", "Flower" }, new List<string> { "Mythology", "Land", "Hot", "Artificial", "Dream", "Lost" }),

            new Wine("Siren's Whisper", new List<string> { "Sweet", "Light", "Flower" }, new List<string> { "Mythology", "Sea", "Cold", "Nature", "Dream", "Lost" }),

            new Wine("Sand Lady", new List<string> { "Sweet", "Rich", "Flower" }, new List<string> { "Mythology", "Land", "Hot", "Artificial", "Dream", "Lost" }),

            new Wine("Twinkling Stars", new List<string> { "Sweet", "Light", "Fruit" }, new List<string> { "Modern", "Sea", "Cold", "Nature", "Reality", "Return" })
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
