using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class player_death : MonoBehaviour
{
    

    public Text timer_text;
    public GameObject leaderboard_canvas;

    public float player_health;
    public ParticleSystem player_death_particle;
    public GameObject player;
    private bool dead = false;
    public GameObject black_death_fade;
    public GameObject death_text_fade;
    public GameObject pause_text_fade;
    public Slider health_slider;
    private bool leady;

    private bool pausey = false;

    private bool test = false;

    public float timeRemaining = 10;
    public bool timerIsRunning = false;

    private void Start()
    {
        
        // Starts the timer automatically
        timerIsRunning = true;
    }

   


    void Update()
    {
        timer_text.text = Mathf.Round(timeRemaining).ToString();

        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
            }
            else
            {
               
                timeRemaining = 0;
                timerIsRunning = false;
                Instantiate(player_death_particle, player.transform.position, Quaternion.identity);
                death();
            }
        }

        health_slider.value = player_health;
      

        if (player_health <= 0 && test == false)
        {


            Instantiate(player_death_particle, player.transform.position, Quaternion.identity);
            death();
            test = true;
            
    

            // making player health back to 50 so it stops executing the death function each frame which i think stops the dead variable on and off again.
        }

         if (Input.GetKeyDown("space") && dead == true)
        {
 
          Invoke("restart", 0f);
          
        }


        if (Input.GetKeyDown("b") && leady == true)
        {
            leaderboard_canvas.SetActive(false);
            death_text_fade.SetActive(true);
            black_death_fade.SetActive(true);
            leady = false;
            dead = true;
        }

        if (Input.GetKeyDown("l") && dead == true)
        {

            Invoke("leaderboard", 0f);

        }

        if (Input.GetKeyDown("space") && pausey == true)
        {
            black_death_fade.SetActive(false);
            pause_text_fade.SetActive(false);
            Time.timeScale = 1f;


            pausey = false;
        }


        if (Input.GetKeyDown("p") || Input.GetKeyDown("escape"))
        {

            Invoke("pause", 0f);

        }


        if (Input.GetKeyDown("q") && pausey == true)
        {
            Application.Quit();
        }
    }
    public void death() 
    {
        FindObjectOfType<audio_manager>().play_explosion();
        health_slider.value = 0;
        black_death_fade.SetActive(true);
        Invoke("death_text", 0.5f);
        Time.timeScale = 0.5f;
        Time.fixedDeltaTime = 0.005f;
        Destroy(player);
       
 

    }

    public void Sethealth()
    {
        health_slider.value = 0;

    }

    public void pause()
    {
        death_text_fade.SetActive(false);
        black_death_fade.SetActive(true);
        pause_text_fade.SetActive(true);
        Time.timeScale = 0f;
        pausey = true;

    }


    public void restart() 
    {
        

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1.0f;
        Time.fixedDeltaTime = 0.02f;
       
    }
    public void death_text()
    {
        death_text_fade.SetActive(true);
        dead = true;


    }

    public void attack(int damage)
    {
        FindObjectOfType<audio_manager>().play_hurt();
        FindObjectOfType<shake_behaviour>().TriggerShake();
        player_health = player_health - damage;

    }

    public void add_time()
    {
        timeRemaining = 10;
    }

    public void leaderboard()
    {
        death_text_fade.SetActive(false);
        black_death_fade.SetActive(false);
        leaderboard_canvas.SetActive(true);
        FindObjectOfType<player_scores>().establish_score();
        dead = false;
        leady = true;
    }
}
