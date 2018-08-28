using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour {

	private bool buttonpush = false;

	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update () {
		if (buttonpush){
			//GameSceneを読み込む（追加）
			Debug.Log("button pushed");
			SceneManager.LoadScene ("GameScene");
		}
	}


	public void Buttonpush() {
		this.buttonpush = true;
	}
}