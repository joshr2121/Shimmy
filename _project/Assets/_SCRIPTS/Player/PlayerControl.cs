using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using InControl;
public class PlayerControl : MonoBehaviour
{
	[HideInInspector]
	public bool facingRight = true;			// For determining which way the player is currently facing.
	[HideInInspector]
	public bool jump = false;				// Condition for whether the player should jump.
    public bool jumpDown = false;				// Condition for whether the player should jump.
    public bool jumpUp = false;				// Condition for whether the player should jump.

    public int playerNumber;

	public float moveForce = 365f;			// Amount of force added to move the player left and right.
	public float maxSpeed = 5f;				// The fastest the player can travel in the x axis.
	public AudioClip[] jumpClips;			// Array of clips for when the player jumps.
	public float jumpForce = 1000f;			// Amount of force added when the player jumps.
	
	private bool grounded = false;			// Whether or not the player is grounded.
	private Animator anim;					// Reference to the player's animator component.

    public List<GameObject> groundCheckList;

    private Vector3 startPos;
    private GameObject[] checkpoints;

    public GameObject explo;
    public bool explosionDisabled;
    
    public AudioSource sourceCheckpointAndWin;
    public AudioClip clipCheckpoint;
    public AudioClip clipWin;

	void Awake()
	{

        startPos = transform.position;
	}
	
	public void Start () {
		checkpoints = GameObject.FindGameObjectsWithTag("Checkpoint");
	}


	void Update()
	{



        foreach (GameObject obj in groundCheckList) {
            if (Physics2D.Linecast(transform.position, obj.transform.position, 1 << LayerMask.NameToLayer("Ground"))) {
                
                grounded = true;
            }
        }


        //// If the jump button is pressed and the player is grounded then the player should jump.
        //if(InputManager.Devices.Count > 0 && InputManager.Devices[playerNumber].Action1 && grounded) {
        //    grounded = false;
        //    jump = true;
        //}

        // If the jump button is pressed and the player is grounded then the player should jump.
        if (InputManager.Devices.Count > 0 && InputManager.Devices[playerNumber].Action1.WasPressed && grounded) {
            grounded = false;
            jump = true;
        }
        if (InputManager.Devices.Count > 0 && InputManager.Devices[playerNumber].Action1.WasReleased) {

            StopCoroutine("jumpRoutine");
        }

        if (InputManager.ActiveDevice.Action3 && !explosionDisabled) {

            GameObject obj = Instantiate(explo, new Vector3(transform.position.x - InputManager.ActiveDevice.LeftStickX, transform.position.y - InputManager.ActiveDevice.LeftStickY, transform.position.z), Quaternion.identity) as GameObject;            
        }
	}


	void FixedUpdate ()
	{

        float h = 0;
		// Cache the horizontal input.
        if ((InputManager.Devices.Count > 0))
		    h = InputManager.Devices[playerNumber].LeftStickX;

		// The Speed animator parameter is set to the absolute value of the horizontal input.
		

		// If the player is changing direction (h has a different sign to velocity.x) or hasn't reached maxSpeed yet...
		if(h * rigidbody2D.velocity.x < maxSpeed)
			// ... add a force to the player.
			rigidbody2D.AddForce(Vector2.right * h * moveForce);

		// If the player's horizontal velocity is greater than the maxSpeed...
		if(Mathf.Abs(rigidbody2D.velocity.x) > maxSpeed)
			// ... set the player's velocity to the maxSpeed in the x axis.
			rigidbody2D.velocity = new Vector2(Mathf.Sign(rigidbody2D.velocity.x) * maxSpeed, rigidbody2D.velocity.y);

		// If the input is moving the player right and the player is facing left...
		if(h > 0 && !facingRight)
			// ... flip the player.
			Flip();
		// Otherwise if the input is moving the player left and the player is facing right...
		else if(h < 0 && facingRight)
			// ... flip the player.
			Flip();

		// If the player should jump...
		if (jump) {
            			
		    rigidbody2D.AddForce(new Vector2(0f, jumpForce * 0.5f));			
			jump = false;

            StartCoroutine("jumpRoutine");
		}
	}

    IEnumerator jumpRoutine() {

        yield return new WaitForSeconds(0.075f);
        
        rigidbody2D.AddForce(new Vector2(0f, jumpForce * 0.5f));
    }
	
	void Flip ()
	{
		// Switch the way the player is labelled as facing.
		facingRight = !facingRight;

		// Multiply the player's x local scale by -1.
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

    void OnTriggerEnter2D(Collider2D other) {

        if (other.tag.Equals("DeathTrigger")) {
            
            if (checkpoints.Length > 0) {
				
				int highestCheckpoint = -1;
				
            	for (int i = checkpoints.Length-1; i >= 0; i--) {
            		if (checkpoints[i].GetComponent<Checkpoint>().active) {
            			highestCheckpoint = i;
            		}
            	}
            	if (highestCheckpoint > -1) {
	            	ResetToPos (checkpoints[highestCheckpoint].transform.position);
	            }
	            else {
	            	ResetToPos (startPos);
	            }
            		
            }	
            else {
				ResetToPos (startPos);
			}		
        }
        
        else if (other.tag.Equals ("Checkpoint")) {
        	if (!other.GetComponent<Checkpoint>().active) {
	        	
	        	other.GetComponent<Checkpoint>().active = true;
	        	other.GetComponent<SpriteRenderer>().sprite = other.GetComponent<Checkpoint>().activatedSprite;
				other.GetComponent<Animator>().enabled = false;
				sourceCheckpointAndWin.clip = clipCheckpoint;
				
				if (!sourceCheckpointAndWin.isPlaying) {
					sourceCheckpointAndWin.Play ();
				}
			}
		}
    }
 
    public void PlayWinSound () {
    	if (!sourceCheckpointAndWin.isPlaying) {	
    		sourceCheckpointAndWin.clip = clipWin;
    		sourceCheckpointAndWin.Play ();
    	}
    }
          
    private void ResetToPos (Vector3 pos) {
		transform.position = pos;
		transform.rigidbody2D.velocity = Vector2.zero;
	}
}
