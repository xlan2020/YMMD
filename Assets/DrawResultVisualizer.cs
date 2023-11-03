using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DrawResultVisualizer : MonoBehaviour
{
    public GameManager gm;
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
    public AudioSource gainAudio;

    [Header("Multiplier Color")]
    public Color goodColor = Color.green;
    public Color normColor = Color.black;
    public Color badColor = Color.red;

    [Header("Reactions")]
    public SpriteRenderer clientProfile;
    //public Text clientName;
    public TextTyper clientReaction;
    public TextTyper painterReaction;
    
    [Header("Result Drawing Visual")]
    public Image resultDrawingDisplay;

    [Header("AudioClip")]
    public AudioClip scoreUpAudio;
    public AudioClip scoreInPlaceAudio;
    public AudioClip textAppearLongAudio;
    public AudioClip textAppearShortAudio;
    private AudioSource auido;

    // logic
    private float displayGain;
    private float targetGain;
    private float displayChangeUnit = 5f;


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
        //this.clientName.text = resDraw.subject;
        clientReaction.text = resDraw.clientReaction;
        painterReaction.text=resDraw.painterReaction;
    }

    public void DisplayResultDrawingVisuals(ResultDrawingScriptableObject resDraw){
        resultDrawingDisplay.sprite=resDraw.image;
    }

    public void DisplayTotalScore(float num){
        all_sum.text=""+num;
    }

    public void SetTargetGain(float gainAmount){
        this.targetGain=gainAmount;
    }
    public void DisplayGain(){
        StartCoroutine(changingGainDisplay(this.targetGain));
    }

    private IEnumerator changingGainDisplay(float targetGain)
    {
        // take consideration of the case if Gain is not an integer
        // the display animation increase / decrease Gain by 1 unit
        // if the the difference between the target and current display is less than 1 unit
        // increasing and decreasing might never meet the target
        // so we are calculating the difference but not only increasing and decreasing
        // difference is absolute, so actually <-1 unit or >1 unit
        gainAudio.loop=true;
        gainAudio.Play();
        while (displayGain - targetGain < -displayChangeUnit)
        {
            displayGain += displayChangeUnit;
            gain.text = "+￥"+ displayGain.ToString("0.00");
            yield return new WaitForSeconds(0.04f);    // animation interval
        }
        while (displayGain - targetGain > displayChangeUnit)
        {
            displayGain -= displayChangeUnit;
            gain.text = "+￥"+displayGain.ToString("0.00");
            yield return new WaitForSeconds(0.04f);    // animation interval
        }
        // else: 
        // -1 unit < displayGain - targetGain < 1 unit
        displayGain = targetGain;
        gain.text = "+￥"+displayGain.ToString("0.00");
        gm.AddMoney(targetGain);
        gainAudio.Stop();
    }

    public void TypeClientReaction(){
        clientReaction.StartTyping();
    }

    public void TypePainterReaction(){
        painterReaction.StartTyping();
    }

    public void PlayAudio(string name){
        GetComponent<AudioSource>().loop=false;
        switch(name){
            case "scoreUp":
            GetComponent<AudioSource>().clip=scoreUpAudio;
            break;
            case "scoreInPlace":
            GetComponent<AudioSource>().clip=scoreInPlaceAudio;
            break;
            case "textAppearLong":
            GetComponent<AudioSource>().clip=textAppearLongAudio;
            break;
            case "textAppearShort":
            GetComponent<AudioSource>().clip=textAppearShortAudio;
            break;
            default:
            return;
        }
        GetComponent<AudioSource>().Play();
    }

}
