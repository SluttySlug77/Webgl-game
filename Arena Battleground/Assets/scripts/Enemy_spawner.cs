using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy_spawner : MonoBehaviour
{
    public Text round_completion;
    public GameObject completion_text_fade;
    public ParticleSystem enemy_spawn_particle;
    public int number_enemies;
    public int round = 2;
    public Text roundtext;
    public Text roundtext2;
    private bool start = false;


    private int base_spawn = 1;
    float randX;
    float randY;
    public GameObject enemy_prefab;
    Vector2 wheretospawn;
    public float spawnrate;
  
    public int spawn_amount;

    private int base_spawn2 = 1;
    float randX2;
    float randY2;
    public GameObject enemy_prefab2;
    Vector2 wheretospawn2;
    public float spawnrate2;
   
    public int spawn_amount2;

    private int base_spawn3 = 2;
    float randX3;
    float randY3;
    public GameObject enemy_prefab3;
    Vector2 wheretospawn3;
    public float spawnrate3;
 
    public int spawn_amount3;
    
    private float spawnTime = 0;
    

    // Use this for initialization
    void Start()
    {
        startinvoking();


    }

    public void startinvoking()
    {
        Invoke("invokey1", spawnrate);
        Invoke("invokey2", spawnrate2);
        Invoke("invokey3", spawnrate3);
    }


    public void invokey1()
    {
        InvokeRepeating("enemy1_spawn", spawnTime, spawnrate);
    }

    public void invokey2()
    {
        InvokeRepeating("enemy2_spawn", spawnTime, spawnrate2);
    }

    public void invokey3()
    {
        InvokeRepeating("enemy3_spawn", spawnTime, spawnrate3);
    }


    public void enemy1_spawn()
    {
        randX = Random.Range(24f, -24f);
        randY = Random.Range(2f, 15f);

        wheretospawn = new Vector2(randX, randY);
        Instantiate(enemy_spawn_particle, wheretospawn, Quaternion.identity);
        Invoke("enemy1", 2f);

    }

    public void enemy2_spawn()
    {
        randX2 = Random.Range(24f, -24f);
        randY2 = Random.Range(2f, 15f);

        wheretospawn2 = new Vector2(randX2, randY2);
        Instantiate(enemy_spawn_particle, wheretospawn2, Quaternion.identity);
        Invoke("enemy2", 2f);

    }
    public void enemy3_spawn()
    {
        randX3 = Random.Range(24f, -24f);
        randY3 = Random.Range(2f, 15f);

        wheretospawn3 = new Vector2(randX3, randY3);
        Instantiate(enemy_spawn_particle, wheretospawn3, Quaternion.identity);
        Invoke("enemy3", 2f);

    }


    void Update()
    {
        if (spawn_amount == 0)
        {
            CancelInvoke("enemy1_spawn");
        }
        
        if (spawn_amount2 == 0)
        {
            CancelInvoke("enemy2_spawn");
        }
        
        if (spawn_amount3 == 0)
        {
            CancelInvoke("enemy3_spawn");
        }


        number_enemies = GameObject.FindGameObjectsWithTag("enemy").Length;


        if (spawn_amount == 0 && spawn_amount2 == 0 && spawn_amount3 == 0 && number_enemies == 0 && start == false)
        {
            start = true;
            round_completion.text = "Round " + (round-1) + " Complete";
            completion_text_fade.SetActive(true);

            roundtext.text = "Round " + round.ToString();
         //   roundtext2.text = "Round " + round.ToString();
            round = round + 1 ;
            Invoke("newround", 2f);
          
        }
    
    
    }
   
    public void enemy1()
    {
        Instantiate(enemy_prefab, wheretospawn, Quaternion.identity);
        spawn_amount = spawn_amount - 1;

    }

    public void enemy2()
    {
        Instantiate(enemy_prefab2, wheretospawn2, Quaternion.identity);
        spawn_amount2 = spawn_amount2 - 1;

    }

    public void enemy3()
    {
        Instantiate(enemy_prefab3, wheretospawn3, Quaternion.identity);
        spawn_amount3 = spawn_amount3 - 1;

    }

    public void newround()
    {
       
        spawn_amount = base_spawn;
        spawn_amount2 = base_spawn2;
        spawn_amount3 = base_spawn3;

        base_spawn = base_spawn + 1;
        base_spawn2 = base_spawn2 + 1;
        base_spawn3 = base_spawn3 + 1;
        startinvoking();
        completion_text_fade.SetActive(false);
        FindObjectOfType<player_death>().add_time();
        start = false;
    }

  

}
