using UnityEngine;
using System.Collections;

public class Cannon : MonoBehaviour {

    public GameObject ammo;

    public float reloadTime;
    private float startReloadTime;

    public float deviation;

    public float power;

    private Vector3 shootDirection;

    private float timeScale;
    private float lastTimeScale;

    void Start() {

        shootDirection = transform.rotation.eulerAngles;

        StartCoroutine(shoot());

        startReloadTime = reloadTime;
    }

    private float timeScaleTarget;

    void Update() {

        if (Global.timeScaleToggle == -1 && timeScale != 0.2f) {
            timeScale = 0.2f;
            reloadTime *= 2;            
        }
        else if (Global.timeScaleToggle == 1 && timeScale != 2F) {
            timeScale = 2F;
            reloadTime *= 0.2f;
            
        }
        else if (Global.timeScaleToggle == 0 && timeScale != 1) {
            timeScale = 1;

            reloadTime = startReloadTime;
        }
    }

    IEnumerator shoot() {

        yield return new WaitForSeconds(reloadTime);

        GameObject obj =  Instantiate(ammo, transform.position, transform.rotation) as GameObject;


        obj.rigidbody2D.AddForce(transform.right * (power * timeScale));

        StartCoroutine(shoot());
    }
}
