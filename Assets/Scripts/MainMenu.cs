using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        Inventory.money = 100.0;
        Inventory.wheat = 0.0;
        Inventory.corn = 0.0;
        Inventory.beet = 0.0;
        Inventory.rapeseed = 0.0;
        Inventory.wheatSeed = 0.0;
        Inventory.cornSeed = 0.0;
        Inventory.beetSeed = 0.0;
        Inventory.rapeseedSeed = 0.0;
        FieldMenuScript.count = 0;
        HUDScript.missionDone = false;
        HUDScript.garageOpened = false;
        SceneManager.LoadScene(1);
    }
    
    public void QuitGame()
    {
        Application.Quit();
    }
}
