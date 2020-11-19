
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
        else if (nextLoc == Waypoint7){ currentLoc = Waypoint7; nextLoc = StartingLine; }
        else if (currentLoc == StartingLine){ nextLoc = Waypoint1; }

        //transform.LookAt (nextLoc);
        Debug.Log("leaving: " + currentLoc + "\n heading towards:" + nextLoc);
    }
}

//research: https://youtu.be/RkrC0PopskM
// A* algorithm