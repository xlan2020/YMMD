using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawWorkStation : MonoBehaviour
{
    public ObserveeManager observeeManager;
    // Start is called before the first frame update


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Observee"))
        {
            other.gameObject.GetComponent<Observee>().SendRight();
        }
    }

    /**
    void OnTriggerStay2D(Collider2D other)
    {
        // Debug.Log("something stays in the right screen");
        if (other.gameObject.CompareTag("Observee"))
        {
            Observee observee = other.gameObject.GetComponent<Observee>();
            if (other.gameObject.GetComponent<DragDrop>().IsOnDrop() && !observee.IsCollected())
            {
                observeeManager.MarkAsCollected(observee);
                observee.SaveSnapPosRight();
            }
        }
    }
*/

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Observee"))
        {
            other.gameObject.GetComponent<Observee>().SendLeft();
        }
    }
}
