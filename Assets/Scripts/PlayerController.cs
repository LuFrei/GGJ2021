using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Player))]
public class PlayerController : MonoBehaviour
{
    private Player player;

    // Start is called before the first frame update
    void Start(){
        player = GetComponent<Player>();
    }

    // Update is called once per frame
    void FixedUpdate(){
        player.transform.Translate(new Vector2(Input.GetAxis("Horizontal"), 0) * Time.deltaTime * player.speed);
    }
}
