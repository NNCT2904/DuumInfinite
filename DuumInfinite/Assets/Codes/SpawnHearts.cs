using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnHearts : MonoBehaviour
{

    public Sprite healthSprite;
    public float timeBetweenHearts = 3f;
    public float heartsCoolDown;
    public Transform[] spawnPoints;
    public GameObject enemyPrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        heartsCoolDown += Time.deltaTime;
        if (heartsCoolDown >= timeBetweenHearts)
        {
            heartsCoolDown = 0;
            if (GameObject.FindGameObjectWithTag("Heart") == null)
            {
                int chance = Random.Range(0, 3);
                Debug.Log(chance);
                if (chance == 0)
                {
                    SpawningHeart();
                }
            }     
        }
    }

    void SpawningHeart()
    {
        Transform _sp = spawnPoints[Random.Range(0, spawnPoints.Length)];

        Sprite heartSprite = this.healthSprite;
        string healthName = heartSprite.name;

        GameObject newHeart = Instantiate(enemyPrefab, _sp.position, _sp.rotation);
        newHeart.name = healthName;
        newHeart.GetComponent<SpriteRenderer>().sprite = heartSprite;
        newHeart.GetComponent<SpriteRenderer>().sprite = heartSprite;
        newHeart.tag = "Heart";


    }
}
