using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour {

	public GameObject Player;
	public GameObject EnemyPrefab;
	public GameObject AttackPrefab;


	void Start(){
		InvokeRepeating("Generate", 0, 1);
		InvokeRepeating ("AttackGenerate", 0, 5);
		Player = GameObject.Find ("Player");
	
	}

	void Generate(){
		if(Player != null){
		
		GameObject newEnemy = (GameObject)Instantiate (EnemyPrefab) as GameObject;
		float playerx = Player.transform.position.x;
		float playery = Player.transform.position.y;
		playerx += 2.0f;
		playery += 2.0f;
		int num = Random.Range (1, 3);
		if(num == 1){
			float x = Random.Range(-7.5f, 7.5f);
			float y = Random.Range(playery, 5.0f);
			newEnemy.transform.position = new Vector2(x,y);
		}
		if(num == 2){
			float x = Random.Range(-7.5f, 7.5f);
			float y = Random.Range(-5.0f, -playery);
			newEnemy.transform.position = new Vector2(x,y);
		}
		}
	}

	void AttackGenerate(){
		if(Player != null){
		GameObject newAttack = (GameObject)Instantiate (AttackPrefab) as GameObject;
		float x = Random.Range(-7.5f, 7.5f);
		float y = Random.Range(-5.0f, 5.0f);
		newAttack.transform.position = new Vector2(x,y);

		}
	}
}