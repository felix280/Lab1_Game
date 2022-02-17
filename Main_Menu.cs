using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main_Menu : MonoBehaviour
{
    //This script allow us to give functions to the button who are pressed in the main menu
    public void Quit_Game()
    {
        Application.Quit();
        Debug.Log("Game Closed");
    }
   public void Play_Game()
    {
        SceneManager.LoadScene("Game");
    }
}
