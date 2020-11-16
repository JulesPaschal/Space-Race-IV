
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour

{
    public CharacterController controller;

    public float speed = 12f;
    
    void Update()
    {
        float X = UnityEngine.Input.GetAxis("Horizontal");
        float Z = UnityEngine.Input.GetAxis("Vertical");

        //this is supposed to allow movement local to the player object so that
        //turning will adjust the absolute direction that pressing W would take
        //you, however it is not doing that
        Vector3 move = transform.right * X + transform.forward * Z;
        controller.Move(move * speed * Time.deltaTime);

    }
}
