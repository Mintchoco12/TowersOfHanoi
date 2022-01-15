using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameWinScreen : MonoBehaviour
{
    public void Setup()
    {
        //Shows the gamewinscreen
        gameObject.SetActive(true);
    }

    //Restart button on gamewinscreen
    public void RestartButton()
    {
        SceneManager.LoadScene("TowersOfHanoi");
    }

    //Exit button on gamewinscreen
    public void ExitButton()
    {
        SceneManager.LoadScene("MainMenu");
    }
}


