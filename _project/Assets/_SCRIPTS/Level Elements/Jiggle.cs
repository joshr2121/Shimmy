using UnityEngine;
using System.Collections;

public class Jiggle : MonoBehaviour {

	public float jiggleAmount;
	public float jiggleDelay;

	// Use this for initialization
	void Start () {
		JiggleIt ();
	}
	
	// Update is called once per frame
	void Update () {

	}
	
	public void JiggleIt () {
		float timeMult = 1f;
		switch (Global.timeScaleToggle) {
		case -1:
			timeMult = 5f;
			break;
		case 1:
			timeMult = 0.5f;
			break;
		}
		Vector3 newPos = new Vector3 (	transform.parent.gameObject.transform.position.x + Random.Range (-jiggleAmount, jiggleAmount),
		                              transform.parent.gameObject.transform.position.y + Random.Range (-jiggleAmount, jiggleAmount),
		                              transform.parent.gameObject.transform.position.z);
		gameObject.transform.position = newPos;
		Invoke ("JiggleIt", jiggleDelay * timeMult);
	}
}
