using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BallManager : MonoBehaviour {

	public GameObject ball;
	// Use this for initialization

	void Awake () {
		WhiteBall.OnHitPong += WhiteBall_OnHitPong;
		GameManager.OnGameOver += GameManager_OnGameOver;
	}

	void GameManager_OnGameOver ()
	{
		CancelInvoke ();
	}

	void OnDestroy()
	{
		WhiteBall.OnHitPong -= WhiteBall_OnHitPong;
		GameManager.OnGameOver -= GameManager_OnGameOver;
	}
		
	void Start () 
	{
		//Invoke ("addBall", 2);
		InvokeRepeating ("addBall", 0, 0.2f);
	}

	public void excuateInSeconds(Action action, float seconds)
	{
		StartCoroutine (delayStart(seconds, action));
	}

	IEnumerator delayStart(float delay, Action action)
	{
		yield return new WaitForSeconds(delay);
		action ();
	}

	// Update is called once per frame
	void Update () {
		
	}

	public void burst()
	{
		InvokeRepeating ("addBall", 0, 0.2f);
	}

	public void addBall()
	{
		GameObject go = Instantiate(ball, Vector3.zero, Quaternion.identity);
		WhiteBall whiteBall= go.GetComponent<WhiteBall> ();
		whiteBall.enterGameWithSpeed (5);
	}

	void WhiteBall_OnHitPong ()
	{

	}
}
