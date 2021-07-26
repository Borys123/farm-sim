using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FieldMenuScript : MonoBehaviour
{
    public TextMeshProUGUI whichField;
    public TextMeshProUGUI price;
    public GameObject fence1;
    public GameObject fence2;
    public static int count = 0;

    void Start()
    {
        price.text = "CENA:\n" +
                    "20000 PLN";
    }

    void Update()
    {
        if (count == 0)
        {
            whichField.text = "POLE NR 1";
        }
        else if (count == 1)
        {
            whichField.text = "POLE NR 2";
        }
        else
        {
            whichField.text = "KUPIŁEŚ JUŻ WSZYSTKIE MOŻLIWE POLA";
            price.text = "";
        }
    }

    public void buy()
    {
        if (count == 0 && Inventory.money >= 20000.0)
        {
            Inventory.money -= 20000.0;
            fence1.SetActive(false);
            count = 1;
        }

        else if (count == 1 && Inventory.money >= 20000.0)
        {
            Inventory.money -= 20000.0;
            fence2.SetActive(false);
            count = 2;
        }
    }
}
