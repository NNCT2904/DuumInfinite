using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public enum SpawnState { SPAWNING, WAITING, COUNTING };

    [System.Serializable]
    public class Wave
    {
        public string name;
        //public Transform enemy;
        public int count;
        public float rate;
    }
    public GameObject enemyPrefab;
    public Sprite[] enemySprites;
    public Wave[] waves;
    private int nextWave = 0;
    public float timeBetweenWave = 5f;
    private float waveCountDown;
    private float searchCountdown = 1f;
    private SpawnState state = SpawnState.COUNTING;
    public Transform[] spawnPoints;

    private float enemySpeed = 3;
    void Start()
    {
        waveCountDown = timeBetweenWave;
    }

    void Update()
    {

        if (state == SpawnState.WAITING)
        {
            //check if enemies are alive
            if(!EnemyIsAlive())
            {
                // begin new round
                WaveCompleted();

            }
            else
            {
                return;
            }
        }

        if (waveCountDown <= 0)
        {
            if (state != SpawnState.SPAWNING)
            {
                //start spawning waves
                StartCoroutine(SpawnWave(waves[nextWave]));
            }
        }
        else
        {
            waveCountDown -= Time.deltaTime;
        }


    }
    
    void WaveCompleted()
    {
        Debug.Log("Wave completed");
        FindObjectOfType<AudioManager>().Play("Next Level");
        FindObjectOfType<CountdownTimer>().ResetTimer();
        state = SpawnState.COUNTING;
        waveCountDown = timeBetweenWave;

        if (nextWave +1 > waves.Length -1)
        {
            nextWave = 0;
            this.enemySpeed += 3;
            Debug.Log("Looping waves");
        }
        else
        {
            this.enemySpeed += 2;
            nextWave++;
        }

    }

    //check every second
    bool EnemyIsAlive()
    {
        searchCountdown -= Time.deltaTime;
        if (searchCountdown <= 0f)
        {
            searchCountdown = 1f;
            if (GameObject.FindGameObjectWithTag("Enemy") == null)
            {
                return false;
            }

        }
        
        return true;
    }
    //wait for amount of seconds
    IEnumerator SpawnWave(Wave _wave)
    {
        state = SpawnState.SPAWNING;

        for (int i = 0; i < _wave.count; i++)
        {
            SpawningEnemy();
            yield return new WaitForSeconds(1f / _wave.rate);
        }

        state = SpawnState.WAITING;

        yield break;
    }



    void SpawningEnemy()
    {
        //D20 for enemies
        int chance = Random.Range(0, 19);
        Debug.Log(chance);
        Transform _sp = spawnPoints[Random.Range(0, spawnPoints.Length)];

        //int arrayIndex = Random.Range(0, enemySprites.Length);
        int arrayIndex;
        if (chance <2)
        {
            arrayIndex = 0;
        }
        else if (chance >= 2 && chance<6)
        {
            arrayIndex = 1;
        }
        else if (chance >=6 && chance <11)
        {
            arrayIndex = 2;
        }
        else
        {
            arrayIndex = 3;
        }

        Sprite enemySprite = enemySprites[arrayIndex];
        string enemyName = enemySprite.name;

        GameObject newEnemy = Instantiate(enemyPrefab, _sp.position, _sp.rotation);
        newEnemy.name = enemyName;
        newEnemy.GetComponent<SpriteRenderer>().sprite = enemySprite;
        newEnemy.GetComponent<EnemyPatrol>().speed = this.enemySpeed;


    }


    public void MakeRandomEnemy()
    {
        int arrayIndex = Random.Range(0, enemySprites.Length);
        Sprite enemySprite = enemySprites[arrayIndex];
        string enemyName = enemySprite.name;
        GameObject newEnemy = Instantiate(enemyPrefab);
        newEnemy.name = enemyName;
        newEnemy.GetComponent<SpriteRenderer>().sprite = enemySprite;

        newEnemy.GetComponent<EnemyPatrol>().speed = this.enemySpeed;
        //newEnemy.GetComponent<SpriteRenderer>().sortingLayerName = "Platform";
    }

}
