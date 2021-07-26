using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShopScript : MonoBehaviour
{
    public GameObject player;
    public GameObject shop;
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
        if(other.gameObject.tag == "Player" && Input.GetKeyDown(KeyCode.E))
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            shop.SetActive(true);
            player.SetActive(false);

        }
    }
}
