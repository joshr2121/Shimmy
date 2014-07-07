using UnityEngine;
using System.Collections;
using InControl;

public class TitleScreen : MonoBehaviour {

	public AudioSource sourceStartSound;

    void Update() {

        if (InputManager.ActiveDevice.Action1) {

            StartCoroutine(startt());    
        }
    }

    IEnumerator startt() {

		if (!sourceStartSound.isPlaying) {
			sourceStartSound.Play ();
        }
        
        yield return new WaitForSeconds(2.0f);

        Application.LoadLevel(1);
    }
}
