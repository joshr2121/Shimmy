using UnityEngine;
using System.Collections;

public class Goal : MonoBehaviour {

	public bool p1IsHere;
	public bool p2IsHere; 
	public bool singlePlayerLevel;

	public SpriteRenderer spriteRenderer;
	public Animator theAnimator;
	public Sprite wonSprite;
			
	public int nextLevel;

	// Use this for initialization
	void Start () {
        Global.currentLevel = nextLevel - 1;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void OnTriggerEnter2D (Collider2D coll) {
		if (coll.gameObject.name == "Player1") {
			p1IsHere = true;
		}
		else if (coll.gameObject.name == "Player2") {
			p2IsHere = true;
		}
	}
	
	public void OnTriggerExit2D (Collider2D coll) {
		if (coll.gameObject.name == "Player1") {
			p1IsHere = false;
		}
		else if (coll.gameObject.name == "Player2") {
			p2IsHere = false;
		}
	}
}
