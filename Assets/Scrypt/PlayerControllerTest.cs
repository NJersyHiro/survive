using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControllerTest : MonoBehaviour {

	public Rigidbody2D rb;
	public float movespeed;
	private GameObject gameoverText;
	private GameObject Play;
	private bool isGameOver = false;
	private Animator myAnimator;



	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		gameoverText = GameObject.Find ("GameOverText");
		Play = GameObject.Find ("Play");
		Play.SetActive (false);
		this.transform.rotation = Quaternion.Euler (0, 0, 0);
		this.myAnimator = GetComponent<Animator>();
		this.myAnimator.SetBool ("explosion", false);
		Debug.Log ("explode reaedy");
	}


	//敵い衝突時破壊されてゲームオーバーを表示
	void OnCollisionEnter2D(Collision2D col){
		if(col.gameObject.tag == "EnemyTag"){
			DestroyObject (gameObject);
			gameoverText.GetComponent<Text>().text = "Game Over";
			Play.SetActive (true);
			isGameOver = true;
			this.myAnimator.SetBool ("explosion", true);
			Debug.Log ("exploded");
		}

	}

	//移動させるスクリプト
	void FixedUpdate()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, moveVertical, 0.0f);
		this.rb.AddForce (movement * movespeed);
		var vec = rb.velocity.normalized;
		var angle = (Mathf.Atan2(vec.y, vec.x) * Mathf.Rad2Deg) - 90.0f;
		transform.rotation = Quaternion.Euler(0.0f, 0.0f, angle);
	}
		
	void Update(){
		// ゲームオーバになった場合
		if (this.isGameOver == true){
		}
	}
}