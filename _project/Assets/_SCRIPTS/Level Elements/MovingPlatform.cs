using UnityEngine;
using System.Collections;

public class MovingPlatform : MonoBehaviour {

    public float speed = 1;
	
    public float horizontalRange;
    public float verticalRange;
	private Vector3 startPos;
	
    private Vector3 deltaMovement;

    public int hdirection = 1;
    public int vdirection = 1;

    public float maxRotationSpeed;

    float timeScale = 1;
    float lastTimeScale;

    public bool continuousDelay;
    public float delay;

    private bool moving = false;

    void Start() {

        if (verticalRange == 0) {
            vdirection = 0;
        }
        if (horizontalRange == 0) {
            hdirection = 0;
        }

        deltaMovement = new Vector3(speed, 0, 0);
        startPos = transform.position;

        StartCoroutine(startDelay(delay));
    }

    private float timeScaleTarget;

    void FixedUpdate() {

        if (moving) {
            if (Global.timeScaleToggle == -1 && timeScale != 0.2f) {
                timeScaleTarget = 0.2f;
                rigidbody2D.angularVelocity *= timeScale;
                lastTimeScale = 0.2f;
            }
            else if (Global.timeScaleToggle == 1 && timeScale != 2) {
                timeScaleTarget = 2;
                rigidbody2D.angularVelocity *= timeScale;
                lastTimeScale = 2f;
            }
            else if (Global.timeScaleToggle == 0 && timeScale != 1) {
                timeScaleTarget = 1;

                if (lastTimeScale == 0.2f)
                    rigidbody2D.angularVelocity *= 5;
                else if (lastTimeScale == 2)
                    rigidbody2D.angularVelocity *= 0.5f;
            }

            // LERP TIME SCALE VALUE MOTHERSFUCKERZ
            if (timeScale != timeScaleTarget) {

                timeScale = Mathf.Lerp(timeScale, timeScaleTarget, Time.deltaTime * 5);
            }

            if (horizontalRange != 0) {
                if (transform.position.x <= startPos.x - horizontalRange / 2) {

                    hdirection = 1;
                }
                else if (transform.position.x >= startPos.x + horizontalRange / 2) {

                    hdirection = -1;
                }
            }

            if (verticalRange != 0) {
                if (transform.position.y <= startPos.y - verticalRange / 2) {

                    vdirection = 1;
                }
                else if (transform.position.y >= startPos.y + verticalRange / 2) {

                    vdirection = -1;
                }
            }

            deltaMovement = new Vector3(hdirection * speed * timeScale, vdirection * speed * timeScale, 0);

            rigidbody2D.MovePosition((transform.position + deltaMovement));            

        }
       
    }

    IEnumerator startDelay(float delay) {

        yield return new WaitForSeconds(delay);

        moving = true;
    }
}
