using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelController : MonoBehaviour {

	float countTime = 0;
	GameObject Player;
	public PlayerControllerTest playerController; 
	public float level;


	// Use this for initialization
	void Start () {
		Player = GameObject.Find ("Player");
		playerController = Player.GetComponent<PlayerControllerTest> ();

	}
	
	// Update is called once per frame
	void Update () {
		bool gameover = playerController.isGameOver;
		countTime += Time.deltaTime; //スタートしてからの秒数を格納
		if(countTime >= 5){
			if(gameover == false){
				level = countTime / 5;
				GetComponent<Text> ().text = "Level" + level.ToString ("N0");
			}

		}

	}
}
