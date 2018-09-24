using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour {
	public AudioClip push;
	public float delay = 0.2f;
	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update () {
	}


	public void Buttonpush() {
		Time.timeScale = 1;
		GetComponent<AudioSource> ().Play();
		Invoke ("Load", delay);
		//GameObject.FindObjectOfType<AudioSource>().Play();
		Debug.Log("Playpushed");
	}

	void Load(){
		SceneManager.LoadScene ("GameScene");
	}
}