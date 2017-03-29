using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhiteBall : MonoBehaviour {

	public delegate void hitPong();
	public static event hitPong OnHitPong;


	public delegate void failed();
	public static event failed OnFailed;


	public GameObject ps;
	public GameObject addScore;

	void Awake()
	{		
		TrailRenderer tr = GetComponent<TrailRenderer> ();
		tr.sortingOrder = -1;
	}
		
	// Update is called once per frame
	void Update () 
	{
		if (checkFailed()) {
			
			if (OnFailed != null)
			{
				OnFailed ();
			}

			reset ();
		}
	}

	public void enterGameWithSpeed(float speed)
	{		

		float rad = Random.Range (0, 2 * Mathf.PI);
		float x = 100 * Mathf.Cos (rad);
		float y = 100 * Mathf.Sin (rad);
		Vector2 n = new Vector2 (x, y);
		gameObject.transform.position = n;
		Vector2 z = Vector2.zero;
		Vector2 d = z - n;
		Vector2 norm = d.normalized;

		Rigidbody2D rb = GetComponent<Rigidbody2D>();
		rb.velocity = norm * speed;

		rb.angularVelocity = Random.Range (-50, 50);

//		Invoke ("addTrail", 4);

	}
		
	public bool checkFailed()
	{
		float distance = Vector2.Distance (gameObject.transform.position, Vector2.zero);
		if (distance < 10) {
			return true;
		}

		return false;
	}

	void reset()
	{
		Destroy (gameObject);
	}

	void OnCollisionEnter2D(Collision2D coll)
	{
		if (coll.gameObject.tag == "Pong")
		{
			if (ps) 
			{
				Instantiate (ps, coll.contacts [0].point, Quaternion.identity);
			}

			if (OnHitPong != null)
			{
				OnHitPong ();
			}

			if (addScore) 
			{
				Instantiate (addScore, coll.contacts [0].point, Quaternion.identity);
			}

			reset ();
		}
	}
}
