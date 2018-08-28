using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour {

	public GameObject Player;
	public GameObject EnemyPrefab;
	public GameObject AttackPrefab;
	GameObject[] tagObjects;

	void Start(){
		InvokeRepeating("EnemyGenerate", 0, 1);
		InvokeRepeating("AttackGenerate", 0, 5);
		Player = GameObject.Find ("Player");
	}

	void EnemyGenerate(){
		if(Player != null){
			GameObject newEnemy = (GameObject)Instantiate (EnemyPrefab) as GameObject;
			float x = Random.Range(-7.4f, 7.4f);
			float y = Random.Range(-4.9f, 4.9f);
			newEnemy.transform.position = new Vector2(x,y);

			/*Vector3 playerPos = Player.transform.position;
			float dis = Vector3.Distance (newEnemy.transform.position, playerPos);
		*/
		}
	}

	void Update(){
		tagObjects = GameObject.FindGameObjectsWithTag("AttackTag");
	}

	void AttackGenerate(){
		if(Player != null && tagObjects.Length <= 1){
		GameObject newAttack = (GameObject)Instantiate (AttackPrefab) as GameObject;
		float x = Random.Range(-7.5f, 7.5f);
		float y = Random.Range(-5.0f, 5.0f);
		newAttack.transform.position = new Vector2(x,y);
		}
	}
}