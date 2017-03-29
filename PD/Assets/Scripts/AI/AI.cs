using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour 
{
	public static AI sharedAI = null;
	List<Shield> shields = new List<Shield>();
	public float vision = 300;

	void Awake()
	{
		if (sharedAI == null) 
		{
			sharedAI = this;
		} else if (sharedAI != this) {
			Destroy(gameObject);
			return;
		}
		Debug.Log ("AI awake");
	}

	void Start () 
	{

	}


	public void addShied(Shield shield)
	{
		shields.Add (shield);
	}

	void FixedUpdate()
	{
		
	}

	void scan()
	{
		
	}

	public void monitorEnemy(Enemy e)
	{
		
	}

	// Update is called once per frame
	void Update () {
		
	}
}
