using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouseLook : MonoBehaviour
{
    //float to modify mouse sensitivity
    public float mouseSensitivity = 100f;
    //Transform to link player 3D object to mouseLook script
    public Transform playerBodyUp;
    public Transform playerBodyRight;
    //float to track rotation of camera around X axis
    float xRotation = 0f;
    float yRotation = 0f;

    void Start()
    {
        //hide the cursor and keep it in the center of the screen
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        //take input from mouse movement on X and Y axes, multiply by
        //sensitivity and tie it to deltaTime instead of framerate
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        //camera rotation around the x axis is controlled by the mouse,
        //subtracted from the default rotation which is 0
        xRotation -= mouseY;
        yRotation += mouseX;

        //rotates the camera around the x axis independent of the player object
        transform.localRotation = Quaternion.Euler(xRotation, yRotation, 0f);

        playerBodyRight.Rotate(Vector3.left * mouseY);
        //rotates the camera and player object together around the y axis
        playerBodyUp.Rotate(Vector3.up * mouseX);

    }
}
