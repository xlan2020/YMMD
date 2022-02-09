/* 
    ------------------- Code Monkey -------------------

    Thank you for downloading this package
    I hope you find it useful in your projects
    If you have any questions let me know
    Cheers!

               unitycodemonkey.com
    --------------------------------------------------
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DissolveEffect : MonoBehaviour
{

    [SerializeField] private Material material;

    public UnityEngine.Color DissolveColor;
    private float dissolveAmount;
    private float dissolveSpeed;
    private bool isDissolving;
    private List<GameObject> destroyObjects;
    public bool DestroyAfterDissolve = true;

    private void Start()
    {
        if (material == null)
        {
            material = transform.Find("Body").GetComponent<MeshRenderer>().material;
        }
    }

    private void Update()
    {
        if (isDissolving)
        {
            dissolveAmount = Mathf.Clamp01(dissolveAmount + dissolveSpeed * Time.deltaTime);
            material.SetFloat("_DissolveAmount", dissolveAmount);

            if (DestroyAfterDissolve && dissolveAmount >= 1)
            {
                foreach (GameObject o in destroyObjects)
                {
                    Destroy(o);
                    UnityEngine.Debug.Log("Destroy gameobject after dissolved.");
                }
                destroyObjects.Clear();
            }

        }
        else
        {
            dissolveAmount = Mathf.Clamp01(dissolveAmount - dissolveSpeed * Time.deltaTime);
            material.SetFloat("_DissolveAmount", dissolveAmount);
        }
    }

    public void StartDissolve(float dissolveSpeed)
    {
        isDissolving = true;
        material.SetColor("_DissolveColor", DissolveColor);
        this.dissolveSpeed = dissolveSpeed;
    }

    public void StopDissolve(float dissolveSpeed)
    {
        isDissolving = false;
        material.SetColor("_DissolveColor", DissolveColor);
        this.dissolveSpeed = dissolveSpeed;
    }

    public void SetDestroyAfterDissolved(bool b)
    {
        DestroyAfterDissolve = b;
    }

    public void SetDestroyObjects(List<GameObject> objects)
    {
        destroyObjects = objects;
    }

}
