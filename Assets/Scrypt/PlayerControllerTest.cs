using System.Collections;
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
	public GameObject Shot;
	private AudioSource audioSource;
	public GameObject PlayerSprite2;
	//Vector2 direction = Vector2.zero;



	// Use this for initialization
	void Start () {
		PlayerSprite2 = GameObject.FindWithTag ("PlayerAttract");
		rb = GetComponent<Rigidbody2D> ();
		gameoverText = GameObject.Find ("GameOverText");
		Play = GameObject.Find ("Play");
		Play.SetActive (false);
		audioSource = gameObject.GetComponent<AudioSource> ();

	}


	//敵い衝突時破壊されてゲームオーバーを表示
	void OnTriggerEnter2D(Collider2D col){
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
	
		if (col.gameObject.tag == "AttackTag2") {
			Destroy (col.gameObject);
			Invoke ("Shoot", 1);
		}
			//var heading = col.transform.position - this.transform.position;
			//var distance = heading.magnitude;
			//var direction = heading / distance; // This is now the normalized direction.

			//Vector3 normal = (col.transform.position - this.transform.position).normalized; 
	}

	void Shoot(){
			if (PlayerSprite2 != null) {
				Debug.Log ("ガッ");

				GameObject shoot = (GameObject)Instantiate (Shot) as GameObject;
				shoot.transform.position = this.transform.position;
				//float x = rb.transform.position.x;
				//float y = rb.transform.position.y;
				//shoot.transform.position = new Vector2 (x, y);
				var angle = (Mathf.Atan2 (dir.y, dir.x) * Mathf.Rad2Deg);
				shoot.transform.rotation = Quaternion.Euler (0.0f, 0.0f, angle);


				//Vector2 direction = new Vector2 (Input.acceleration.x, Input.acceleration.y);
				//Vector3 direction = rb.velocity.normalized;
				//shoot.GetComponent<Rigidbody2D>().velocity = direction * movespeed;
				//shoot.GetComponent<Rigidbody2D>().velocity = normal * 10f;
				dir = Vector2.zero;
				dir.x = Input.acceleration.x;
				dir.y = Input.acceleration.y;

				shoot.GetComponent<Rigidbody2D>().velocity = dir.normalized * 10f;

				//float x = PlayerSprite2.GetComponent<Transform> ().position.x;
				//float y = PlayerSprite2.GetComponent<Transform> ().position.y;

				//Vector2 target = new Vector2 (x, y).normalized;
				Destroy (shoot, 3.0f);  
				audioSource.PlayOneShot (audioSource.clip);
				Physics2D.IgnoreCollision (shoot.GetComponent<Collider2D> (), GetComponent<Collider2D> ());
			}

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

	/*
	public void Shoot(){
		if (PlayerSprite2 != null) {
			Debug.Log ("ガッ");

			GameObject shoot = (GameObject)Instantiate (Shot) as GameObject;
			shoot.transform.position = this.transform.position;
			//float x = rb.transform.position.x;
			//float y = rb.transform.position.y;
			//shoot.transform.position = new Vector2 (x, y);
			var angle = (Mathf.Atan2 (dir.y, dir.x) * Mathf.Rad2Deg);
			shoot.transform.rotation = Quaternion.Euler (0.0f, 0.0f, angle);


			//Vector2 direction = new Vector2 (Input.acceleration.x, Input.acceleration.y);
			//Vector3 direction = rb.velocity.normalized;
			//shoot.GetComponent<Rigidbody2D>().velocity = direction * movespeed;
			shoot.GetComponent<Rigidbody2D>().velocity = normal * 10f;
			//float x = PlayerSprite2.GetComponent<Transform> ().position.x;
			//float y = PlayerSprite2.GetComponent<Transform> ().position.y;
	
			//Vector2 target = new Vector2 (x, y).normalized;
			Destroy (shoot, 3.0f);  
			audioSource.PlayOneShot (audioSource.clip);
			Physics2D.IgnoreCollision (shoot.GetComponent<Collider2D> (), GetComponent<Collider2D> ());
		}
	}

*/
}