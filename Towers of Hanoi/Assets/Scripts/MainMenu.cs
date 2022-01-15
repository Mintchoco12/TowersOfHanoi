using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    //Start button in main menu
    public void StartGame()
    {
        SceneManager.LoadScene("TowersOfHanoi");
    }

    //Exit Button in main menu
    public void ExitButton()
    {
        Application.Quit();
        Debug.Log("Game quit");
    }
}
