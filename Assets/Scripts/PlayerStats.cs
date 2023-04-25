using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using TMPro;

public class PlayerStats : MonoBehaviour
{
    public GameObject player;
    public GameObject waveSystem;

    [Header("Player Stats")]
    private float maxHealth;
    private float playerHealth;
    public HealthBar healthBar;
    public float baseDamage;

    [Header("Shop Stats")]
    public float playerExperience;
    public float playerMoney;

    private void Update()
    {
        maxHealth = gameObject.GetComponent<Health>().maxHealth;
        playerHealth = gameObject.GetComponent<Health>().getHealth();
        healthBar.SetHealth(playerHealth);

        if (playerHealth <= 0)
        {
            waveSystem.GetComponent<WaveSystem>().Restart();
        }
    }

    public void grantExperience(float exp)
    {
        playerExperience += exp;
    }

    public void grantMoney(float money)
    {
        playerMoney += money;
    }

    public void setDamage(float damage)
    {
        baseDamage = damage;
    }

    public void setExperience(float exp)
    {
        playerExperience = exp;
    }

    public void setMoney(float money)
    {
        playerMoney = money;
    }
}
