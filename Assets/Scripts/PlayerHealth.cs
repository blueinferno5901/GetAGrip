﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    public int maxHealth = 100;
    public int currentHealth;
    public int regeneration = 1;
    public float waitTime = 1;

    public StaminaBar staminaBar;

    void Start()
	{
        currentHealth = maxHealth;
        staminaBar.SetMaxHealth(maxHealth);
        StartCoroutine(Regen());
	}

    IEnumerator Regen()
	{
        while (true)
		{
            if (currentHealth < maxHealth)
            {
                currentHealth++;
            }
            else
            {
                currentHealth = maxHealth;
            }
            yield return new WaitForSeconds(waitTime);
        }
	}

    void Update()
	{
        staminaBar.SetHealth(currentHealth);
    }

    public void TakeDamage(int damage)
	{
        currentHealth -= damage;

        staminaBar.SetHealth(currentHealth);
    }
}
