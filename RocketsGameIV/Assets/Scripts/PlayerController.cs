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
	public TextMeshProUGUI LapText;
	public GameObject WinMenu;
	public GameObject LoseMenu;
    public GameObject Opponent1;
    public GameObject Opponent2;

	public int Opponent1Lap;
	public AudioSource boostSound;




    void Start(){
		boostSound = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();
        count = 0;

		WinMenu.SetActive(false);
		LoseMenu.SetActive(false);
    }

    void OnMove(InputValue movementValue)
    {
    	
        Vector2 movementVector = movementValue.Get<Vector2>();
        movementX = movementVector.x;
        movementY = movementVector.y;

    }

    void FixedUpdate()
    {
		Opponent1Lap = Opponent1.GetComponent<NPC2Script>().lap;
		//Debug.Log("THE OPPONENT IS ON LAP #" + Opponent1Lap);

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

 		LapText.text = "Lap " + lapNum + "/3";

		Vector3 PositionNPC = Opponent1.transform.position;
		Vector3 PositionNPC2 = Opponent2.transform.position;
 		
 		if (PositionNPC.x >= PositionPlayer.x && PositionNPC2.x >= PositionPlayer.x){
 			PlaceText.text = "1st Place";
 		}
 		else if ((PositionNPC.x <= PositionPlayer.x && PositionNPC2.x >= PositionPlayer.x)) {
 			PlaceText.text = "2nd Place";
 		}
 		else if ((PositionNPC.x >= PositionPlayer.x && PositionNPC2.x <= PositionPlayer.x)) {
 			PlaceText.text = "2nd Place";
 		}
 		else {
 			PlaceText.text = "3rd Place";
 		}

 		
 		if (Finished == false){
        	Vector3 movement = new Vector3(-3f, 
        				movementY * 2.5f, movementX * 2.5f);
        	rb.AddForce(movement * speed);
    	}

    	else if (Finished == true && PlaceText.text == "1st"){
			WinMenu.SetActive(true);
    		PlaceText.text = "You win!";
    	}
    	else {
			LoseMenu.SetActive(true);
    		PlaceText.text = "You lose!";
    	}

	}   
	
	void OnTriggerEnter(Collider other)
	    {
	        if (other.CompareTag("Booster"))
	        {
			   boostSound.Play(0);
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
    	}

	}
	IEnumerator DashDuration(){
		yield return new WaitForSeconds(coolDownTime);
		isDash = false;
		boosted = false;
	}


}
