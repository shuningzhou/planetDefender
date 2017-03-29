using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public Rigidbody2D rb;

	void Update ()
	{
		if (Input.GetButtonDown("Play"))
		{
			rb.bodyType = RigidbodyType2D.Dynamic;
		}
	}

	void OnCollisionEnter2D(Collision2D coll) 
	{
		if (coll.gameObject.tag == "Hole") 
		{
			Destroy (coll.gameObject);
			Destroy (gameObject);
		}

	}

}
