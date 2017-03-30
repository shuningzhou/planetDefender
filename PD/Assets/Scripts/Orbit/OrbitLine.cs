using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitLine : MonoBehaviour {
	public DrawLine drawLine;
	public Orbit orbit;
	public Color addColor;
	public Color normalColor;

	public float addWidth;
	public float normalWidth;
	// Use this for initialization
	void Start () {
		for (int x = 0; x < 365; x = x + 1) 
		{
			float xCor = orbit.radius * Mathf.Cos (x * Mathf. Deg2Rad);
			float yCor = orbit.radius * Mathf.Sin (x * Mathf. Deg2Rad);
			Vector2 newCor = new Vector2 (xCor, yCor);
			drawLine.UpdateLine(newCor);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void showCanAdd()
	{
		drawLine.setColor (addColor, addColor);
		drawLine.setWidth (addWidth);
	}

	void showNormal()
	{
		drawLine.setColor (normalColor, normalColor);
		drawLine.setWidth (normalWidth);
	}
}
