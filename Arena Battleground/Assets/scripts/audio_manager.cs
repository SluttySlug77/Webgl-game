using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audio_manager : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip enemy_death;
    public AudioClip shoot;
    public AudioClip hurt;
    public AudioClip explosion;
    public AudioClip jump;
    public float volume = 1f;

    public void Awake()
    {
        
    }

    public void play_enemy_death()
    {
        audioSource.PlayOneShot(enemy_death, volume);
    }

    public void play_shoot()
    {
        audioSource.PlayOneShot(shoot, volume);
    }

    public void play_hurt()
    {
        audioSource.PlayOneShot(hurt, volume);
    }

    public void play_explosion()
    {
        audioSource.PlayOneShot(explosion, volume);
    }

    public void play_jump()
    {
        audioSource.PlayOneShot(jump, volume);
    }


}
