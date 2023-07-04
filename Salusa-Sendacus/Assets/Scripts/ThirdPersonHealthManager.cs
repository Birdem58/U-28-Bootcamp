using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonHealthManager : MonoBehaviour
{

    public HealthBar healthBar;

    public int maxHealth = 100;
    public int currentHealth;

    public float healthRegen = 0.5f;
    private float zamanlayici;
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);

    }


    private void Update()
    {
        zamanlayici += Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.F))
        {
            TakeDamage(20);
        }


        if (zamanlayici >= healthRegen && currentHealth < maxHealth)
        {
            zamanlayici = 0;
            currentHealth++;
            healthBar.SetHealth(currentHealth);

        }

        healthBar.SetHealth(currentHealth);
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }
}
