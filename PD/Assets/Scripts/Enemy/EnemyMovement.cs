using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void enterGameWithSpeed(float speed, float spinRandomSeed)
	{		
		Vector2 n = gameObject.transform.position;
		Vector2 z = Vector2.zero;
		Vector2 d = z - n;
		Vector2 norm = d.normalized;

		Rigidbody2D rb = GetComponent<Rigidbody2D>();
		rb.velocity = norm * speed;

		rb.angularVelocity = Random.Range (-spinRandomSeed, spinRandomSeed);

		//		Invoke ("addTrail", 4);

	}
}
