using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControllerTest : MonoBehaviour {

	public Rigidbody2D rb;
	public float movespeed;
	private GameObject gameoverText;
	public Transform playergraphic;




	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		gameoverText = GameObject.Find ("GameOverText");
		InvokeRepeating ("debug", 1f, 1f);
		this.transform.rotation = Quaternion.Euler (0, 0, 0);
	
	}
		

	//敵い衝突時破壊されてゲームオーバーを表示
	void OnCollisionEnter2D(Collision2D col){
		if(col.gameObject.tag == "EnemyTag"){
			DestroyObject (gameObject);
			gameoverText.GetComponent<Text>().text = "Game Over";
		}

	}

	//移動させるスクリプト
	void FixedUpdate()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, moveVertical, 0.0f);
		this.rb.AddForce (movement * movespeed);

		//Vector3 dir = movement - transform.position;
		//float angle = Mathf.Atan2(dir.y,dir.x) * Mathf.Rad2Deg;
		//transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

		//Vector3 moveDirection = new Vector3 (moveHorizontal, moveVertical, 0);    
		//if (moveDirection != Vector3.zero) {
		//	Quaternion newRotation = Quaternion.LookRotation (moveDirection);
		//	playergraphic.transform.rotation = Quaternion.Slerp (playergraphic.transform.rotation, newRotation, Time.deltaTime * 8);


		if (movement != Vector3.zero) {
			// get the angle
			Vector3 norTar = (movement - transform.position).normalized;
			float angle = Mathf.Atan2 (norTar.y, norTar.x) * Mathf.Rad2Deg;
			// rotate to angle
			Quaternion rotation = new Quaternion ();
			rotation.eulerAngles = new Vector3 (0, 0, angle - 90);
			transform.rotation = rotation;
		}
	}

	void debug(){
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 moveDirection = new Vector3 (moveHorizontal, moveVertical, 0); 
		Vector3 diff = moveDirection - this.transform.position;

		Debug.Log (this.transform.position);
		Debug.Log (diff);

	}
}
