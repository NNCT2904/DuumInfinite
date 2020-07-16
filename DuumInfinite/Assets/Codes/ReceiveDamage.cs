using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class ReceiveDamage : MonoBehaviour
{

    private bool isBeingAttacked = false;

    // Update is called once per frame
    void Update()
    {
        if (isBeingAttacked)
        {
            if (name == "Skull")
            {
                ScoreSpript.scoreValue += 1;

            }
            else if (name == "Ghost")
            {
                ScoreSpript.scoreValue += 2;
            }
            else if (name == "Demon")
            {
                ScoreSpript.scoreValue += 3;
            }
            else if (name == "Clown")
            {
                ScoreSpript.scoreValue += 4;
            }
            else if (name == "Health")
            {

                if (Player.currentHealth < 5)
                {
                    Player.currentHealth += 1;
                }
                else
                    Player.currentHealth = 5;

            }
            Destroy(gameObject);
        }
    }

    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (GameObject.FindGameObjectWithTag("Player") != null)
            {
            Vector3 mousePos;
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);
                if (name == "Health")
                {
                    FindObjectOfType<AudioManager>().Play("Get Health");
                }
                else FindObjectOfType<AudioManager>().Play("Enemy Damaged");

                isBeingAttacked = true;
            }
        }
    }

    private void OnMouseUp()
    {
        isBeingAttacked = false;
    }
}
