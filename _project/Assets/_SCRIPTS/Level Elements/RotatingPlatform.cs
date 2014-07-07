using UnityEngine;

using System.Collections;

public class RotatingPlatform : MonoBehaviour {

	public float rotateSpeed;

    float timeScale = 1;

    public int rotateDirection = 1;

    public float rotateTime;

    public float angle;
    
	// Use this for initialization
	void Start () {

        //if (rotateTime != 0)
        //    StartCoroutine(changeDirection());
	}
        
    private float timeScaleTarget;
	
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
        if (timeScale != timeScaleTarget) {

            timeScale = Mathf.Lerp(timeScale, timeScaleTarget, Time.deltaTime * 2);
        }

		// This is causing some problems but is probably okay for now
        if (transform.localEulerAngles.z > angle && angle != 0) {
            rotateDirection *= -1;
        }

		transform.Rotate (Vector3.forward * Time.deltaTime * rotateSpeed * timeScale * rotateDirection); 
	}

    IEnumerator changeDirection() {

        yield return new WaitForSeconds(rotateTime / timeScale);

        rotateDirection *= -1;

        StartCoroutine(changeDirection());
    }
}
