using UnityEngine;
using System.Collections;

public class P1GoalChecker : MonoBehaviour {

	// This is attached to P1 only and checks to see if the players are colliding inside the goal.
	// If they are, it will send them to the next level or something.

	// Use this for initialization
	
	Goal goal;

    private bool won;

	void Start () {
        

		goal = GameObject.Find ("goal").GetComponent<Goal>();
	}
	
	// Update is called once per frame
	void Update () {
		if (goal.p1IsHere && goal.singlePlayerLevel) {
			WinLevel ();
			gameObject.GetComponent<PlayerControl>().PlayWinSound ();
		}
	}
		
	void OnCollisionStay2D (Collision2D coll) {	
		if (coll.gameObject.name == "Player2" && goal.p1IsHere && goal.p2IsHere && !goal.singlePlayerLevel) {
			WinLevel ();
		}
	}
	
	public void WinLevel () {
	//	Debug.Log ("YOU DID IT?! YOU FUCKIN WON OMG");

        if (!won) {
            won = true;
            Time.timeScale = 0.1f;
            StartCoroutine(WIN());

            foreach (GameObject obj in GameObject.FindGameObjectsWithTag("DeathTrigger")) {

                obj.SetActive(false);
            }
        }        
    }

    IEnumerator WIN() {
        
		goal.spriteRenderer.sprite = goal.wonSprite;
		goal.theAnimator.enabled = false;
		yield return new WaitForSeconds(0.2f);
		Time.timeScale = 1f;
        Application.LoadLevel(goal.nextLevel);
    }
}
