using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DrinkWaterCup : MonoBehaviour
{
    private float bottomLimitValue = 0.2f;
    private Slider slider;
    public Animator mermaidAnimator;
    [SerializeField] private float drinkingSpeed = 0.01f;

    void Awake(){
        slider=GetComponent<Slider>();
    }
    void Start(){
        slider.value = 1f;
    }

    public void DrinkWater(float amount){
        StartCoroutine(drinkWaterCoroutine(slider.value-amount));
    }

    IEnumerator drinkWaterCoroutine(float target){
        
        while (slider.value>target){
            slider.value -= drinkingSpeed;
            mermaidAnimator.SetFloat("waterAmount", slider.value);
            yield return new WaitForSeconds(0.04f);
        }
        
        if (slider.value < bottomLimitValue){
            // has drunk all water
            // trigger next animation
            UnityEngine.Debug.Log("drinking is done!");
        }
    }
}
