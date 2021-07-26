using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Globalization;

public class BuyMenu : MonoBehaviour
{
    public static double wheatSeedPrice= 2.1;
    public static double cornSeedPrice = 17.5;
    public static double beetSeedPrice = 250.0;
    public static double rapeseedSeedPrice = 120.0;
    public double amount;
    public TextMeshProUGUI priceWheat;
    public TextMeshProUGUI priceCorn;
    public TextMeshProUGUI priceBeet;
    public TextMeshProUGUI priceRapeseed;
    public InputField input;
    public TextMeshProUGUI invWheatSeed;
    public TextMeshProUGUI invCornSeed;
    public TextMeshProUGUI invBeetSeed;
    public TextMeshProUGUI invRapeseedSeed;
    public TextMeshProUGUI moneyText;


    public void buy(string crop)
    {
        if (!double.TryParse(input.text, System.Globalization.NumberStyles.Any, CultureInfo.CurrentCulture, out amount) &&
            !double.TryParse(input.text, System.Globalization.NumberStyles.Any, CultureInfo.GetCultureInfo("en-US"), out amount) &&
            !double.TryParse(input.text, System.Globalization.NumberStyles.Any, CultureInfo.InvariantCulture, out amount))
        {
            amount = 0.1;
        }
        switch (crop)
        {
            case "Wheat":
                if(Inventory.money >= wheatSeedPrice * amount)
                {
                    Inventory.money -= wheatSeedPrice * amount;
                    Inventory.wheatSeed += amount;
                }
                break;
            case "Corn":
                if (Inventory.money >= cornSeedPrice * amount)
                {
                    Inventory.money -= cornSeedPrice * amount;
                    Inventory.cornSeed += amount;
                }
                break;
            case "Beet":
                if (Inventory.money >= beetSeedPrice * amount)
                {
                    Inventory.money -= beetSeedPrice * amount;
                    Inventory.beetSeed += amount;
                }
                break;
            case "Rapeseed":
                if (Inventory.money >= rapeseedSeedPrice * amount)
                {
                    Inventory.money -= rapeseedSeedPrice * amount;
                    Inventory.rapeseedSeed += amount;
                }
                break;
        }
    }

    void Start()
    {
        priceWheat.text = wheatSeedPrice + " PLN/kg";
        priceCorn.text = cornSeedPrice + " PLN/kg";
        priceBeet.text = beetSeedPrice + " PLN/kg";
        priceRapeseed.text = rapeseedSeedPrice + " PLN/kg";
        input.text = "0.1";
    }

    void Update()
    {
        invWheatSeed.text = "Posiadane: " + Inventory.wheatSeed.ToString("F2") + " kg";
        invCornSeed.text = "Posiadane: " + Inventory.cornSeed.ToString("F2") + " kg";
        invBeetSeed.text = "Posiadane: " + Inventory.beetSeed.ToString("F2") + " kg";
        invRapeseedSeed.text = "Posiadane: " + Inventory.rapeseedSeed.ToString("F2") + " kg";
        moneyText.text = "Pieniądze: " + Inventory.money.ToString("F2") + " PLN";
    }
}
