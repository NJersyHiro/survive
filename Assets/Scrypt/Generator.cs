using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour {

	public GameObject Player;
	public GameObject EnemyPrefab;
	public GameObject AttackPrefab;
	public GameObject attack20;
	GameObject[] tagObjects;
	public PlayerControllerTest playerController; 
	private float RepNum = 1.0f;

	void Start(){
		//InvokeRepeating("EnemyGenerate", 0, RepNum);
		InvokeRepeating("AttackGenerate", 0, 3.0f);
		Player = GameObject.Find ("Player");
		playerController = Player.GetComponent<PlayerControllerTest> ();
		EnemyGenerate ();
		Ready();
	}

	void EnemyGenerate(){
		bool gameover = playerController.isGameOver;
		if (gameover == false) {
			GameObject newEnemy = (GameObject)Instantiate (EnemyPrefab) as GameObject;
			Vector3 playerPos = Player.transform.position;
			float x = playerPos.x + Random.Range (3.0f, 6.0f);
			float y = playerPos.y + Random.Range (3.0f, 6.0f);
			int num = Random.Range(1,5);
			if(num == 1){
				newEnemy.transform.position = new Vector2 (x, y);
			}
			if(num == 2){
				newEnemy.transform.position = new Vector2 (-x, y);
			}
			if(num == 3){
				newEnemy.transform.position = new Vector2 (x, -y);
			}
			if(num == 4){
				newEnemy.transform.position = new Vector2 (-x, -y);
			}

		}
	}

	void AttackGenerate(){
		int num = Random.Range (1, 3);
		if (num == 1) {			
			tagObjects = GameObject.FindGameObjectsWithTag ("AttackTag");
			bool gameover = playerController.isGameOver;
			if (gameover == false && tagObjects.Length <= 1 && tagObjects != null) {
				GameObject newAttack = (GameObject)Instantiate (AttackPrefab) as GameObject;
				float x = Random.Range(-7.0f, 7.0f);
				float y = Random.Range(-4.0f, 4.0f);
				newAttack.transform.position = new Vector2(x,y);

			}
		}
		if (num == 2) {
			tagObjects = GameObject.FindGameObjectsWithTag ("AttackTag2");
			bool gameover = playerController.isGameOver;
			if(gameover == false && tagObjects.Length <= 1 && tagObjects != null){
				GameObject newAttack = (GameObject)Instantiate (attack20) as GameObject;
				float x = Random.Range(-7.0f, 7.0f);
				float y = Random.Range(-4.0f, 4.0f);
				newAttack.transform.position = new Vector2(x,y);

			}	
		}
	}

	void Ready(){
		if (RepNum >= 0.3) {
			RepNum -= 0.02f;
		}
		Invoke ("Ready", RepNum);
		EnemyGenerate ();

	}

}