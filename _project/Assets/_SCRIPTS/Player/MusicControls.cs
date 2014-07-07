using UnityEngine;
using System.Collections;

public class MusicControls : MonoBehaviour {

	private float musicTargetPitch;
	public AudioSource sourceMusic;

	// Use this for initialization
	void Start () {
		musicTargetPitch = 1.0f;
	}
	
	// Update is called once per frame
	void Update () {
		if (Global.timeScaleToggle == -1) {
			musicTargetPitch = 0.5f;
		} 
		
		else if (Global.timeScaleToggle == 1) {
			musicTargetPitch = 1.5f;
		}
		
		else {
			musicTargetPitch = 1.0f;
		}
		
		if (Mathf.Abs (sourceMusic.pitch - musicTargetPitch) < 0.05f) {
			sourceMusic.pitch = musicTargetPitch;
		}
		
		else { 
			sourceMusic.pitch = Mathf.Lerp (sourceMusic.pitch, musicTargetPitch, 0.05f);
		}
	}
}
