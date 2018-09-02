using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Start : MonoBehaviour {
	private Animator myAnimator;

	// Use this for initialization
	void StartScript () {
		this.myAnimator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		this.myAnimator.SetBool ("buttonAppear", false);

	}
}
