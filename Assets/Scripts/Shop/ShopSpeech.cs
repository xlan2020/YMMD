using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopSpeech : MonoBehaviour
{
    public string welcomeSpeech;
    public string welcomeSpeech_EN;
    public string[] saleSpeech;
    public string[] saleSpeech_EN;
    public string noMoneySpeech;
    public string noMoneySpeech_EN;
    public string[] buySuccessSpeech; // not random, loop by sequence
    public string[] buySuccessSpeech_EN;
    public string[] refreshSpeech;
    public string[] refreshSpeech_EN;
    private int saleSpeechIndex = 0;
    private int buySuccessIndex = 0;
    private int refreshIndex = 0;


    public void PlayWelcomeSpeech(TextTyper typer)
    {
        switch (GameEssential.localeId)
        {
            case 0:
                typer.StartTypingLine(welcomeSpeech);
                break;
            case 1:
                typer.StartTypingLine(welcomeSpeech_EN);
                break;
            default:
                break;
        }
    }
    public void PlaySaleSpeech(TextTyper typer)
    {
        typer.StopTyping();
        typer.StartTypingLine(getRandomSaleSpeech());
    }
    public void PlayNoMoneySpeech(TextTyper typer)
    {
        typer.StopTyping();
        switch (GameEssential.localeId)
        {
            case 0:
                typer.StartTypingLine(noMoneySpeech);
                break;
            case 1:
                typer.StartTypingLine(noMoneySpeech_EN);
                break;
            default:
                break;
        }
    }
    public void PlayBuySuccessSpeech(TextTyper typer)
    {
        typer.StopTyping();
        typer.StartTypingLine(getBuySuccessSpeech());
    }
    public void PlayRefreshSpeech(TextTyper typer)
    {
        typer.StopTyping();
        typer.StartTypingLine(getRefreshSpeech());
    }
    private string getBuySuccessSpeech()
    {
        string[] speeches = buySuccessSpeech;
        if (speeches.Length == 0)
        {
            return "...";
        }

        switch (GameEssential.localeId)
        {
            case 0:
                speeches = buySuccessSpeech;
                break;
            case 1:
                speeches = buySuccessSpeech_EN;
                break;
            default:
                break;
        }

        if (buySuccessIndex < speeches.Length - 1)
        {
            buySuccessIndex++;
        }
        else
        {
            buySuccessIndex = 0;
        }
        return speeches[buySuccessIndex];

    }
    private string getRefreshSpeech()
    {
        string[] speech = refreshSpeech;
        switch (GameEssential.localeId)
        {
            case 0:
                break;
            case 1:
                speech = refreshSpeech_EN;
                break;
            default:
                break;
        }

        if (speech.Length == 0)
        {
            return "...";
        }

        if (speech.Length == 1)
        {
            return speech[0];
        }
        // select random index
        int i = 0;
        do
        {
            i = Random.Range(0, speech.Length);
        } while (i == refreshIndex); // Repeat until a new index is chosen

        refreshIndex = i;
        return speech[i];

    }
    private string getRandomSaleSpeech()
    {
        int i = 0;

        switch (GameEssential.localeId)
        {
            case 0:
                if (saleSpeech.Length == 0)
                {
                    return "...";
                }
                // If there is only one element, return it directly to avoid infinite loop
                if (saleSpeech.Length == 1)
                {
                    return saleSpeech[0];
                }

                // Randomly select a different index if there are multiple elements
                do
                {
                    i = Random.Range(0, saleSpeech.Length);
                } while (i == saleSpeechIndex); // Repeat until a new index is chosen

                saleSpeechIndex = i;
                return saleSpeech[saleSpeechIndex];

            case 1:
                if (saleSpeech_EN.Length == 0)
                {
                    return "...";
                }
                if (saleSpeech_EN.Length == 1)
                {
                    return saleSpeech_EN[0];
                }

                do
                {
                    i = Random.Range(0, saleSpeech_EN.Length);
                } while (i == saleSpeechIndex); // Same logic for English speeches

                saleSpeechIndex = i;
                return saleSpeech_EN[saleSpeechIndex];

            default:
                return "";
        }
    }

}
