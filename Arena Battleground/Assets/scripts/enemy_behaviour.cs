using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_behaviour : MonoBehaviour
{
    public float speed;
    private float stoppingdistance;
    public float retreatdistance;
    private float bullet_time;
    public float bullet_interval;
    public float jumpHeight;
    public GameObject bullet;
    public Transform player;
    public float wait_time = 0;
    public Rigidbody2D enemy_rb;
    public ParticleSystem enemy_death_particle;
    public ParticleSystem enemy_jump_particle;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        StartCoroutine(JumpLogic());
        stoppingdistance = Random.Range(1.5f, 8f);
    }


    void FixedUpdate()
    {

        if (Vector2.Distance(transform.position, player.position) > stoppingdistance)
        {
            var targetPos = new Vector2(player.position.x, transform.position.y);
            transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);

          
        }
        else if (Vector2.Distance(transform.position, player.position) < stoppingdistance && Vector2.Distance(transform.position, player.position) > stoppingdistance)
        {
            transform.position = this.transform.position;

        }
        else
        {
      
        }

        if(bullet_time <= 0)
        {

            Instantiate(bullet, transform.position , Quaternion.identity);
            FindObjectOfType<audio_manager>().play_shoot();
            bullet_time = bullet_interval;
            
        }
        else
        {
            bullet_time -= Time.deltaTime;

        }
        if (enemy_rb.position.y < 0)
        {
            FindObjectOfType<audio_manager>().play_enemy_death();
            Instantiate(enemy_death_particle, transform.position, Quaternion.identity);
            Destroy(gameObject);
            FindObjectOfType<player_death>().add_time();
        }

       
    }
    void OnTriggerEnter2D(Collider2D collide)
    {

        if (collide.gameObject.tag.Equals("weapon"))
        {
            FindObjectOfType<audio_manager>().play_enemy_death();
            FindObjectOfType<player_death>().add_time();
            Instantiate(enemy_death_particle, transform.position, Quaternion.identity);
            Destroy(gameObject);
           
        }


    }


    IEnumerator JumpLogic()
    {
        float minWaitTime = 1;
        float maxWaitTime = 5;

        while (true)
        {
            yield return new WaitForSeconds(Random.Range(minWaitTime, maxWaitTime));

            Instantiate(enemy_jump_particle, transform.position, Quaternion.identity);
            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpHeight);
        }
    }



}

 


