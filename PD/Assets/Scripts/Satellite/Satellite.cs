using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Satellite : MonoBehaviour {
	public Orbit orbit;
	public bool isAttacking = false;
	Vector3 zAxis = new Vector3(0, 0, 1);
	public float rotationSpeed = 100;

	public List<GameObject> enemies = new List<GameObject>();

	public Missle missle;

	public GameObject currentTarget;

	// Use this for initialization
	void Start () {
		gameObject.transform.position = new Vector2 (0, orbit.radius);
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (!isAttacking) 
		{
			rotate (Time.deltaTime * rotationSpeed);
		}

		findTarget ();

		if (currentTarget == null) {
			cancelAttact ();
		} 
		else if (!enemies.Contains(currentTarget))
		{
			cancelAttact ();
		}
		else if (currentTarget)
		{
			isAttacking = true;
			if (!IsInvoking("attack")) {
				InvokeRepeating("attack", 0, 1);
			}
		}
	}

	void cancelAttact()
	{
		CancelInvoke ("attack");

		if (isAttacking)
		{
			Invoke ("doCancelAttactState", 1);
		}
	}

	void doCancelAttactState()
	{
		isAttacking = false;
	}

	void rotate(float step)
	{
		gameObject.transform.RotateAround(Vector3.zero, zAxis, step); 
	}

	public void addEnemy(GameObject enemy)
	{
		enemies.Add (enemy);
	}

	public void removeEnemy(GameObject enemy)
	{
		enemies.Remove (enemy);
	}

	void findTarget()
	{
		if (enemies.Count == 0) 
		{
			return;
		}
			
		float distance = 10000;
		GameObject closest = null;
		foreach (GameObject go in enemies) 
		{
			if (go) {
				float thisDistance = Vector2.Distance (go.transform.position, gameObject.transform.position);
				if (thisDistance < distance) 
				{
					closest = go;
				}
			}
		}

		currentTarget = closest;
	}

	void attack()
	{
		if (currentTarget) 
		{
			Missle m = Instantiate (missle, gameObject.transform.position, Quaternion.identity);
			m.target = currentTarget;
		}
	}
}
