using UnityEngine;
using System.Collections;

public class BouncyWall : MonoBehaviour {

	public float horizBounceFactor;
	public float torqueFactor;

	public float bounceDuration;
	
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

	}
	
 	public void OnCollisionEnter2D (Collision2D coll) {
// 		Debug.Log ("coll");
		Bounce bounce = coll.gameObject.AddComponent<Bounce>();
		if (coll.gameObject.rigidbody2D != null) {
			if (gameObject.transform.position.x > coll.gameObject.transform.position.x) {		
		 	//	coll.gameObject.rigidbody2D.AddForce (new Vector2 (-horizBounceFactor, 0), ForceMode2D.Force);
				bounce.bounceDuration = bounceDuration;
				bounce.bounceTimer = bounceDuration;
				bounce.bounceVector = new Vector2 (-horizBounceFactor, 0);
				// = new Bounce (bounceDuration, new Vector2 (-horizBounceFactor, 0));		
		 		coll.gameObject.rigidbody2D.AddTorque (Random.Range (-torqueFactor, torqueFactor));
		 	}
		 		
			else {
	//			coll.gameObject.rigidbody2D.AddForce (new Vector2 (horizBounceFactor, 0), ForceMode2D.Force);
				bounce.bounceDuration = bounceDuration;
				bounce.bounceTimer = bounceDuration;
				bounce.bounceVector = new Vector2 (horizBounceFactor, 0);
				//bounce = new Bounce (bounceDuration, new Vector2 (horizBounceFactor, 0));	
				coll.gameObject.rigidbody2D.AddTorque (Random.Range (-torqueFactor, torqueFactor));
			}
		}
//		coll.gameObject.AddComponent(" (bounce);
		//			coll.gameObject.rigidbody2D.velocity = new Vector2 (coll.gameObject.rigidbody2D.velocity.x * -10, coll.gameObject.rigidbody2D.velocity.y);
 	}
}

//Wait what the hell am I doing
//Fuck arrays
/**
public class JoshArrayList<E> {

	public E[] list;
	public int[] indexList;
	
	public JoshArrayList () {
		list = new E[100];
		indexList = new int[100];
	}
	
	public E Get () {
		
	}
//	public JoshArrayList () {
	public E Remove () {
	
	}
//	}
}

*/