using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    //Variables
    public Text ammoText;
    public Text pickText;

    private void Start()
    {
        pickText.text = "";
    }

    public void UpdateAmmo (int count, int total)
    {
        ammoText.text = "Bullets: " + count.ToString() + " / " + total.ToString();
    }

}
