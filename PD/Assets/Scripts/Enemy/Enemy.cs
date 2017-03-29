using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : CanDestroy {
	public float life;
	// Use this for initialization

	void Awake()
	{		
		TrailRenderer tr = GetComponent<TrailRenderer> ();
		tr.sortingOrder = -1;
	}

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
	{

	}

	public void hit(Damage damage)
	{
		life = life - damage.lifeDeduct;
		if (life <= 0) 
		{
			destroyInSeconds (0);
		}
	}
}
