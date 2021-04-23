using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_bullet : MonoBehaviour
{

    public float moveSpeed = 7f;

    Rigidbody2D rb;

    public GameObject target;

    Vector2 moveDirection;

    public ParticleSystem bullet_impact;

    public int numb_damage;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player");
        moveDirection = (target.transform.position - transform.position).normalized * moveSpeed;
        rb.velocity = new Vector2(moveDirection.x, moveDirection.y);
 

        Vector3 dir = target.transform.position - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
       

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag.Equals("Player"))
        {
            Instantiate(bullet_impact,gameObject.transform.position, Quaternion.identity);
            FindObjectOfType<player_death>().attack(numb_damage);
            Destroy(gameObject);

            

        }

        if (col.gameObject.tag.Equals("weapon"))
        {
            Instantiate(bullet_impact, gameObject.transform.position, Quaternion.identity);
            FindObjectOfType<player_weapon>().weapon_attack(10);
            Destroy(gameObject);



        }

        if (col.gameObject.tag.Equals("Ground"))
        {
        
            Destroy(gameObject);
        }
       
    }

    private void Update()
    {
        if (gameObject.transform.position.x <= -40 || gameObject.transform.position.x >= 40 || gameObject.transform.position.y <= -20 || gameObject.transform.position.y >= 30)
        {

            Destroy(gameObject);

        }
    }

}
