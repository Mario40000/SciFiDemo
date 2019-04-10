using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookY : MonoBehaviour
{

    //variables
    public float sensitivity = 0.0f;
    
    void FixedUpdate()
    {
        float _mouseY = Input.GetAxis("Mouse Y");
        Vector3 newRotation = transform.localEulerAngles;
        //Miramos hacia  arriba y hacia abajo
        newRotation.x -= _mouseY * sensitivity;
        transform.localEulerAngles = newRotation;
    }
}
