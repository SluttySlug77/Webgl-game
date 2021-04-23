using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class player_weapon : MonoBehaviour
{

    public GameObject player;
    public Vector3 radius;
    public float rotationSpeed;
    public GameObject weapon;
    public GameObject fake_weapon;

    public Slider health_slider1;
    public Slider health_slider2;
    public Slider health_slider3;

    public int weapon_regeneration;
    public float weapon_health;


    private float time = 0.0f;
    public float interpolationPeriod = 1f;

    private BoxCollider2D collider;
    private SpriteRenderer sprite;

    void Start()
    {
        collider = GetComponent<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        health_slider1.value = weapon_health - 20;
        health_slider2.value = weapon_health - 10;
        health_slider3.value = weapon_health;

        transform.RotateAround(player.transform.position, radius, rotationSpeed * Time.deltaTime);
       
        if (weapon_health <= 10)
        {
            collider.enabled = false;
            sprite.enabled = false;
     
        }
        else
        {
            collider.enabled = true;
            sprite.enabled = true;


        }

        time += Time.deltaTime;

        if (time >= interpolationPeriod && weapon_health < 30)
        {
            time = 0.0f;
            regeneration();
           
        }
   
    }

    public void weapon_attack(int damage)
    {

        weapon_health = weapon_health - damage;

    }

    public void regeneration()
    {
        weapon_health = weapon_health + 1;
    }




}
