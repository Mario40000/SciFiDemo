using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookX : MonoBehaviour
{

    //variables
    public float sensitivity = 0.0f;
	
    void FixedUpdate ()
    {
        float _mouseX = Input.GetAxis("Mouse X");
        Vector3 newRotation = transform.localEulerAngles;
        //Miramos hacia  los lados
        newRotation.y += _mouseX * sensitivity;
        transform.localEulerAngles = newRotation;
    }
}
