using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Top : MonoBehaviour {

	//float top = 0;
	float top = 0.0f;
	GameObject Level;
	public LevelController levelController; 
	private string key = "Top"; //ハイスコアの保存先キー


	// Use this for initialization
	void Start () {
		top = PlayerPrefs.GetFloat(key, 0.0f);

		Level = GameObject.Find ("Level");
		levelController = Level.GetComponent<LevelController> ();
		GetComponent<Text>().text = "TOP" + top.ToString("N0");
	}

	// Update is called once per frame
	void Update () {
		float level = levelController.level;

		if(levelController.level > top){
			top = level;
			PlayerPrefs.SetFloat(key, top);
			GetComponent<Text>().text = "TOP" + top.ToString("N0");
		}

	}
}
