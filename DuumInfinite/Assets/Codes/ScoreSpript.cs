using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;


public class ScoreSpript : MonoBehaviour
{

    public static int scoreValue = 0;
    //Text score;
    public TextMeshProUGUI sc;
    
    // Start is called before the first frame update
    void Start()
    {
        
        sc = GetComponent<TextMeshProUGUI>();
       //score = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        sc.SetText($"Score: {scoreValue.ToString()}");
        //score.text = "Score: " + scoreValue;
    }

    public void Reset()
    {
        scoreValue = 0;
    }
}
