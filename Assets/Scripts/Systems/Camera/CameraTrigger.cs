using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTrigger : MonoBehaviour {

    public GameObject anchor;//Camera this trigger is tied to
    public CameraSystem camSys;

    private void Start() {
        camSys = GameObject.Find("Game Manager").GetComponent<CameraSystem>();
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.tag == "Player") {
            camSys.ChangeCamPosition(anchor.transform.position);
        }
    }
}