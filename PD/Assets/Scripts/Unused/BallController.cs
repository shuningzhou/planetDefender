using UnityEngine;
using System.Collections;

public class BallController : MonoBehaviour {
	//Maximum velocity the ball can have
	public float maxVelocity = 0.5f;
	//The Particle effect when ball hits the plank
	public GameObject sparkEffect;
	//Current Velocity
	Vector3 velocity;
	//Play Area
	public float range = 10.0f;
	//Sound the ball will make when collision with the plank
	public AudioClip bounceSound;
	// Use this for initialization
	void Start () {
		//Setting the layers and order for trail renderer
		if (transform.GetComponent<TrailRenderer> ()) {
			transform.GetComponent<TrailRenderer>().sortingLayerID = 0;
			transform.GetComponent<TrailRenderer>().sortingOrder = 3;
		}
		//Initial Velocity
		velocity = Vector3.down * maxVelocity;
	}

	// Update is called once per frame
	void Update (){
		//World MidPoint
		Vector3 midPoint = new Vector3 (0.0f, 0.6f, 0.0f);
		//Distance between ball and world
		float distance = Vector3.Distance (midPoint, transform.position);
		//Is ball in the play area?
		if (distance >= range) {
			EndGame ();
		}
	}

	void EndGame (){
		//Message to end the game
		transform.root.SendMessage ("EndGame", SendMessageOptions.DontRequireReceiver);
	}

	void FixedUpdate () {
		//let's move the ball
		transform.Translate (velocity*Time.fixedDeltaTime);
	}

	void OnTriggerEnter2D (Collider2D other){
		//Did we hit the plank
		if (other.name == "Plank") {
			//React to collision
			velocity = -(transform.position - new Vector3(0.0f,0.6f,0.0f)).normalized + Vector3.Reflect(transform.position - new Vector3(0.0f,0.6f,0.0f).normalized,other.transform.up).normalized*maxVelocity;
			//Increase score
			transform.root.SendMessage("IncrementScore",SendMessageOptions.DontRequireReceiver);
			//Launch Particle effect
			if (sparkEffect){
				Instantiate(sparkEffect,transform.position,Quaternion.identity);
			}
			//Play sound On hit
			if (transform.GetComponent<AudioSource>() && bounceSound){
				transform.GetComponent<AudioSource>().PlayOneShot(bounceSound);
			}
		}
	}

}

