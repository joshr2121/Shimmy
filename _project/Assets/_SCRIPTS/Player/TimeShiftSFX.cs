using UnityEngine;
using System.Collections;

public class TimeShiftSFX : MonoBehaviour {

	public AudioSource sourceSFX;
	public AudioClip clipSlowdown;
	public AudioClip clipSpeedup;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void PlaySlowdown () {
		if (!sourceSFX.isPlaying) {
			sourceSFX.clip = clipSlowdown;
			sourceSFX.Play ();
		}
	}
	
	public void PlaySpeedup () {
		if (!sourceSFX.isPlaying) {
			sourceSFX.clip = clipSpeedup;
			sourceSFX.Play ();
		}
	}
}
