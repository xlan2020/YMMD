
using UnityEngine;

public class DisplaceButtonActivator : MonoBehaviour
{
    [SerializeField] DisplaceButton displaceButton;
    public Animator displaceEffect;

    public void executeDisplaceAction()
    {
        displaceButton.ExecuteDisplaceAction();
    }

    private void turnOnDisplaceEffect()
    {
        displaceEffect.SetBool("displacing", true);
    }

    private void turnOffDisplaceEffect()
    {
        displaceEffect.SetBool("displacing", false);
    }

}
