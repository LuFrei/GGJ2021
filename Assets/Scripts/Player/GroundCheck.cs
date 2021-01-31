using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    public bool isGrounded;

    private void OnCollisionEnter2D(Collision2D collision) {
        Debug.Log("we hit ", collision.gameObject);
        if(collision.gameObject.CompareTag("Ground")) {
            Debug.Log("we hit the floor");
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision) {
        Debug.Log("we left ", collision.gameObject);
        if(collision.gameObject.CompareTag("Ground")) {
            Debug.Log("we left the floor");
            isGrounded = false;
        }
    }
}
