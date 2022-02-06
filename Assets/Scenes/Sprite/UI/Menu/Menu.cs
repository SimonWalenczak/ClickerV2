using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject credits;
    public void ClickToPlay()
    {
        SceneManager.LoadScene(1);
    }
    public void ClickToQuit()
    {
        Application.Quit();
    }
    public void GoToCredit()
    {
        if (!GameObject.Find("Credit"))
        {
            credits.SetActive(true);
        }
        else
        {
            credits.SetActive(false);
        }  
    }
}
