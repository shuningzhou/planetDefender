using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour {
	
	void Awake () {
		WhiteBall.OnHitPong += WhiteBall_OnHitPong;
	}

	void OnDestroy()
	{
		WhiteBall.OnHitPong -= WhiteBall_OnHitPong;
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void WhiteBall_OnHitPong ()
	{
		Animator a = GetComponent<Animator> ();
		a.SetTrigger ("shake");
	}
}
