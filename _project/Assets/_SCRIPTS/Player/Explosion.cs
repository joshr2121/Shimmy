using UnityEngine;
using System.Collections;

public class Explosion : MonoBehaviour {


    void Start() {        

        Destroy(gameObject, 0.14f);
    }

    void Update() {

        transform.localScale = new Vector3(transform.localScale.x + 0.4f, transform.localScale.y + 0.4f, transform.localScale.z);
    }
}
