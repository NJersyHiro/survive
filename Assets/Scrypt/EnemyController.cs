using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

	GameObject Player;
	public float Speed;
	public PlayerControllerTest playerController; 
	private AudioSource audioSource;


	// Use this for initialization
	void Start () {
		audioSource = gameObject.GetComponent<AudioSource> ();
		Player = GameObject.Find ("Player");
		if (Player != null) {
			playerController = Player.GetComponent<PlayerControllerTest> ();
	
		}
	}

	void OnCollisionEnter2D(Collision2D col){
		if (col.gameObject.tag == "PlayerRepel") {
			audioSource.PlayOneShot(audioSource.clip);

		
		}
	}

	// Update is called once per frame
	void Update () {
		if(playerController != null){
			bool gameover = playerController.isGameOver;
		//	Debug.Log (gameover);
			if(gameover == false){
				this.transform.position = Vector2.MoveTowards (this.transform.position,new Vector2(Player.transform.position.x, Player.transform.position.y), Speed * Time.deltaTime);
			}
		}
	}
}