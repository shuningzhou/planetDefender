using UnityEngine;
using System.Collections;

public class BGColorChanger : MonoBehaviour {
	//Background
	public SpriteRenderer BGSprite;
	//All the colors to loop through
	//Speed to loop through colors
	public float colorSpeed = 5.0f;
	//Middle Text
	public TextMesh scoreText;
	//Sorting order for Middle Text
	public int sortingOrder = 1;
	//Current Chosen color

	public int currentLife = 0;
	int fullLife = 100;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		//Ready to go?
		if (!BGSprite) {
			//Debug.LogWarning("I can't find some Objects");
			return;
		}
		//Applying the color
		//BGSprite.color = Color.Lerp (BGSprite.color, getCurrentColor(),Time.deltaTime*colorSpeed);
	}

	public Color getCurrentColor()
	{
		Color c = new Color ();
		c.a = ((float)currentLife / (float)fullLife);
		c.r = 224.0f/255.0f;
		c.b = 72.0f/255.0f;
		c.g = 199.0f/255.0f;
		return c;
	}
}
