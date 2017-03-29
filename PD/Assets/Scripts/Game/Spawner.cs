using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {
	public GameObject Enemy;

	// Use this for initialization
	void Start () {
		InvokeRepeating ("addEnemy", 0, 3f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public Vector2 randomSpawnPoint(float radius)
	{
		float rad = Random.Range (0, 2 * Mathf.PI);
		float x = radius * Mathf.Cos (rad);
		float y = radius * Mathf.Sin (rad);
		Vector2 n = new Vector2 (x, y);
		return n;
	}

	public void addEnemy()
	{
		GameObject go = Instantiate(Enemy, randomSpawnPoint(150), Quaternion.identity);
		EnemyMovement e = go.GetComponent<EnemyMovement> ();
		e.enterGameWithSpeed (5, 50);
	}
}
