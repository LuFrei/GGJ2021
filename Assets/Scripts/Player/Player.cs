using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Collider2D feet;


    public float speed;
    public float flapForce;

    public bool isGrounded;

    // Start is called before the first frame update
    void Start(){
        feet = GetComponentInChildren<Collider2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.CompareTag("Ground"))
            isGrounded = true;
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.gameObject.CompareTag("Egg"))
            collision.gameObject.GetComponent<CollectableEgg>().PickUp(); //if we jsut touched and egg, pick it up
    }

    private void OnCollisionExit2D(Collision2D collision) {
        if(collision.gameObject.CompareTag("Ground"))
            isGrounded = false;
    }
}
