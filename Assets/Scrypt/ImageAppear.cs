using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageAppear : MonoBehaviour {
/*
	GameObject TiltLeft;
	private SpriteRenderer sprite;

	// Use this for initialization
	void Start () {
		sprite = gameObject.GetComponent<SpriteRenderer> ();	
		InvokeRepeating ("Disappear", 1f, 1f);


	}
	
	// Update is called once per frame
	void Update () {
	}

	void Disappear(){
		sprite.enabled = false;
		Invoke ("Appear", 1.0f);
		Debug.Log ("disappeared");

	}

	void Appear(){
		sprite.enabled = true;
		Debug.Log ("appeared");

	}
}
*/


	public GameObject TiltLeftPrefab;

	void Start(){
		InvokeRepeating ("LeftGenerate", 0, 1f);

	}

	void LeftGenerate(){
		GameObject newLeft = (GameObject)Instantiate (TiltLeftPrefab) as GameObject;
		float x = 0f;
		float y = -2.5f;
		newLeft.transform.position = new Vector2 (x, y);
		Invoke ("Destroy", 1);
		
	}

	void Destroy(){
		GameObject.Destroy(TiltLeftPrefab);


	}
	/*

	public GameObject TiltLeft;

	void Start(){
	
	
	}
	*/
}