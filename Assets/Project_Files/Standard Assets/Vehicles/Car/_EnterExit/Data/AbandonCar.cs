using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbandonCar : MonoBehaviour
{
     public CarSwitcher carSwitcher;
    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.name == "Character" && Input.GetKeyDown(KeyCode.E) && Time.time > carSwitcher.nextSpawnTime)
        {
                carSwitcher.OlSwitcheroo();
                Debug.Log("Abandon Car");
        }
    }  
}
