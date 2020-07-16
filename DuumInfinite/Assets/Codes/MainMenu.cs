using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    
    public void ToMainScreen()
    {
        FindObjectOfType<AudioManager>().Play("Click");
        SceneManager.LoadScene(0);
    }

    public void Instructions()
    {
        FindObjectOfType<AudioManager>().Play("Click");
        SceneManager.LoadScene("Instructions");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
