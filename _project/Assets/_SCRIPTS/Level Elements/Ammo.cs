using UnityEngine;
using System.Collections;

public class Ammo : MonoBehaviour {

    void Start() {

        if (Global.timeScaleToggle == -1) {
            Destroy(gameObject, 30);
        }
        else if (Global.timeScaleToggle == 1) {
            Destroy(gameObject, 10);

        }
        else if (Global.timeScaleToggle == 0) {
            Destroy(gameObject, 20);
        } 

        
    }

    void FixedUpdate() {

        //rigidbody2D.AddForce(transform.right * 5);
    }

    void LateUpdate() {

        
    }
}
