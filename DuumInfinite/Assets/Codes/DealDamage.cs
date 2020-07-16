using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DealDamage : MonoBehaviour
{

    public int damage = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Player target = hitInfo.GetComponent<Player>();
        if (target != null)
        { 
            if (name == "Health")
            {
                FindObjectOfType<AudioManager>().Play("Get Health");
                target.Heal(1);
            }
            else if (name == "Clown")
            {
                target.TakeDamage(3);
            }
            else if (name == "Demon")
            {
                target.TakeDamage(2);
            }
            else if (name == "Ghost")
            {
                target.TakeDamage(1);
            }
            else if (name == "Skull")
            {
                target.TakeDamage(1);
            }
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
