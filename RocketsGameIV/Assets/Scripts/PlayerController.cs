using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    private float movementX;
    private float movementY;
    public float startSpeed = 75;
    public float speed;
    private int count;

    public bool isDash = false;
	public float coolDownTime = .5f;
	private float theTime1;
	private float theTime2;
	private bool boosted;

	private int dashNumber = 0;

	private bool Finished = false;

	public TextMeshProUGUI PlaceText;
    public GameObject Opponent;

    void Start()

    {
        rb = GetComponent<Rigidbody>();
        count = 0;
    }

    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        movementX = movementVector.x;
        movementY = movementVector.y;

    }

    void FixedUpdate()
    {
    	if (isDash == true){
			speed = startSpeed + 20 * dashNumber;
			boosted = true;
		}
		else{
			speed = startSpeed;
			dashNumber = 0;
		}

 		if (boosted == true){
 			StartCoroutine(DashDuration());
 		}	

 		Vector3 PositionNPC = GameObject.Find("RatBastard").transform.position;
 		Vector3 PositionPlayer = GameObject.Find("rocket").transform.position;
 		if (PositionNPC.x >= PositionPlayer.x){
 			PlaceText.text = "1st";
 		}
 		else {
 			PlaceText.text = "2nd";
 		}

 		if (Finished == false){
        	Vector3 movement = new Vector3(-3f, 
        				movementY * 2.5f, movementX * 2.5f);
        	rb.AddForce(movement * speed);
    	}

    	else if (Finished == true && PlaceText.text == "1st"){
    		PlaceText.text = "You win!";
    	}
    	else {
    		PlaceText.text = "You lose!";
    	}

	}   
	
	void OnTriggerEnter(Collider other)
	    {
	        if (other.CompareTag("Booster"))
	        {
	           isDash = true;
	           dashNumber++;
	        }
	        else if (other.CompareTag("Finish Line")){
	        	Finished = true;
	        }
	    }


	IEnumerator DashDuration(){
		yield return new WaitForSeconds(coolDownTime);
		isDash = false;
		boosted = false;
	}


}
