using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tools : MonoBehaviour
{
    public GameObject shovel;
    public GameObject sickle;
    public GameObject seeds;
    public static int equipped = 0;
    private Vector3 shovelPosition;
    private Quaternion shovelRotation;
    private Vector3 sicklePosition;
    private Quaternion sickleRotation;


    void deactivate()
    {
        shovel.SetActive(false);
        sickle.SetActive(false);
        seeds.SetActive(false);
        shovel.transform.localPosition = shovelPosition;
        shovel.transform.localRotation = shovelRotation;
        sickle.transform.localPosition = sicklePosition;
        sickle.transform.localRotation = sickleRotation;
        equipped = 0;
    }

    void activate(int x)
    {
        switch(x)
        {
            case 1:
                shovel.SetActive(true);
                equipped = x;
                break;
            case 2:
                sickle.SetActive(true);
                equipped = x;
                break;
            case 3:
                seeds.SetActive(true);
                equipped = x;
                break;
            case 4:
               seeds.SetActive(true);
                equipped = x;
                break;
            case 5:
                seeds.SetActive(true);
                equipped = x;
                break;
            case 6:
                seeds.SetActive(true);
                equipped = x;
                break;
        }
    }

    void Start()
    {
        shovelPosition = shovel.transform.localPosition;
        shovelRotation = shovel.transform.localRotation;
        sicklePosition = sickle.transform.localPosition;
        sickleRotation = sickle.transform.localRotation;
        deactivate();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            deactivate();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            deactivate();
            activate(1);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            deactivate();
            activate(2);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            deactivate();
            activate(3);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            deactivate();
            activate(4);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            deactivate();
            activate(5);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            deactivate();
            activate(6);
        }
    }
}
