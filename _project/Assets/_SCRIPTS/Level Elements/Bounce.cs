using UnityEngine;
using System.Collections;

public class Bounce : MonoBehaviour {

	public float bounceDuration;
	public float bounceTimer;
	public Vector2 bounceVector;

	public Bounce (float duration, Vector2 vector) {
		bounceDuration = duration;
		bounceTimer = duration;
		bounceVector = vector;
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		bounceTimer -= Time.deltaTime;
		if (bounceTimer > 0 && gameObject.transform.rigidbody2D != null) {
			gameObject.transform.rigidbody2D.AddForce (bounceVector * (bounceTimer/bounceDuration));
		}
		else {
			Component.Destroy (this);
		}
	}
}
