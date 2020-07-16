using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UI_InputField : MonoBehaviour
{
    TMP_InputField inputField;
    void Awake()
    {
        inputField = transform.Find("InputField").GetComponent<TMP_InputField>();
        inputField.text = "BOB";
    }
    public void StartClick()
    {
        GameObject.FindGameObjectWithTag("Player").name = inputField.text;
        Debug.Log($"Player's name: {GameObject.FindGameObjectWithTag("Player").name}");
    }
}
