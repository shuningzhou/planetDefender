using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineCreator : MonoBehaviour {

	public GameObject linePrefab;

	Line activeLine;
	int initalDegree = 20;
	float radius = 3.0f;
	public Line player;

	void Start ()
	{
		print ("Line started");
		GameObject lineGO = Instantiate(linePrefab);
		activeLine = lineGO.GetComponent<Line>();
		for (int x = 0; x < initalDegree; x = x + 1) 
		{
			float xCor = radius * Mathf.Cos (x * Mathf. Deg2Rad);
			float yCor = radius * Mathf.Sin (x * Mathf. Deg2Rad);
			Vector2 newCor = new Vector2 (xCor, yCor);
			print (x);
			activeLine.UpdateLine(newCor);
		}
		player = activeLine;
		activeLine = null;
	}

	void Update ()
	{
		if (Input.GetMouseButtonDown(0))
		{
			GameObject lineGO = Instantiate(linePrefab);
			activeLine = lineGO.GetComponent<Line>();
		}

		if (Input.GetMouseButtonUp(0))
		{
			activeLine = null;
		}

		if (activeLine != null)
		{
			Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			activeLine.UpdateLine(mousePos);
		}

	}

}
