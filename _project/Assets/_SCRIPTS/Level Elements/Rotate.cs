using UnityEngine;
using System.Collections;

public class Rotate : MonoBehaviour {

	public float automaticTorque;
	public float maxAngularVelocity;
	public bool rotatingLeft;
	private float dir;

	// Use this for initialization
	void Start () {
		if (rotatingLeft) dir = 1f;
		else dir = -1f;
	}
	
	// Update is called once per frame
	void Update () {
			
	}
	
	public void FixedUpdate () {
		//Time scale stuff isn't really working
		
		float timeMult = 1f;
		switch (Global.timeScaleToggle) {
		case -1:
			timeMult = 0.2f;
			break;
		case 1:
			timeMult = 2f;
			break;
		}
		
		if (Mathf.Abs (transform.rigidbody2D.angularVelocity * timeMult) < Mathf.Abs (maxAngularVelocity * timeMult)) {
			transform.rigidbody2D.AddTorque (automaticTorque * dir);
		}
		else {
			transform.rigidbody2D.angularVelocity = maxAngularVelocity * timeMult * dir;
		}
		
	}
}
