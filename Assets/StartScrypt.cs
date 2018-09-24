using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScrypt : MonoBehaviour {

	private GameObject Resume;
//	private string key = "StartScrypt";
	private GameObject Tutorial;

	// Use this for initialization
	void Start () {

		Resume = GameObject.Find ("Resume");
		Tutorial = GameObject.Find ("Tutorial");
		Resume.SetActive (false);
		Tutorial.SetActive (false);
		if (!PlayerPrefs.HasKey ("Init")) { // "Init"のキーが存在しない場合はチュートリアルパネルを表示
			SaveDataInitialize (); // セーブデータを初期化
			Time.timeScale = 0;
//		if (number != 1) {
//			number = PlayerPrefs.GetFloat (key, 0.0f);
//			PlayerPrefs.SetFloat (key, 0.0f);
//		}
			Resume.SetActive (true);
			Tutorial.SetActive (true);
		}

	}

	void SaveDataInitialize(){
		PlayerPrefs.SetInt("Init", 1); // ”Init”のキーをint型の値(1)で保存
		// PlayerPrefs.SetInt("Score", 0);
	}
	
	// Update is called once per frame
	void Update () {
//		if (number == 0.0f) {
//			Resume.SetActive (true);
//			Tutorial.SetActive (true);
//			Time.timeScale = 0;
//			PlayerPrefs.SetFloat (key, 1.0f);
		
//		}
//		Debug.Log (number);
	}
}
