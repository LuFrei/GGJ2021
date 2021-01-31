using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Player))]
public class PlayerController : MonoBehaviour
{
    private Player player;
    private Rigidbody2D rb2d;
    [SerializeField]private Animator anim;

    private bool wingsAreUp = false;
    float speed;

    // Start is called before the first frame update
    void Start(){
        player = GetComponent<Player>();
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
        speed = player.speed;
    }

    // Update is called once per frame
    void FixedUpdate(){
        if(player.isGrounded) {
            speed = player.speed; //not optimal, but its the quick and dirty way to toggle between speeds
        }

        //when the space/"jump" button is down, the wings open, when it is released it closes
        if(wingsAreUp) {
            if(!player.isGrounded) {
                Glide();
            }
            if (Input.GetAxisRaw("Jump") == 0)
                LowerWings(player.flapForce);
        } else if (Input.GetAxisRaw("Jump") == 1 && !wingsAreUp) {
            RaiseWings();
        }

        Move();
    }

    private void Move() {
        float moveDir = Input.GetAxis("Horizontal");
        //if input is recieved, see if we turned
        if(moveDir != 0)
            anim.SetBool("facingRight", moveDir > 0);
        player.transform.Translate(new Vector2(moveDir, 0) * Time.deltaTime * speed);
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

        speed = player.speed * 2;          //modify forward vector here

        rb2d.velocity = vel;  //Apply changes
    }
}
