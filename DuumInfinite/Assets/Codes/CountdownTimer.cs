using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CountdownTimer : MonoBehaviour
{
    public float timeLimit = 6f;
    public float currentTime = 6f;
    public TextMeshProUGUI timer;
    public float CurrentTime { get => currentTime; }

    // Start is called before the first frame update
    void Start()
    {
        timer = GetComponent<TextMeshProUGUI>();
        currentTime = timeLimit;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentTime <= 0)
        {
            Destroy(GameObject.FindGameObjectWithTag("Player"));
        }
        if (GameObject.FindGameObjectWithTag("Player") != null)
        {
            ReturnTicks();
            timer.SetText(currentTime.ToString("0"));
        }
        else
        {
            return;
        } 
    }

    public void ResetTimer()
    {
        currentTime = timeLimit;
    }

    float ReturnTicks()
    {
        currentTime -= 1 * Time.deltaTime;
        return currentTime;
    }
}
