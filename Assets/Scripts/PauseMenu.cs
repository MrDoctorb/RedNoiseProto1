using UnityEngine.SceneManagement;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public bool isPaused;
    public GameObject pauseMenu;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //If escape key is pressed and is paused, will resume
            if (isPaused)
            {
                Resume();
            }
            //If escape key is pressed and not paused, will pause.
            else
            {
                Pause();
            }
        }
    }

    /// <summary>
    /// Deactivates the pause menu and set time back to normal.
    /// </summary>
   public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    /// <summary>
    /// Activates the pause menu and freezes time. 
    /// </summary>
    void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    /// <summary>
    /// Sets time back to normal and loads main menu
    /// </summary>
    public void Menu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

    public void Quit()
    {
        Application.Quit();
    }

}
