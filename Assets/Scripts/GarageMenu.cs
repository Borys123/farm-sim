using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GarageMenu : MonoBehaviour
{
    public GameObject player;
    public GameObject garageMenu;
    public GameObject tractor;
    public GameObject plow;
    public GameObject planter;
    public GameObject combine;
    public GameObject tractorCam;
    public GameObject combineCam;

    public void setPos()
    {
        tractor.transform.position = new Vector3(9.83f, 0.01f, 32.11f);
        tractor.transform.rotation = new Quaternion(0.0f,0.0f,0.0f,0.0f);
        combine.transform.position = new Vector3(9.83f, 0.01f, 32.11f);
        combine.transform.rotation = new Quaternion(0.0f, 0.0f, 0.0f, 0.0f);
    }

    public void exitShop()
    {
        player.SetActive(true);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        garageMenu.SetActive(false);
    }

    public void enterTractor()
    {
        player.SetActive(false);
        tractor.SetActive(true);
        setPos();
        tractorCam.SetActive(true);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        garageMenu.SetActive(false);
    }

    public void enterPlow()
    {
        player.SetActive(false);
        tractor.SetActive(true);
        setPos();
        tractorCam.SetActive(true);
        plow.SetActive(true);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        garageMenu.SetActive(false);
    }

    public void enterPlanter()
    {
        player.SetActive(false);
        tractor.SetActive(true);
        setPos();
        tractorCam.SetActive(true);
        planter.SetActive(true);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        garageMenu.SetActive(false);
    }

    public void enterCombine()
    {
        player.SetActive(false);
        combine.SetActive(true); // delete later
        setPos(); // delete later
        combineCam.SetActive(true); // change later
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        garageMenu.SetActive(false);
    }

    void Start()
    {

    }

    void Update()
    {

    }
}
