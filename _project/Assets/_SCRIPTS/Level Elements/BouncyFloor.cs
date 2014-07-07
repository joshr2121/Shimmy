using UnityEngine;
using System.Collections;

public class BouncyFloor : MonoBehaviour {

	//public float minYSpeed;				//Player bounce must be at least this high
	//public float maxYSpeed;				//Player bounce may not be higher than this  
	public float bounceFactor;
	public float torqueAdded;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
 	public void OnCollisionEnter2D (Collision2D coll) {
		/**float ySpeed = Mathf.Abs (coll.gameObject.transform.rigidbody2D.velocity.y);
		Debug.Log (ySpeed);
		
		if (ySpeed < minYSpeed) {
			ySpeed = minYSpeed;
		}
		
		else if (ySpeed > maxYSpeed) {
			ySpeed = maxYSpeed;
		}
		*/
		
		if (coll.transform.rigidbody2D != null) {
			if (gameObject.transform.position.y > coll.gameObject.transform.position.y) {
				//coll.gameObject.rigidbody2D.velocity = new Vector2 (coll.gameObject.rigidbody2D.velocity.x, coll.gameObject.rigidbody2D.velocity.magnitude * bounceFactor);		
		 		coll.gameObject.rigidbody2D.AddForce (new Vector2 (0, -bounceFactor));
		 		coll.gameObject.rigidbody2D.AddTorque (Random.Range (-torqueAdded, torqueAdded));
			}
			else {
				//coll.gameObject.rigidbody2D.velocity = new Vector2 (coll.gameObject.rigidbody2D.velocity.x, coll.gameObject.rigidbody2D.velocity.magnitude * bounceFactor);		
				coll.gameObject.rigidbody2D.AddForce (new Vector2 (0, bounceFactor));
				coll.gameObject.rigidbody2D.AddTorque (Random.Range (-torqueAdded, torqueAdded));
			}
			//			coll.gameObject.rigidbody2D.velocity = new Vector2 (coll.gameObject.rigidbody2D.velocity.x * -10, coll.gameObject.rigidbody2D.velocity.y);
		
 	 	}
 	 }
}
