using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomBomb : MonoBehaviour {

	public GameObject BombPrefab;
	public GameObject EnemyPrefab;
	public float RepNum = 0.2f;

	// Use this for initialization
	void Start () {
		InvokeRepeating ("Bomb", 1, 2);
		EnemyGenerate ();
		Ready();

		}
	
	// Update is called once per frame
	void Update () {
	}

	void Bomb(){
		GameObject newBomb = (GameObject)Instantiate (BombPrefab) as GameObject;
		float x = Random.Range (-8.0f, 8.0f);
		float y = Random.Range (-4.5f, 4.5f);
		newBomb.transform.position = new Vector2 (x, y);
		GameObject[] nodes = GameObject.FindGameObjectsWithTag("EnemyTag");
		//配列分繰り返す

		foreach (GameObject EnemyPrefab in nodes) {
			Vector3 nodePos = EnemyPrefab.transform.position;
			Vector3 bombPos = newBomb.transform.position;
			float dis = Vector3.Distance (nodePos, bombPos);

			if (dis < 3f) {
				GameObject.Destroy (EnemyPrefab);
			}
		}
	}

	void EnemyGenerate(){
		GameObject newEnemy = (GameObject)Instantiate (EnemyPrefab) as GameObject;
		float x = Random.Range (-8.0f, 8.0f);
		float y = Random.Range (-4.5f, 4.5f);
		newEnemy.transform.position = new Vector2 (x, y);
	}

	void Ready(){
		Invoke ("Ready", RepNum);
		EnemyGenerate ();

	}

	
}

