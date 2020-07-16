using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    public GameObject endLevelUI;
    private string playerName;
    private int score;
    public HighScoreTable highScoreTable;

    // Start is called before the first frame update
    void Start()
    {
        playerName = GameObject.FindGameObjectWithTag("Player").name;
        score = ScoreSpript.scoreValue;
    }

    // Update is called once per frame
    void Update()
    {
        score = ScoreSpript.scoreValue;
        if (Ended())
        {
            endLevelUI.SetActive(true);
            highScoreTable.AddHighScoreEntry(129, playerName);
        }
    }


    bool Ended()
    {
        if (GameObject.FindGameObjectWithTag("Player") == null)
        {
            return true;
        }
        return false;
    }

}
