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
	public int lapNum = 1;

	public TextMeshProUGUI PlaceText;
	public TextMeshProUGUI LapText;
	public GameObject WinMenu;
	public GameObject LoseMenu;
    public GameObject Opponent1;
    public GameObject Opponent2;

    public int CourseSize;
	private int Opponent1Lap;
	private int Opponent2Lap;
	public AudioSource boostSound;

	private bool doneForReal = false;
	private int Place = 0;
	public ParticleSystem particles;



    void Start(){
		boostSound = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();
        count = 0;
		WinMenu.SetActive(false);
		LoseMenu.SetActive(false);
		particles.Stop();
    }

    void OnMove(InputValue movementValue)
    {
    	
        Vector2 movementVector = movementValue.Get<Vector2>();
        movementX = movementVector.x;
        movementY = movementVector.y;

    }

    void FixedUpdate()
    {
		if (Opponent1.GetComponent<NPC2Script>() != null){
			Opponent1Lap = Opponent1.GetComponent<NPC2Script>().lap;
		}
		else if (Opponent1.GetComponent<NPC3Script>() != null){
			Opponent1Lap = Opponent1.GetComponent<NPC3Script>().lap;
		}


			//Debug.Log("THE OPPONENT IS ON LAP #" + Opponent1Lap);
		if (CourseSize != 5000){

			if (Opponent2.GetComponent<NPC2Script>() != null){
				Opponent2Lap = Opponent2.GetComponent<NPC2Script>().lap;
			}
			else if (Opponent2.GetComponent<NPC3Script>() != null){
				Opponent2Lap = Opponent2.GetComponent<NPC3Script>().lap;
			}

		}

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

 		float PositionNPC = Opponent1.transform.position.x;
 		float PositionNPC2 = Opponent2.transform.position.x;
		
		if (Finished == false){
        	Vector3 movement = new Vector3(-3f, 
        				movementY * 2.5f, movementX * 2.5f);
        	rb.AddForce(movement * speed);
    

 		if ((PositionNPC >= PositionPlayer.x) && (PositionNPC2 >= PositionPlayer.x)
 		&& (Opponent1Lap <= lapNum) && (Opponent2Lap <= lapNum)){
 			PlaceText.text = "1st Place";
 			Place = 1;
 		}
 		else if ((PositionNPC <= PositionPlayer.x) && (PositionNPC2 >= PositionPlayer.x)
 			&& (Opponent1Lap >= lapNum) && (Opponent2Lap <= lapNum)) {
 			PlaceText.text = "2nd Place";
 			Place = 2;
 		}
 		else if ((PositionNPC >= PositionPlayer.x) && (PositionNPC2 <= PositionPlayer.x)
 			&& (Opponent1Lap <= lapNum) && (Opponent2Lap >= lapNum)) {
 			PlaceText.text = "2nd Place";
 			Place = 2;
 		}
 		else if ((PositionNPC <= PositionPlayer.x) && (PositionNPC2 <= PositionPlayer.x)
 			&& (Opponent1Lap >= lapNum) && (Opponent2Lap >= lapNum)) {
 			PlaceText.text = "3rd Place";
 			Place = 3;
 		}

 		}
 		
    	else if (doneForReal == true){
    		WinMenu.SetActive(true);
    		PlaceText.text = "You win!";
    	}
    	else if (Finished == true && Place == 1){
			WinMenu.SetActive(true);
    		PlaceText.text = "You win!";
    		doneForReal = true;
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
			   other.gameObject.GetComponent<RingColor>().PlayerBoost();
			   boostSound.Play(0);
	           isDash = true;
	           particles.Play();
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
		particles.Stop();
		boosted = false;
	}

	IEnumerator BoosterFlash(Renderer boosterRend){
		boosterRend.material.color = Color.red;
		Debug.Log("I made it red!");
		yield return new WaitForSeconds(0.2f);
		boosterRend.material.color = Color.white;
	}

}
