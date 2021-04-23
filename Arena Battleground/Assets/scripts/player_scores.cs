using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class player_scores : MonoBehaviour
{


    int score;
    string username;

    void Start()
    {
       



    }

    private void Update()
    {

    }

    public void establish_score()
    {
        
        username = GameObject.Find("gamemanager").GetComponent<menu_manager>().player_name;
        score = GameObject.Find("GameManager").GetComponent<Enemy_spawner>().round;
        score = score - 1;

        FindObjectOfType<leaderboard>().AddNewHighscore(username, score);
    }

}
