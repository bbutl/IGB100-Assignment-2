using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Mainmenu : MonoBehaviour
{
    public GameObject nextLevel;
    public int level = 1;
    public void Start()
    {
        if(SceneManager.GetActiveScene().name == "Victory 2")
        {
            Destroy(nextLevel);
        }
    }
    public void PlayGame()
    {
       SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ResetLevel()
    {
        SceneManager.LoadScene($"level {level}");
    }

    public void GameMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
