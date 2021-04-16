using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSystem : MonoBehaviour {

    public GameObject mainCamera;

    public Vector2[] anchors;
    public GameObject[] camTriggers;



    // Start is called before the first frame update
    void Start() {
        mainCamera = GameObject.Find("Main Camera");
    }

    public void ChangeCamPosition(Vector3 newPos) {
        mainCamera.transform.position = newPos;
    }

}
