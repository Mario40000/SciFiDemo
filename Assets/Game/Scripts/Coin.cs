using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private Player player;
    private bool playerIn = false;
    private UIManager uiManager;

    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
    }

    private void Update()
    {
        
    }
    public void OnTriggerStay(Collider other)
    {
        Debug.Log("Collision");
        if (other.tag == "Player")
        {
            //player.CoinPick();
            //Destroy(gameObject);
            playerIn = true;
            uiManager.pickText.text = "Press Space to pick coin";
            if (playerIn)
            {
                if (Input.GetButtonDown("Jump"))
                {
                    player.CoinPick();
                    uiManager.pickText.text = "";
                    Destroy(gameObject);
                }
            }
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            playerIn = false;
            uiManager.pickText.text = "";
        }
    }


}
