using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hoop : MonoBehaviour
{
    [SerializeField] Image[] images;
    [SerializeField] Animator animationController;
    // initial loc;
    private int x_loc = 0;
    private int y_loc = 0;

    // start hoop moving animations, x and y = target location
    public void StartSpin()
    {
        // animation of hoop flying towards goal
        animationController.SetBool("isSpinning", true);
    }

    public void ResetAnimation()
    {
        // animation of hoop flying towards goal
        animationController.SetBool("isFalling", false);
        animationController.SetBool("isSpinning", false);
    }
    public void StartFall()
    {
        // animation of hoop flying towards goal
        animationController.SetBool("isFalling", true);
        animationController.SetBool("isSpinning", false);
    }

    public void ChangeColor(Color color)
    {
        foreach(Image image in images)
        {
            image.color = color;
        }
    }
}
