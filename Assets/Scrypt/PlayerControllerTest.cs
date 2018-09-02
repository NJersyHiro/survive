﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControllerTest : MonoBehaviour {

	public Rigidbody2D rb;
	public float movespeed = 10.0f;
	private GameObject gameoverText;
	private GameObject Play;
	public bool isGameOver = false;
	public Vector3 dir;
	//private AudioSource audioSource;


	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		gameoverText = GameObject.Find ("GameOverText");
		Play = GameObject.Find ("Play");
		Play.SetActive (false);
		//audioSource = gameObject.GetComponent<AudioSource> ();
	//	audioSource.PlayOneShot(audioSource.clip);

		//Vector3 initpos = new Vector3 (0, 20, 0);
		//this.transform.LookAt(initpos);
		//this.transform.rotation = Quaternion.Euler (49,39,29);
	}


	//敵い衝突時破壊されてゲームオーバーを表示
	void OnCollisionEnter2D(Collision2D col){
		if (col.gameObject.tag == "EnemyTag" || col.gameObject.tag == "WallTag") {
			//audioSource.Play();
			//audioSource.PlayOneShot(audioSource.clip);

			//AudioSource.PlayClipAtPoint(dead, transform.position);
			gameObject.SetActive (false);
			gameoverText.GetComponent<Text> ().text = "Game Over";
			Play.SetActive (true);
			isGameOver = true;
			//audioSource.PlayOneShot(audioSource.clip);

		}
		/*
		if (col.gameObject.tag == "AttackTag") {
			Debug.Log ("boll");
			audioSource.PlayOneShot(audioSource.clip);

		}
*/
	}

			

	//移動させるスクリプト
	void FixedUpdate()
	{
		/*
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, moveVertical, 0.0f);
		this.rb.AddForce (movement * movespeed);
		*/

		dir = Vector3.zero;
		dir.x = Input.acceleration.x;
		dir.y = Input.acceleration.y;
		if (dir.sqrMagnitude > 1) {
			dir.Normalize ();
		}
		dir *= Time.deltaTime;
		transform.Translate (dir * movespeed);


		//var vec = rb.velocity.normalized;
		//var vec = dir.normalized;
		//var angle = (Mathf.Atan2(vec.y, vec.x) * Mathf.Rad2Deg) - 90.0f;
		/*
		var angle = (Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg) - 90.0f;
		transform.rotation = Quaternion.Euler(0.0f, 0.0f, angle);
		*/
	}

		
}