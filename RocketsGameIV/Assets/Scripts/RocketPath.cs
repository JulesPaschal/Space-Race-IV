
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RocketPath : MonoBehaviour {

    public Transform StartingLine;
    public Transform Waypoint1;
    public Transform Waypoint2;
    public Transform Waypoint3;
    public Transform Waypoint4;
    public Transform Waypoint5;
    public Transform Waypoint6;
    public Transform Waypoint7;
    public Transform Waypoint8;
    public Transform Waypoint9;
    public Transform Waypoint10;
    public Transform Waypoint11;
    public Transform Waypoint12;
    public Transform Waypoint13;
    public Transform Finishline;

    private Transform currentLoc;
    private Transform nextLoc;

    public float moveSpeed = 2f;
    public float rotationSpeed = 5f;
    public Vector3 offset;
    public Rigidbody rb;

   

    void Start(){
       // rb = GetComponent ();
        currentLoc = StartingLine;
        transform.position = currentLoc.position;
        nextLoc = Waypoint1;
        moveShip();
    }

    void Update(){
    //LERP rotation
       Vector3 relativePos = nextLoc.position - transform.position;
       Quaternion toRotation = Quaternion.LookRotation(relativePos);
       transform.rotation = Quaternion.Lerp( transform.rotation, toRotation, rotationSpeed * Time.deltaTime );

    //LERP movement
        Vector3 newPos = nextLoc.position + offset;
        Vector3 smoothPos = Vector3.Lerp (transform.position, newPos, moveSpeed * Time.deltaTime);
        transform.position = smoothPos;
    }

    public void OnTriggerEnter(Collider other){
        if (other.gameObject.layer == 9){
            Debug.Log("Hit a waypoint!");
            moveShip();
        }
    }

    public void moveShip(){
        //Transform ShipYard = transform.position;

        if (nextLoc == Waypoint1){ currentLoc = Waypoint1; nextLoc = Waypoint2; }
        else if (nextLoc == Waypoint2){ currentLoc = Waypoint2; nextLoc = Waypoint3; }
        else if (nextLoc == Waypoint3){ currentLoc = Waypoint3; nextLoc = Waypoint4; }
        else if (nextLoc == Waypoint4){ currentLoc = Waypoint4; nextLoc = Waypoint5; }
        else if (nextLoc == Waypoint5){ currentLoc = Waypoint5; nextLoc = Waypoint6; }
        else if (nextLoc == Waypoint6){ currentLoc = Waypoint6; nextLoc = Waypoint7; }
        else if (nextLoc == Waypoint7){ currentLoc = Waypoint7; nextLoc = Waypoint8; }
        else if (nextLoc == Waypoint8){ currentLoc = Waypoint8; nextLoc = Waypoint9; }
        else if (nextLoc == Waypoint9){ currentLoc = Waypoint9; nextLoc = Waypoint10; }
        else if (nextLoc == Waypoint10){ currentLoc = Waypoint10; nextLoc = Waypoint11; }
        else if (nextLoc == Waypoint11){ currentLoc = Waypoint11; nextLoc = Waypoint12; }
        else if (nextLoc == Waypoint12){ currentLoc = Waypoint12; nextLoc = Waypoint13; }
        else if (nextLoc == Waypoint13){ currentLoc = Waypoint13; nextLoc = Finishline; }
        else if (nextLoc == Finishline){ currentLoc = Finishline; }
        //transform.LookAt (nextLoc);
        Debug.Log("leaving: " + currentLoc + "\n heading towards:" + nextLoc);
    }
}

//research: https://youtu.be/RkrC0PopskM
// A* algorithm