using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelection : MonoBehaviour
{
    private GameObject[] characterList;
    private int index = 0;

    private void Start()
    {
        index = PlayerPrefs.GetInt("CharacterSelected");
        name = PlayerPrefs.GetString("PlayerName");
        characterList = new GameObject[transform.childCount];

        //fill array with models
        for(int i = 0; i< transform.childCount; i++)
        {
            characterList[i] = transform.GetChild(i).gameObject;
        }

        //turn off render all of them
        foreach(GameObject go in characterList)
        {
            go.SetActive(false);
        }

        //turn on the first index
        if(characterList[index])
        {
            characterList[index].SetActive(true);
        }


    }

    public void ToggleLeft()
    {
        FindObjectOfType<AudioManager>().Play("Click");
        //turn off the current model
        characterList[index].SetActive(false);
        index--;
        if (index < 0)
        {
            index = characterList.Length - 1;
        }

        //turn on the new model
        characterList[index].SetActive(true);
    }
    public void ToggleRight()
    {
        FindObjectOfType<AudioManager>().Play("Click");

        //turn off the current model
        characterList[index].SetActive(false);
        index++;
        if (index >= characterList.Length)
        {
            index = 0;
        }

        //turn on the new model
        characterList[index].SetActive(true);
    }
    public void Confirm()
    {
        FindObjectOfType<AudioManager>().Play("Click");
        PlayerPrefs.SetInt("CharacterSelected", index);
        PlayerPrefs.SetString("PlayerName", name);
        SceneManager.LoadScene("Instructions");
    }

}
