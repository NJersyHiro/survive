using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

	GameObject Player;
	public float Speed;
	public PlayerControllerTest playerController; 

	// Use this for initialization
	void Start () {
		Player = GameObject.Find ("Player");
		if (Player != null) {
			playerController = Player.GetComponent<PlayerControllerTest> ();
	
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