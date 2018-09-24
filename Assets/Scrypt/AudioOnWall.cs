using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioOnWall : MonoBehaviour {

	GameObject Player;
	private AudioSource audioSource;

	// Use this for initialization
	void Start () {
		audioSource = gameObject.GetComponent<AudioSource> ();

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.tag == "PlayerRepel") {
			audioSource.PlayOneShot(audioSource.clip);


		}
	}


}
