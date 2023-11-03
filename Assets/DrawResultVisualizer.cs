using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DrawResultVisualizer : MonoBehaviour
{
    [Header("Result Drawing Info")]
    public Text title;
    public Text subject;
    public Text theme;

    [Header("Materials")]
    public Image mat1;
    public Image mat2;
    public Image mat3;

    [Header("Score Calculation")]
    public Text mat_vals;
    public Text mat_prefs;
    public Text mat_sum;

    public Text mat_stability;
    public Text mat_score;

    public Text theme_score;
    public Text all_sum;
    public Text reputation;
    public Text gain;

    [Header("Multiplier Color")]
    public Color goodColor = Color.green;
    public Color normColor = Color.black;
    public Color badColor = Color.red;

    [Header("Reactions")]
    public SpriteRenderer clientProfile;
    public Text clientName;
    public Text clientReaction;
    public Text painterReaction;
    
    [Header("Result Drawing Visual")]
    public Image resultDrawingDisplay;

    public void ShowSelf(bool b)
    {
        gameObject.SetActive(b);
        if (b == true)
        {
            // handle audio
            // stop current bgm
            // play draw result bgm
        }
    }
    public void DisplayMatVals(int experimental, int organic, int premium){

        this.mat_vals.text=experimental+"\n"+organic+"\n"+premium;
    }

    public void DisplayMatPrefMultiplier(int experimental, int organic, int premium){
        
        this.mat_prefs.text = TranslateAttitudeSymbol(experimental)+"\n"+TranslateAttitudeSymbol(organic)+"\n"+TranslateAttitudeSymbol(premium);
    }

    private string TranslateAttitudeSymbol(int multipler){
        
        if(multipler==1){
            return "";
        }else {
        string output = "× "+multipler;
        return output; 
        }
    }

    public void DisplayMatSum(int sum){
        this.mat_sum.text=""+sum;
    }

    public void DisplayMatStabilityMultiplier(float mul){
        this.mat_stability.text= "× " + mul;

        if (mul==0.5f){
            // 角标 display 不稳定
            this.mat_stability.color=badColor;
        } else if (mul==2f){
            // 角标 display 非常稳定
            this.mat_stability.color=goodColor;
        }else{
            // 角标 display 正常
            this.mat_stability.color=normColor;
        }
    }

    public void DisplayMatResult(float score){
        this.mat_score.text=""+score;
    }

    public void DisplayResultDrawingInfo(ResultDrawingScriptableObject resDraw){
        // info
        title.text=resDraw.title;
        subject.text=resDraw.subject;
        theme.text=resDraw.themeDescription;

        // theme score update
        theme_score.text=""+resDraw.themeScore;

        // reactions
        clientProfile.sprite=resDraw.clientProfile;
        this.clientName.text = resDraw.subject;
        clientReaction.text = resDraw.clientReaction;
        painterReaction.text = resDraw.painterReaction;
    }

    public void DisplayResultDrawingVisuals(ResultDrawingScriptableObject resDraw){
        resultDrawingDisplay.sprite=resDraw.image;
    }

}
