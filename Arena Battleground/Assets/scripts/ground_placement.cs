using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ground_placement : MonoBehaviour
{

    float randX;
    float randY;
    public GameObject ground;
    Vector2 wheretospawn;
    public float spawn_amount = 3;

    float randsizex;
    float randsizey;


    void Start()
    {

      
    }

    void FixedUpdate()
    {
        if (spawn_amount > 0)
        {
            randX = Random.Range(24f, -24f);
            randY = Random.Range(5f, 12f);
            randsizex = Random.Range(2f, 8f);
            randsizey = Random.Range(1f, 2f);
            Vector3 randomSize = new Vector3(Random.Range(1f, 9f), 0.5f, 0.5f);

            wheretospawn = new Vector2(randX, randY);
          

          

            GameObject go =  Instantiate(ground, wheretospawn, Quaternion.identity);
            go.transform.localScale = randomSize;

            spawn_amount = spawn_amount - 1;
       
        }
    }

      
        

     

    

 
}
