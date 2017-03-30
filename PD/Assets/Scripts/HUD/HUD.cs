using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUD : MonoBehaviour {
	public GameObject confirm;
	public Satellite currentSatellite;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void addButtonPressed()
	{
		Orbit[] orbits = GameObject.FindObjectsOfType<Orbit> ();
		foreach (Orbit orbit in orbits) 
		{
			orbit.enterAddMode();
			currentSatellite = orbit.addSatellite ();
			confirm.gameObject.SetActive (true);
			confirm.transform.position = new Vector2 (currentSatellite.transform.position.x, currentSatellite.transform.position.y + 50);
		}
	}

	public void okPressed()
	{
		currentSatellite.editing = false;
		confirm.gameObject.SetActive (false);

		enterNormalMode ();
	}

	public void cancelPressed()
	{
		Destroy (currentSatellite.gameObject);
		confirm.gameObject.SetActive (false);

		enterNormalMode ();
	}

	public void enterNormalMode()
	{
		Orbit[] orbits = GameObject.FindObjectsOfType<Orbit> ();
		foreach (Orbit orbit in orbits) 
		{
			orbit.enterNormalMode ();
		}
	}
}
