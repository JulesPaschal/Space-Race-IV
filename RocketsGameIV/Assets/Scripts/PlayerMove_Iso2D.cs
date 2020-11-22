using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// public class PlayerMove_Iso2D : MonoBehaviour {

// 	public float startSpeed = 5f;
// 	public float speed; // player movement speed

// 	private Vector3 change; // player movement direction
// 	private Rigidbody2D rb2d;
// 	//private Animator animator;

// 	public bool isDash = false;

// 	public float coolDownTime = 3f;
// 	private float theTime1;
// 	private float theTime2;
// 	private bool boosted;

// 	void Start () {
// 		//animator = GetComponent<Animator>();
// 		rb2d = GetComponent<Rigidbody2D>();
// 		speed = startSpeed;
// 	}

// 	void Update() {
// 		change = Vector3.zero;
// 		change.x = Input.GetAxisRaw("Horizontal");
// 		change.y = Input.GetAxisRaw("Vertical");
// 		UpdateAnimationAndMove();
// 	}

// 	void FixedUpdate(){
// 		if (boosted == true){
// 			StartCoroutine(DashDuration());
// 		}
// 	}

// 	void UpdateAnimationAndMove() {
// 		if (change!=Vector3.zero) {
// 			MoveCharacter();
// 			//animator.SetFloat("moveX", change.x);
// 			//animator.SetFloat("moveY", change.y);
// 			//animator.SetBool("moving", true);
// 		} else {
// 			//animator.SetBool("moving", false);
// 		}
// 	}

// 	void MoveCharacter() {
// 		if (isDash == true){
// 			speed = startSpeed * 10;
// 			boosted = true;
// 		}
// 		else{
// 			speed = startSpeed;
// 		}
// 		rb2d.MovePosition(transform.position + change * speed * Time.deltaTime);
// 	}


// 	IEnumerator DashDuration(){
// 		yield return new WaitForSeconds(coolDownTime);
// 		isDash = false;
// 		boosted = false;
// 	}
// }
