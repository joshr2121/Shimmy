using UnityEngine;
using System.Collections;

public class TimeLabel : MonoBehaviour {


    private UILabel label;

    void Awake() {

        label = GetComponent<UILabel>();        
    }

	void Update () {


        if (Time.timeScale < 1) {

            label.text = "sllllooowwww ttiiiimmmmmmeeeee";
        }
        else if (Time.timeScale == 1) {
            label.text = "reg time";
        }
        else if (Time.timeScale > 1) {
            label.text = "FAST TIME AAAAAAAAAHHHHH";
        }
	}
}
