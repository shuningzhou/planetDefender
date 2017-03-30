using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbit : MonoBehaviour {

	public float capacity;
	public List<Satellite> satellites = new List<Satellite> ();
	public float radius = 10;

	public GameObject satellite1;
	public OrbitLine line;

	// Use this for initialization
	void Start () {
		spawnSatellites ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void spawnSatellites ()
	{
		Satellite s = Instantiate (satellite1).GetComponent<Satellite>();
		s.orbit = this;
		satellites.Add (s);
	}
}
