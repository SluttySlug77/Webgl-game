using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class menu_manager : MonoBehaviour
{
    public string player_name;
    public GameObject inputfield;

    public void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    public void playgame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void store_name()
    {
        player_name = inputfield.GetComponent<Text>().text;
       
    }

   


}
