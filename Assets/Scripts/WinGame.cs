using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinGame : MonoBehaviour
{
    public int sceneNum;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.GetComponent<PlayerController>())
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(sceneNum);
        }
    }
}
