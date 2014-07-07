using UnityEngine;
using System.Collections;
using InControl;

public class Controller : MonoBehaviour {

	private bool singlePlayerLevel;
    public float minTimeScale;
    public float maxTimeScale;
    private TimeShiftSFX timeShiftSFX;

    void Awake() {
        Global.controller = this;
		timeShiftSFX = GameObject.Find ("Player1").GetComponent<TimeShiftSFX>();
    }
    
    void Start () {
    	singlePlayerLevel = GameObject.Find ("goal").GetComponent<Goal>().singlePlayerLevel;
    }

	void Update() {

        if (Input.GetKeyUp(KeyCode.Alpha1)) {
            Application.LoadLevel(0);
        }
        else if (Input.GetKeyUp(KeyCode.Alpha2)) {
            Application.LoadLevel(1);
        }
        else if (Input.GetKeyUp(KeyCode.Alpha3)) {
            Application.LoadLevel(2);
        }
        else if (Input.GetKeyUp(KeyCode.Alpha4)) {
            Application.LoadLevel(3);
        }
        else if (Input.GetKeyUp(KeyCode.Alpha5)) {
            Application.LoadLevel(4);
        }
        else if (Input.GetKeyUp(KeyCode.Alpha6)) {
            Application.LoadLevel(5);
        }
        else if (Input.GetKeyUp(KeyCode.Alpha7)) {
            Application.LoadLevel(6);
        }
		else if (Input.GetKeyUp(KeyCode.Alpha8)) {
			Application.LoadLevel(7);
		}
        
        if (InputManager.Devices.Count > 0) {
			
			int speed = 0;

			if (InputManager.Devices[0].LeftBumper || InputManager.Devices[0].LeftTrigger) {
				
				speed--;
				
				if (Global.timeScaleToggle != -1) {
					timeShiftSFX.PlaySlowdown ();
				}				
			}
			
			if (InputManager.Devices[0].RightBumper || InputManager.Devices[0].RightTrigger) {
				
				speed++;
				
				if (Global.timeScaleToggle != 1) {
					timeShiftSFX.PlaySpeedup ();
				}
			}
			
			Global.timeScaleToggle = speed;
		}
							
			/**Old 2P code

            for (int i = 0; i < 1; i++) {

                if ((InputManager.Devices[i].LeftBumper || InputManager.Devices[i].LeftTrigger)) {
                    found = true;

                    if (i == 0) {
                    
                    	if (Global.timeScaleToggle != -1) {
							timeShiftSFX.PlaySlowdown ();
						}
						
						Global.timeScaleToggle = -1;
                        //Time.timeScale = minTimeScale;
                    }
                    else if (i == 1) {
                        Global.timeScaleToggle = 1;
                        //Time.timeScale = maxTimeScale;
                    }                                        
                }
               	             
                if (InputManager.Devices.Count > 0 && singlePlayerLevel && InputManager.Devices[i].LeftBumper) {
                	found = true;
                	
                	if (i == 0) {	//Turn this off if you want P2 to be able to affect time in single-player levels
                	
                		if (Global.timeScaleToggle != 1) {
                			timeShiftSFX.PlaySpeedup ();
                		} 
                	
	                	if (InputManager.Devices[i].RightBumper) {
	                		Global.timeScaleToggle = 0;
	                	}
	                	
	                	else {
	                		Global.timeScaleToggle = 1;
	                	}
	                }
	            }
            }

            if (!found) {
                Global.timeScaleToggle = 0;
                //Time.timeScale = 1f;
            }
		*/   

        //print(InputManager.Devices.Count);

        //if (InputManager.Devices.Count > 1) {
        //    print("DEVICE 0: " + InputManager.Devices[0].Action1);            
        //    print("DEVICE 1: " + InputManager.Devices[1].Action1);
        //}
        //else if (InputManager.Devices.Count > 0) {
        //    print(InputManager.Devices[0].Action1);            
        //}
        if (Input.GetKeyUp(KeyCode.R)) {
      
            Application.LoadLevel(Global.currentLevel);
        }
	}


}
