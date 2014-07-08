using UnityEngine;

using System.Collections;

public class RotatingPlatform : MonoBehaviour {

	float timeScale = 1;

	public float rotateSpeed;
    public int rotateDirection = 1;
	public float angle; 	// Assume lever starts at the midpoint of its rotation
	private float maxEulerAngle;
	private float minEulerAngle;
	
	private float timeScaleTarget;
	
	//public float rotateTime;
    
	// Use this for initialization
	void Start () {

		maxEulerAngle = transform.eulerAngles.z + angle/2;
		minEulerAngle = transform.eulerAngles.z - angle/2;
        //if (rotateTime != 0)
        //    StartCoroutine(changeDirection());
	}
        	
	// Update is called once per frame
	void FixedUpdate () {

        if (Global.timeScaleToggle == -1 && timeScale != 0.2f) {
            timeScale = 0.2f;            
        }
        else if (Global.timeScaleToggle == 1 && timeScale != 2) {
            timeScale = 2;            
        }
        else if (Global.timeScaleToggle == 0 && timeScale != 1) {
            timeScale = 1;            
        }

        // LERP TIME SCALE VALUE MOTHERSFUCKERZ
        // Actually don't
        /** 
        if (timeScale != timeScaleTarget) {
	         timeScale = Mathf.Lerp(timeScale, timeScaleTarget, 0.1f);
        }
        */

		// This is causing some problems but is probably okay for now
        if (angle != 0) {
        	if (transform.eulerAngles.z > maxEulerAngle || transform.eulerAngles.z < minEulerAngle) {
            	rotateDirection *= -1;
        	}
        }

		transform.Rotate (Vector3.forward * Time.deltaTime * rotateSpeed * timeScale * rotateDirection); 
	}

	/**
    IEnumerator changeDirection() {

        yield return new WaitForSeconds(rotateTime / timeScale);

        rotateDirection *= -1;

        StartCoroutine(changeDirection());
    }
    */
}
