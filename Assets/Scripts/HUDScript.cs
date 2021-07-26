using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using TMPro;

public class HUDScript : MonoBehaviour
{
    public TextMeshProUGUI resourceText;
    public TextMeshProUGUI itemText;
    public TextMeshProUGUI missionText;
    public static bool missionDone = false;
    public static bool garageOpened = false;
    public GameObject menu;
    public GameObject player;

    void Start()
    {
        missionText.text =
            "Zadanie:\n" +
            "Zarób 2000 PLN";

        resourceText.text = "Menu - 'P'\n" +
                            "Pieniądze: " + Inventory.money.ToString("F2") + " PLN\n" +
            "Nas.Pszenicy: " + Inventory.wheatSeed.ToString("F2") + " kg\n" +
            "Nas. Kukurydzy: " + Inventory.cornSeed.ToString("F2") + " kg\n" +
            "Nas. Buraka: " + Inventory.beetSeed.ToString("F2") + " kg\n" +
            "Nas. Rzepaku: " + Inventory.rapeseedSeed.ToString("F2") + " kg\n" +
            "Pszenica: " + Inventory.wheat.ToString("F2") + " kg\n" +
            "Kukurydza: " + Inventory.corn.ToString("F2") + " kg\n" +
            "Burak: " + Inventory.beet.ToString("F2") + " kg\n" +
            "Rzepak: " + Inventory.rapeseed.ToString("F2") + " kg";
        if (GameObject.FindWithTag("Player").activeSelf == true)
        {
            switch (Tools.equipped)
            {
                case 0:
                    itemText.text = "-";
                    break;
                case 1:
                    itemText.text = "Łopata";
                    break;
                case 2:
                    itemText.text = "Sierp";
                    break;
                case 3:
                    itemText.text = "Pszenica";
                    break;
                case 4:
                    itemText.text = "Kukurydza";
                    break;
                case 5:
                    itemText.text = "Burak";
                    break;
                case 6:
                    itemText.text = "Rzepak";
                    break;
            }
        }
        else if (GameObject.FindWithTag("Planter").activeSelf == true)
        {
            Debug.Log("PLANTER");
            switch (PlanterSeeds.equipped)
            {
                case 3:
                    itemText.text = "Pszenica";
                    break;
                case 4:
                    itemText.text = "Kukurydza";
                    break;
                case 5:
                    itemText.text = "Burak";
                    break;
                case 6:
                    itemText.text = "Rzepak";
                    break;
            }
        }
        else itemText.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        resourceText.text = "Menu - 'P'\n" +
                            "Pieniądze: " + Inventory.money.ToString("F2") + " PLN\n" +
                            "Nas.Pszenicy: " + Inventory.wheatSeed.ToString("F2") + " kg\n" +
                            "Nas. Kukurydzy: " + Inventory.cornSeed.ToString("F2") + " kg\n" +
                            "Nas. Buraka: " + Inventory.beetSeed.ToString("F2") + " kg\n" +
                            "Nas. Rzepaku: " + Inventory.rapeseedSeed.ToString("F2") + " kg\n" +
                            "Pszenica: " + Inventory.wheat.ToString("F2") + " kg\n" +
                            "Kukurydza: " + Inventory.corn.ToString("F2") + " kg\n" +
                            "Burak: " + Inventory.beet.ToString("F2") + " kg\n" +
                            "Rzepak: " + Inventory.rapeseed.ToString("F2") + " kg";
        if (GameObject.FindWithTag("Player"))
        {
            switch (Tools.equipped)
            {
                case 0:
                    itemText.text = "";
                    break;
                case 1:
                    itemText.text = "Łopata";
                    break;
                case 2:
                    itemText.text = "Sierp";
                    break;
                case 3:
                    itemText.text = "Pszenica";
                    break;
                case 4:
                    itemText.text = "Kukurydza";
                    break;
                case 5:
                    itemText.text = "Burak";
                    break;
                case 6:
                    itemText.text = "Rzepak";
                    break;
            }
        }
        else if (GameObject.FindWithTag("Planter"))
        {
            switch (PlanterSeeds.equipped)
            {
                case 3:
                    itemText.text = "Pszenica";
                    break;
                case 4:
                    itemText.text = "Kukurydza";
                    break;
                case 5:
                    itemText.text = "Burak";
                    break;
                case 6:
                    itemText.text = "Rzepak";
                    break;
            }
        }
        else itemText.text = "";

        if (missionDone == false && Inventory.money >= 2000 && garageOpened == false)
        {
            missionText.text =
                "Gratulacje! Twój wniosek o dofinansowanie z Unii Europejskiej " +
                "\nzostał rozpatrzony pozytywnie!" +
                "\nOtrzymujesz ciągnik z osprzętem i kombajn! " +
                "\nPójdź do garażu i naciśnij 'E'!";
            missionDone = true;
        }
        else if (garageOpened == true)
        {
            missionText.text = "";
        }

        if (Input.GetKeyDown(KeyCode.P) && GameObject.FindWithTag("Player"))
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            menu.SetActive(true);
            player.SetActive(false);
        }
    }
}
