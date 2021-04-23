using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_movement : MonoBehaviour
{
    public int maxJumps = 2;
    private int jumps;
    public float jumpForce = 5f;
    public bool grounded = false;
    public float movespeed = 5f;
    public float hori_movement;
    public Rigidbody2D rb;
    public ParticleSystem player_death_particle;
    public ParticleSystem jump_particle;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W))
        {
            this.Jump();
        }
      
        hori_movement = Input.GetAxisRaw("Horizontal");
    }
    void FixedUpdate()
    {

        rb.velocity = new Vector2(hori_movement * movespeed, rb.velocity.y);
      
        if ( rb.position.y < -3 || Input.GetKeyDown(KeyCode.R))
        {
            FindObjectOfType<shake_behaviour>().TriggerShake();
            FindObjectOfType<player_death>().Sethealth();
            Instantiate(player_death_particle, transform.position, Quaternion.identity);
            FindObjectOfType<player_death>().death();
        }

    }
   
    
    private void Jump()
    {
        if (jumps > 0)
        {
      
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            Instantiate(jump_particle, transform.position, Quaternion.identity);
            grounded = false;
            FindObjectOfType<audio_manager>().play_jump();
            jumps = jumps - 1;
        }
        if (jumps == 0)
        {
            return;
        }
    }
    void OnCollisionEnter2D(Collision2D collider)
    {
        if (collider.gameObject.tag == "Ground" || collider.gameObject.tag == "enemy")
        {
            jumps = maxJumps;
            grounded = true;

        }
        
        if (collider.gameObject.tag == "death")
        {

            Instantiate(player_death_particle, transform.position, Quaternion.identity);
            FindObjectOfType<player_death>().death();



        }



    }

}