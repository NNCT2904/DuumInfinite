using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlayer : MonoBehaviour
{

    public GameObject playerPrefab;

    public void MakePlayer()
    {
        GameObject newPlayer = Instantiate(playerPrefab);
    }
}
