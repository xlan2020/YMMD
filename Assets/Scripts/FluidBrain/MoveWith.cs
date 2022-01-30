using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWith : MonoBehaviour
{
    public GameObject Target;
    public float rate_x = 1;
    public float rate_y = 1;
    public float rate_z = 1;
    private Vector3 prevPosition;

    // Start is called before the first frame update
    void Start()
    {
        prevPosition = Target.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float displace_x = (Target.transform.position.x - prevPosition.x) * rate_x;
        float displace_y = (Target.transform.position.y - prevPosition.y) * rate_y;
        float displace_z = (Target.transform.position.z - prevPosition.z) * rate_z;

        transform.position = new Vector3(transform.position.x + displace_x, transform.position.y + displace_y, transform.position.z + displace_z);
        prevPosition = Target.transform.position;
    }
}
