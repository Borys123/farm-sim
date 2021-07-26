using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using TMPro;
using UnityEngine;
using UnityEngine.Experimental.U2D;
using UnityEngine.SceneManagement;


public class Menu : MonoBehaviour
{
    public GameObject player;
    public GameObject menu;
    public TextMeshProUGUI popup;
    public GameObject fence1;
    public GameObject fence2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            Inventory.money += 1000;
        }
    }

    private Save createSave()
    {
        Save save = new Save();
        save.money = Inventory.money;
        save.beet = Inventory.beet;
        save.beetSeed = Inventory.beetSeed;
        save.corn = Inventory.corn;
        save.cornSeed = Inventory.cornSeed;
        save.rapeseed = Inventory.rapeseed;
        save.rapeseedSeed = Inventory.rapeseedSeed;
        save.wheat = Inventory.wheat;
        save.wheatSeed = Inventory.wheatSeed;
        save.fieldCount = FieldMenuScript.count;
        save.missionDone = HUDScript.missionDone;
        save.garageOpened = HUDScript.garageOpened;
        return save;
    }

    public void saveGame()
    {
        Save save = createSave();
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/savedgame.save");
        bf.Serialize(file, save);
        file.Close();
        StartCoroutine(showPopup("GRA ZAPISANA!", 3));

    }

    public void exitMenu()
    {
        player.SetActive(true);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        menu.SetActive(false);
    }

    public void loadGame()
    {
        if (File.Exists(Application.persistentDataPath + "/savedgame.save"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/savedgame.save", FileMode.Open);
            Save save = (Save) bf.Deserialize(file);
            file.Close();
            Inventory.money = save.money;
            Inventory.beet = save.beet;
            Inventory.beetSeed = save.beetSeed;
            Inventory.corn = save.corn;
            Inventory.cornSeed = save.cornSeed;
            Inventory.rapeseed = save.rapeseed;
            Inventory.rapeseedSeed = save.rapeseedSeed;
            Inventory.wheat = save.wheat;
            Inventory.wheatSeed = save.wheatSeed;
            FieldMenuScript.count = save.fieldCount;
            HUDScript.missionDone = save.missionDone;
            HUDScript.garageOpened = save.garageOpened;
            if (save.fieldCount == 1)
            {
                fence1.SetActive(false);
            }

            else if (save.fieldCount == 2)
            {
                fence2.SetActive(false);
            }
            StartCoroutine(showPopup("GRA WCZYTANA!", 3));
        }
        else
        {
            StartCoroutine(showPopup("BRAK PLIKU!", 3));
        }
    }

    IEnumerator showPopup(string text, float time)
    {
        popup.text = text;
        popup.gameObject.SetActive(true);
        yield return new WaitForSeconds(time);
        popup.gameObject.SetActive(false);
    }

    public void exitGame()
    {
        SceneManager.LoadScene(0);
    }
}
