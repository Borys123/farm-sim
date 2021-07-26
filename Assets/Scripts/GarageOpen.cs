using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarageOpen : MonoBehaviour
{
    public GameObject player;
    public GameObject garageMenu;
    public GameObject tractor;
    public GameObject plow;
    public GameObject planter;
    public GameObject combine;
    public GameObject tractorCam;
    public GameObject combineCam;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player" && HUDScript.missionDone == true && Input.GetKeyDown(KeyCode.E))
        {
            if (HUDScript.garageOpened == false)
                HUDScript.garageOpened = true;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            garageMenu.SetActive(true);
            player.SetActive(false);

        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Tractor" || other.gameObject.tag == "Plow" || other.gameObject.tag == "Planter" || other.gameObject.tag == "Combine")
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            tractor.SetActive(false);
            plow.SetActive(false);
            planter.SetActive(false);
            combine.SetActive(false);
            tractorCam.SetActive(false);
            combineCam.SetActive(false);
            player.SetActive(true);

        }
    }
}
