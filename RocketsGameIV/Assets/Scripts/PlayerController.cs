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
	private bool newLapVar = false;
	private int lapNum = 1;

	public TextMeshProUGUI PlaceText;
    public GameObject Opponent1;
    public GameObject Opponent2;

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
    	Vector3 PositionPlayer = this.transform.position;

    	Quaternion RotationPlayer = this.transform.rotation;
    	RotationPlayer.x = 0;
    	RotationPlayer.y = 0;
    	RotationPlayer.z = 0;
    	
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

		Vector3 PositionNPC = Opponent1.transform.position;
		Vector3 PositionNPC2 = Opponent2.transform.position;
 		
 		if (PositionNPC.x >= PositionPlayer.x && PositionNPC2.x >= PositionPlayer.x){
 			PlaceText.text = "1st";
 		}
 		else if ((PositionNPC.x <= PositionPlayer.x && PositionNPC2.x >= PositionPlayer.x)) {
 			PlaceText.text = "2nd";
 		}
 		else if ((PositionNPC.x >= PositionPlayer.x && PositionNPC2.x <= PositionPlayer.x)) {
 			PlaceText.text = "2nd";
 		}
 		else {
 			PlaceText.text = "3rd";
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
	        else if (other.CompareTag("Obstacle"))
	        {
	            speed = speed - 10;
	            
    			Debug.Log("CORNCH");
	        }
	        else if (other.CompareTag("Finish Line")){
	        	if (lapNum == 3){
	        		Finished = true;
	        	}
	        	else {
	        		newLapVar = true;
	        		newLap();
	        		Debug.Log("newLap, according to on trigger enter");
	        		lapNum++;
	        	}
	        }
	    }

	void newLap(){
		//Vector3 PositionPlayer = this.transform.position;
		Vector3 restartLoc = new Vector3 (0, 0, 0);
    	if (newLapVar == true){
    		this.transform.position = restartLoc;
    		newLapVar = false;
    		Debug.Log("newLap, according to new lap");
    	}

	}
	IEnumerator DashDuration(){
		yield return new WaitForSeconds(coolDownTime);
		isDash = false;
		boosted = false;
	}


}
