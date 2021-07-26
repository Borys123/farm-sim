using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SellMenu : MonoBehaviour
{

    public static double wheatCropPrice = 0.75;
    public static double cornCropPrice = 0.7;
    public static double beetCropPrice = 0.7;
    public static double rapeseedCropPrice = 1.53;
    public TextMeshProUGUI priceWheat;
    public TextMeshProUGUI priceCorn;
    public TextMeshProUGUI priceBeet;
    public TextMeshProUGUI priceRapeseed;
    public TextMeshProUGUI invWheat;
    public TextMeshProUGUI invCorn;
    public TextMeshProUGUI invBeet;
    public TextMeshProUGUI invRapeseed;
    public TextMeshProUGUI moneyText;

    public void Sell(string crop)
    {
        switch(crop)
        {
            case "Wheat":
                Inventory.money += Inventory.wheat * wheatCropPrice;
                Inventory.wheat = 0;
                break;
            case "Corn":
                Inventory.money += Inventory.corn * cornCropPrice;
                Inventory.corn = 0;
                break;
            case "Beet":
                Inventory.money += Inventory.beet * beetCropPrice;
                Inventory.beet = 0;
                break;
            case "Rapeseed":
                Inventory.money += Inventory.rapeseed * rapeseedCropPrice;
                Inventory.rapeseed = 0;
                break;
        }
    }

    void Start()
    {
        priceWheat.text = wheatCropPrice + " PLN/kg";
        priceCorn.text = cornCropPrice + " PLN/kg";
        priceBeet.text = beetCropPrice + " PLN/kg";
        priceRapeseed.text = rapeseedCropPrice + " PLN/kg";
    }

    void Update()
    {
        invWheat.text = "Posiadane: " + Inventory.wheat.ToString("F2") + " kg";
        invCorn.text = "Posiadane: " + Inventory.corn.ToString("F2") + " kg";
        invBeet.text = "Posiadane: " + Inventory.beet.ToString("F2") + " kg";
        invRapeseed.text = "Posiadane: " + Inventory.rapeseed.ToString("F2") + " kg";
        moneyText.text = "Pieniądze: " + Inventory.money.ToString("F2") + " PLN";
    }
}
