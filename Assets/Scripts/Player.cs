using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public float flapForce;
    [SerializeField] private GameObject player;

    // Start is called before the first frame update
    void Start(){
        player = gameObject;
    }
}
