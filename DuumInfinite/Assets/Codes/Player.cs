using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Player : MonoBehaviour
{
    public int maxHealth = 5;
    public static int currentHealth;
    public HealthBar healthBar;

    // Start is called before the first frame update
    void Start()
    {
        name = PlayerPrefs.GetString("PlayerName");
        Debug.Log($"CharName: {name}");
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.SetHealth(currentHealth);
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void Heal(int hitPoint)
    {
        if (currentHealth < 5)
        {
            currentHealth += 1;
            healthBar.SetHealth(currentHealth);
        }
        else 
            currentHealth = 5;
    }

    public void TakeDamage(int dmg)
    {
        FindObjectOfType<AudioManager>().Play("Player Damaged");
        currentHealth -= dmg;
    }
}
