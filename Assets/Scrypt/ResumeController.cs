using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ResumeController : MonoBehaviour {
//	public AudioClip push;
	private GameObject Resume;
	private GameObject Tutorial;

	// Use this for initialization
	void Start () {
		Resume = GameObject.Find ("Resume");
		Tutorial = GameObject.Find ("Tutorial");

	}

	// Update is called once per frame
	void Update () {
	}


	public void Buttonpush() {
		Time.timeScale = 1;
		Resume.SetActive (false);
		Tutorial.SetActive (false);
//		GetComponent<AudioSource> ().Play();

	}

}