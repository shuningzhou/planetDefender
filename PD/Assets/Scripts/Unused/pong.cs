using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pong : MonoBehaviour {
	public GameObject linePrefab;

	public int initalDegree = 90;
	public float radius = 150f;
	int startDegree = -110;
	int currentDegree = 90;

	public Line pad;
	Vector3 zAxis = new Vector3(0, 0, 1);
	// Use this for initialization
	void Start () {
		print ("Line started");
		GameObject lineGO = Instantiate(linePrefab);
		Line activeLine = lineGO.GetComponent<Line>();
		currentDegree = initalDegree;
		for (int x = startDegree; x < startDegree + initalDegree; x = x + 1) 
		{
			float xCor = radius * Mathf.Cos (x * Mathf. Deg2Rad);
			float yCor = radius * Mathf.Sin (x * Mathf. Deg2Rad);
			Vector2 newCor = new Vector2 (xCor, yCor);
			activeLine.UpdateLine(newCor);
		}
		pad = activeLine;
		pad.transform.SetParent(gameObject.transform);
	}
	
	// Update is called once per frame
	void Update () {
//		pad.transform.RotateAround(Vector3.zero, zAxis, 20 * Time.deltaTime); 
		foreach (Touch touch in Input.touches) {
			if (touch.position.x < Screen.width/2)
			{
				pad.transform.RotateAround(Vector3.zero, zAxis, -100 * Time.deltaTime); 

			}
			else if (touch.position.x > Screen.width/2)
			{
				pad.transform.RotateAround(Vector3.zero, zAxis, 100 * Time.deltaTime); 
			}
		}
			
		if (Input.GetKey (KeyCode.RightArrow)) {
			pad.transform.RotateAround(Vector3.zero, zAxis, 150 * Time.deltaTime); 
		}

		if (Input.GetKey (KeyCode.LeftArrow)) {
			pad.transform.RotateAround(Vector3.zero, zAxis, -150 * Time.deltaTime); 
		}
	}

	public void increaseLength()
	{
		print ("increace");
		Quaternion r = pad.transform.rotation;
		Vector3 p = pad.transform.position;
		pad.clearPoints ();
		currentDegree = currentDegree + 10;
		startDegree = startDegree - 5;
		for (int x = startDegree; x < startDegree + currentDegree; x = x + 1) 
		{
			float xCor = radius * Mathf.Cos (x * Mathf. Deg2Rad);
			float yCor = radius * Mathf.Sin (x * Mathf. Deg2Rad);
			Vector2 newCor = new Vector2 (xCor, yCor);
			pad.UpdateLine(newCor);
		}
			
		pad.transform.rotation = r;
		pad.transform.position = p;
	}
}
