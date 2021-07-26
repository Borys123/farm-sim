using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HingeScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<Rigidbody>().centerOfMass = new Vector3(0, 0, 0);
        this.GetComponent<Rigidbody>().inertiaTensor = new Vector3(1, 1, 1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
