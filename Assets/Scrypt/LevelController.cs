using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelController : MonoBehaviour {

	float countTime = 0;
		
	// Use this for initialization
	void Start () {



	}
	
	// Update is called once per frame
	void Update () {
		countTime += Time.deltaTime; //スタートしてからの秒数を格納
		if(countTime >= 5){
			float level = countTime/5;
			GetComponent<Text>().text = "Level" + level.ToString("N0");


		}

	}
}
