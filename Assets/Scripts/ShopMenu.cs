using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class ShopMenu : MonoBehaviour
{
    public GameObject player;
    public GameObject shop;

    public void exitShop()
    {
        player.SetActive(true);
        shop.SetActive(false);
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
