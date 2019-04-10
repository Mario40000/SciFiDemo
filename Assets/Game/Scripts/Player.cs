using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //Variables
    private CharacterController _controller;

    public float playerSpeed = 0.0f;
    public float gravity = 0.0f;

	// Use this for initialization
	void Start ()
    {
        _controller = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        
	}

    private void FixedUpdate()
    {
        CalculateMovement();
    }

    //Metodo para el moviento del player
    void CalculateMovement ()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(horizontalInput, 0, verticalInput);
        Vector3 velocity = direction * playerSpeed;
        velocity.y -= gravity;
        //Tranformamos el movimiento a worldspace
        velocity = transform.transform.TransformDirection(velocity);
        _controller.Move(velocity * Time.deltaTime * playerSpeed);
    }
}
