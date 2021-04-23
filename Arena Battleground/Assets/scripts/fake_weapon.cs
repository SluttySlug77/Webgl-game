using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fake_weapon : MonoBehaviour
{
    public GameObject player;
    public Vector3 radius;
    public float rotationSpeed;
  
    void Update()
    {
        transform.RotateAround(player.transform.position, radius, rotationSpeed * Time.deltaTime);
    }
}
