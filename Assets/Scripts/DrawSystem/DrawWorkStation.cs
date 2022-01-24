using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawWorkStation : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("something enters right screen");
        if (other.gameObject.CompareTag("Observee"))
        {
            other.gameObject.GetComponent<Observee>().SendRight();
            other.gameObject.GetComponent<Observee>().SetIsCollected(true);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("something enters right screen");
        if (other.gameObject.CompareTag("Observee"))
        {
            //other.gameObject.GetComponent<Observee>().CanMove(false);
        }
    }
}
