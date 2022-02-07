using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{
    /// <summary>
    /// Controls the play button in the main menu.
    /// </summary>
    public void Play()
    {
        SceneManager.LoadScene(1);
    }

    public void Menu()
    {
        SceneManager.LoadScene(0);
    }

    public void Sandbox()
    {
        SceneManager.LoadScene(3);
    }
    /// <summary>
    /// Controls the quit button in the main menu.
    /// </summary>
    public void Quit()
    {
        Application.Quit();
    }
}
