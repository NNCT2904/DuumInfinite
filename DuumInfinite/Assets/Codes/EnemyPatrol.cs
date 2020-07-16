using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class EnemyPatrol : MonoBehaviour
{

    public float speed;
    private float waitTime;
    public float startWaitTime;
    public float min_X;
    public float max_X;
    public float min_Y;
    public float max_Y;
    private GameObject moveSpotObject;
    private Transform moveSpot;
    public GameObject target;
    //Start is called before the first frame update
    void Start()
    {
        moveSpotObject = new GameObject("MoveSpotObject");
        moveSpot = moveSpotObject.transform;


        waitTime = startWaitTime;
        //moveSpot.position = new Vector2(Random.Range(min_X, max_X), Random.Range(min_Y, max_Y));
        //moveSpot.position = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>().position;
        if (GameObject.FindGameObjectWithTag("Player"))
        {
            int trace = Random.Range(0, 2);
            if (trace == 1)
            {
                Debug.Log($"enemy {name} is tracing player");
                moveSpot.position = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>().position;
            }
            else
            {
                Debug.Log($"enemy {name} is ignoring player");
                moveSpot.position = new Vector2(Random.Range(min_X, max_X), Random.Range(min_Y, max_Y));
            }
        }
        else
        {
            moveSpot.position = new Vector2(Random.Range(min_X, max_X), Random.Range(min_Y, max_Y));
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, moveSpot.position, speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, moveSpot.position) < 0.2f)
        {
            if (waitTime <= 0)
            {
                waitTime = startWaitTime;


                if (GameObject.FindGameObjectWithTag("Player"))
                {
                    int trace = Random.Range(0, 2);
                    if (trace == 1)
                    {
                        Debug.Log($"enemy {name} is tracing player");
                        moveSpot.position = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>().position;
                    }
                    else
                    {
                        Debug.Log($"enemy {name} is ignoring player");
                        moveSpot.position = new Vector2(Random.Range(min_X, max_X), Random.Range(min_Y, max_Y));
                    }
                }
                else
                {
                    moveSpot.position = new Vector2(Random.Range(min_X, max_X), Random.Range(min_Y, max_Y));
                }



            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }

    }
}
