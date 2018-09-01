using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackController : MonoBehaviour {

	public GameObject Explosion;
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter2D(Collider2D col){
		if (col.CompareTag ("PlayerRepel")) {
			DestroyObject (gameObject);
			explosion ();
			DestroyObjectWithTag("EnemyTag");

		}

	}

	//指定したノードを全て消す関数
	public void DestroyObjectWithTag(string tagname){
		
		//配列にtagnameのタグを持つオブジェクトを格納する
		GameObject[] nodes = GameObject.FindGameObjectsWithTag(tagname);
		//配列分繰り返す

		foreach (GameObject node in nodes) {
			Vector3 nodePos = node.transform.position;
			Vector3 itemPos = this.transform.position;
			float dis = Vector3.Distance (nodePos, itemPos);

			if (dis < 5f) {
				GameObject.Destroy (node);
			}
		}
	}

	public void explosion(){
		GameObject Exploded = (GameObject)Instantiate (Explosion) as GameObject;
		Exploded.transform.position = gameObject.transform.position;
	}
}