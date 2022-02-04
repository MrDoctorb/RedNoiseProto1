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

   
    /// <summary>
    /// Controls the quit button in the main menu.
    /// </summary>
    public void Quit()
    {
        Application.Quit();
    }
}
