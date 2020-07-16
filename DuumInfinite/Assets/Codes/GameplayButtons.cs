using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameplayButtons : MonoBehaviour
{
    public void BackButton()
    {
        ScoreSpript.scoreValue = 0;
        FindObjectOfType<AudioManager>().Play("Click");
        SceneManager.LoadScene("CharacterSelection");
    }

    public void HighscoreButton()
    {
        FindObjectOfType<AudioManager>().Play("Click");
        SceneManager.LoadScene("Highscore");
    }
}
