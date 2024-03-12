using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        Debug.Log("Игра запустилась");
        SceneManager.LoadScene("Menu");
    }
    public void ExitGame()
    {
        Debug.Log("Игра закрылась");
    Application.Quit();
    }
   


}
