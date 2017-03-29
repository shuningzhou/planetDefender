using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestroy : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Invoke ("autoDestroy", destroyDelay());
	}

	// Update is called once per frame
	void Update () {

	}

	void autoDestroy()
	{
		Destroy (gameObject);
	}

	virtual public float destroyDelay()
	{
		return 3f;
	}
}
