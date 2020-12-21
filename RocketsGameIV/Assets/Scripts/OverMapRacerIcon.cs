using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverMapRacerIcon : MonoBehaviour
{
	public Transform racer;

    void Start(){
		gameObject.transform.position = new Vector3(racer.position.x, transform.position.y, racer.position.z);
    }
		
	void Update(){
		gameObject.transform.position = new Vector3(racer.position.x, transform.position.y, racer.position.z);
    }
}
