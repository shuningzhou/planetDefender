using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
	
	public delegate void onGameOver();
	public static event onGameOver OnGameOver;

	public GameObject yellowCircle;
	public GameObject greenCircle;
	public GameObject greenCircle2;
	public SpriteRenderer greenSprite;
	public Color startColor;
	public Color finalColor;
	Vector2 newScale = new Vector2();
	public bool gameOver = false;

	float lerpSpeed = 10;
	float greenLerpSpeed = 0.2f;

	public pong plank;

	void Awake () {
		WhiteBall.OnHitPong += WhiteBall_OnHitPong;
		WhiteBall.OnFailed += WhiteBall_OnFailed;
	}

	void OnDestroy()
	{
		WhiteBall.OnHitPong -= WhiteBall_OnHitPong;
		WhiteBall.OnFailed += WhiteBall_OnFailed;
	}

	// Use this for initialization
	void Start () {
		newScale = yellowCircle.transform.localScale;
	}

	// Update is called once per frame
	void Update () 
	{
//		yellowCircle.transform.localScale = Vector2.Lerp(yellowCircle.transform.localScale, newScale, lerpSpeed * Time.deltaTime);
//		greenCircle.transform.localScale = Vector2.Lerp(greenCircle.transform.localScale, Vector2.zero, greenLerpSpeed * Time.deltaTime);
//		greenSprite.color = Color.Lerp (greenSprite.color, finalColor,Time.deltaTime*(greenLerpSpeed));
//
//		if (greenCircle.transform.localScale.x < 10 && !gameOver) 
//		{
//			BallManager bm = GameObject.FindObjectOfType<BallManager> ();
////			bm.addBall ();
//			greenCircle.transform.localScale = new Vector2 (150, 150);
//			greenSprite.color = startColor;
//			greenLerpSpeed = Random.Range (0.05f,0.2f);
//		}
	}

	void WhiteBall_OnHitPong ()
	{
//		yellowCircle.transform.localScale = new Vector2 (yellowCircle.transform.localScale.x +5, yellowCircle.transform.localScale.y +5);
		//newScale = new Vector2 (newScale.x + 7, newScale.y + 7);
	}

	void WhiteBall_OnFailed ()
	{
//		newScale = new Vector2 (newScale.x - 50, newScale.y - 50);
//		if (newScale.x/2 <= 150) {
//			greenCircle.gameObject.SetActive (false);
//			greenCircle2.gameObject.SetActive (false);
//			newScale = Vector2.zero;
//			gameOver = true;
//			plank.gameObject.SetActive (false);
//			lerpSpeed = 2;
//			if (OnGameOver != null)
//			{
//				OnGameOver ();
//			}
//		}
	}
}
