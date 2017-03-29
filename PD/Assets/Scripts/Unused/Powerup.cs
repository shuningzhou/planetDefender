using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour {
	public float speed = 50;
	bool speedChanged = false;
	public GameObject ps;
	// Use this for initialization
	void Start () {
		float rad = Random.Range (0, 2 * Mathf.PI);
		Rigidbody2D rb = GetComponent<Rigidbody2D>();
		rb.velocity = new Vector2(speed * Mathf.Cos(rad), speed * Mathf.Sin(rad));
		rb.angularVelocity = Random.Range (-50, 50);
	}
	
	// Update is called once per frame
	void Update () 
	{
		checkScreenEdge ();
	}



	void checkScreenEdge()
	{
		
		Vector3 screenPos = Camera.main.WorldToScreenPoint(gameObject.transform.position);
		Rigidbody2D rb = GetComponent<Rigidbody2D>();
		Vector2 newVelocity = rb.velocity;

		if (screenPos.x > 0 && screenPos.x < Screen.width && screenPos.y > 0 && screenPos.y < Screen.height) 
		{
			speedChanged = false;
		}

		if (!speedChanged) 
		{
			if (screenPos.x < 0) 
			{
				newVelocity.x = -newVelocity.x;
				speedChanged = true;
			}

			if (screenPos.x > Screen.width) {
				newVelocity.x = -newVelocity.x;
				speedChanged = true;
			}

			if (screenPos.y < 0) {
				newVelocity.y = -newVelocity.y;
				speedChanged = true;
			}

			if (screenPos.y > Screen.height) {
				newVelocity.y = -newVelocity.y;
				speedChanged = true;
			}

			rb.velocity = newVelocity;
		}
	}

	void OnCollisionEnter2D(Collision2D coll)
	{
		print (coll.gameObject.tag);
		if (coll.gameObject.tag == "Pong")
		{
			if (ps) 
			{
				Instantiate (ps, coll.contacts [0].point, Quaternion.identity);
			}

			pong p = GameObject.FindObjectOfType<pong> ();
			p.increaseLength ();
			gameObject.SetActive (false);
			//Destroy (gameObject);
		}
	}
}
