using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSprite : MonoBehaviour {
	public GameObject Player;
	public PlayerControllerTest playerController;
	public Vector3 vec = Vector3.zero;

	// Use this for initialization
	void Start () {
		Player = GameObject.Find ("Player");
		playerController = Player.GetComponent<PlayerControllerTest> ();
	}
	
	// Update is called once per frame
	void Update () {
		vec = playerController.dir;
			var angle = (Mathf.Atan2(vec.y, vec.x) * Mathf.Rad2Deg) - 90.0f;
		transform.rotation = Quaternion.Euler(0.0f, 0.0f, angle);

	}
}
