using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_follow : MonoBehaviour
{
    public Transform Target1;
    public Transform Target2;


    public float minOrthographicDistance = 5f;
    public float sensetivity = 1f;
    public float maxOrthographicSize = 10f;

    Camera thisCam;
    float min = 5f;

    private void Start()
    {
       

        thisCam = GetComponent<Camera>();
        min = thisCam.orthographicSize;
    }
    void Update()
    {
      
        
        thisCam.orthographicSize = min + Mathf.Clamp((Vector2.Distance(Target1.position, Target2.position) - minOrthographicDistance) * sensetivity, 0f, maxOrthographicSize);
      
    }
   
}
