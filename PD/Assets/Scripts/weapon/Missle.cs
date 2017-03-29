using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missle : CanDestroy {

	public Damage damage;
	public float speed;
	public GameObject target;
	public Vector2 currentDirection;
	public bool isFree = false;

	// Update is called once per frame
	void Update () 
	{
		if (target == null && !isFree) 
		{
			isFree = true;
			lostTarget ();
			Rigidbody2D rb = GetComponent<Rigidbody2D>();
			rb.velocity = currentDirection * speed;
		} 
		else if (!isFree)
		{
			Vector2 d = target.transform.position - transform.position;
			currentDirection = d.normalized;

			transform.position = Vector2.MoveTowards(new Vector2(transform.position.x, transform.position.y), target.transform.position, speed * Time.deltaTime);
		}
	}

	void OnTriggerEnter2D(Collider2D coll)
	{
		if (coll.gameObject.tag == "Enemy")
		{
			Enemy e = coll.gameObject.GetComponent<Enemy> ();
			e.hit (damage);
			destroyInSeconds (0);
		}
	}

	virtual public void lostTarget()
	{
		destroyInSeconds (5);
	}
}
