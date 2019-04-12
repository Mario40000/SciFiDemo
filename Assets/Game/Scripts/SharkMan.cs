using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharkMan : MonoBehaviour
{
    //Variables
    private Player player;
    private bool playerIn = false;
    private UIManager uiManager;

    // Use this for initialization
    void Start ()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            playerIn = true;
            
            if (playerIn == true && player.coin == true)
            {
                uiManager.pickText.text = "If you want a gun, give me that coin pressing Space";
                if (Input.GetButtonDown("Jump"))
                {
                    gameObject.GetComponent<AudioSource>().Play();
                    player.coin = false;
                    player.hasGun = true;
                    uiManager.coinImage.SetActive(false);
                    player.gun.SetActive(true);
                }
            }
            else
            {
                uiManager.pickText.text = "get out of here!";
            }
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            playerIn = false;
            uiManager.pickText.text = "";
        }
    }
}
