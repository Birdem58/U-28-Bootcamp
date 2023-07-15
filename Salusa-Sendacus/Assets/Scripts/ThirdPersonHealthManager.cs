using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonHealthManager : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip _canSesi;
    [SerializeField] private GameObject canText;
    [SerializeField] private AudioClip _hasarAlma;
    public HealthBar healthBar;

    public int maxHealth = 100;

    public int aiDamage = 5;
    public int currentHealth;

    public int regenAmount = 1;

    public float healthRegen = 0.5f;
    private float zamanlayici;
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        canText.SetActive(false);

    }


    private void Update()
    {
        zamanlayici += Time.deltaTime;

        if (zamanlayici >= healthRegen && currentHealth < maxHealth)
        {
            zamanlayici = 0;
            currentHealth += regenAmount;
            healthBar.SetHealth(currentHealth);

        }

        healthBar.SetHealth(currentHealth);
    }

    IEnumerator ShowCanText()
    {
        yield return new WaitForSeconds(0.5f);
        canText.SetActive(false);
    }


    public void CanBarRegen()
    {
        maxHealth += 2;
        audioSource.PlayOneShot(_canSesi);
        if (regenAmount <= 50)
        {
            regenAmount++;
            canText.SetActive(true);
        }

        if (healthRegen >= 0.1f)
        {
            healthRegen -= 0.002f;
            canText.SetActive(true);
        }

        StartCoroutine(ShowCanText());
    }

    public void TakeDamagePlayer()
    {
        audioSource.PlayOneShot(_hasarAlma);
        currentHealth -= aiDamage;
        healthBar.SetHealth(currentHealth);
    }
}
