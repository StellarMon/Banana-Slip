using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject optionsMenu;
   public void Pause()
   {
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
   }

   public void Home()
   {
        SceneManager.LoadScene("Main Menu");
        Time.timeScale = 1;
   }
   public void Resume()
   {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
   }
   public void Restart()
   {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
   }
   public void Options()
   {
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
   }
   public void Quit ()
   {
        Application.Quit();
   }

   public void CloseSettings ()
   {
        Application.Quit();
   }
}
