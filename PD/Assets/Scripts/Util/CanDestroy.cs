using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanDestroy : MonoBehaviour {

	public void destroyInSeconds(float seconds)
	{
		Invoke ("doDestroy", seconds);
	}

	void doDestroy()
	{
		doPS ();
		Destroy (gameObject);
	}

	virtual public void doPS()
	{
	}
}
