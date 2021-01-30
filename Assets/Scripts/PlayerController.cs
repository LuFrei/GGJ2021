using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Player))]
public class PlayerController : MonoBehaviour
{
    private Player player;
    private Rigidbody2D rb2d;
    private Animator anim;

    private bool wingsAreUp = false;

    // Start is called before the first frame update
    void Start(){
        player = GetComponent<Player>();
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate(){
        Move(player.speed);

        //when the space/"jump" button is down, the wings open, when it is released it closes
        if(wingsAreUp) {
            Glide();
            if (Input.GetAxisRaw("Jump") == 0)
                LowerWings(player.flapForce);
        } else if (Input.GetAxisRaw("Jump") == 1 && !wingsAreUp) {
            RaiseWings();
        }
    }

    private void Move(float speed) {
        player.transform.Translate(new Vector2(Input.GetAxis("Horizontal"), 0) * Time.deltaTime * speed);
    }

    private void RaiseWings() {
        wingsAreUp = true;

        //set anim
        anim.SetBool("wingsAreOpen", wingsAreUp);
    }

    private void LowerWings(float force) {
        wingsAreUp = false;
        anim.SetBool("wingsAreOpen", wingsAreUp);
        rb2d.AddForce(new Vector2(0, 1) * force, ForceMode2D.Impulse);
    }

    //Apply vertical drag and slgiht forward motion
    private void Glide() {
        Vector2 vel = rb2d.velocity;
        
        vel.y *= 0.7f;        //modify drag here

        vel.x += 0f;          //modify forward vector here

        rb2d.velocity = vel;  //Apply changes
    }
}
