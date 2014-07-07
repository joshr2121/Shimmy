using UnityEngine;
using System.Collections;

public class LockMe : MonoBehaviour {
	
	private float xPos;
	private float yPos;
	private Vector3 eulerAngles;
	
	public bool lockX;
	public bool lockY;
	public bool lockRotation;
	
	// Use this for initialization
	void Start () {
		
		xPos = transform.position.x;
		yPos = transform.position.y;
		eulerAngles = transform.eulerAngles;
	}
	
	// Update is called once per frame
	void Update () {
		
		Vector3 newPos = transform.position;
		Vector3 rot = transform.eulerAngles;
		
		if (lockX) {
			newPos.x = xPos;
		}
		
		if (lockY) {
			newPos.y = yPos;
		}
		
		transform.position = new Vector3 (newPos.x, newPos.y, newPos.z);
		
		if (lockRotation) {		
			transform.eulerAngles = rot;
		}
	}
}
