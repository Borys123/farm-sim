using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanterSeeds : MonoBehaviour
{
    public static int equipped = 3;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            activate(3);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            activate(4);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            activate(5);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            activate(6);
        }
    }

    void activate(int x)
    {
        switch (x)
        {
            case 3:
                equipped = x;
                break;
            case 4:
                equipped = x;
                break;
            case 5:
                equipped = x;
                break;
            case 6:
                equipped = x;
                break;
        }
    }
}