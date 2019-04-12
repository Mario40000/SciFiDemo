using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructible : MonoBehaviour
{
    public GameObject crate;
	// Use this for initialization
	
    public void CrateDestroy()
    {
        Instantiate(crate, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
