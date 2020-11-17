
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerMovement : MonoBehaviour

{
    public CharacterController controller;

    public float speed = 12f;

    private Rigidbody rb;
    private float movementX;
    private float movementY;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        speed = 0;
    }


   
    void Update()
    {
        if (UnityEngine.Input.inputString == "Space"){
            float X = UnityEngine.Input.GetAxis("Horizontal");
            float Z = UnityEngine.Input.GetAxis("Vertical");

            //this is supposed to allow movement local to the player object so that
            //turning will adjust the absolute direction that pressing W would take
            //you, however it is not doing that
            Vector3 move = transform.right * X + transform.forward * Z;
            controller.Move(move * speed * Time.deltaTime);
        }

    }

     void FixedUpdate()
    {
        Vector3 movement = new Vector3(-1.0f, movementY, movementX);
        rb.AddForce(movement * speed);
    }
}
