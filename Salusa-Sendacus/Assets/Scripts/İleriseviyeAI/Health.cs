using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Health : MonoBehaviour
{
    public float maxHealth;
    public float currentHealth;

    public float blinkIntensity;

    public float blinkDuration;

    float blinkTimer;

    NavMeshAgent agent;


    Ragdoll ragdoll;

    SkinnedMeshRenderer skinnedMeshRenderer;

    UIHealtbar healtBar;
    // Start is called before the first frame update
    void Start()
    {
        skinnedMeshRenderer = GetComponentInChildren<SkinnedMeshRenderer>();
        healtBar = GetComponentInChildren<UIHealtbar>();
        ragdoll = GetComponent<Ragdoll>();
        agent = GetComponent<NavMeshAgent>();
        currentHealth = maxHealth;
        var rigidBodies = GetComponentsInChildren<Rigidbody>();
        foreach (var rigidbody in rigidBodies)
        {
            Hitbox hitbox = rigidbody.gameObject.AddComponent<Hitbox>();
            hitbox.health = this;
        }


    }

    public void TakeDamage(float amount, Vector3 direction)
    {
        currentHealth -= amount;
        healtBar.SetHealthBarPercentage(currentHealth / maxHealth);
        if (currentHealth <= 0.0f)
        {
            Die();
        }
        blinkTimer = blinkDuration;
    }

    private void Die()
    {
        healtBar.gameObject.SetActive(false);
        ragdoll.ActivateRagdoll();
        agent.speed = 0.0f;
    }


    // Update is called once per frame
    void Update()
    {
        blinkTimer -= Time.deltaTime;
        float lerp = Mathf.Clamp01(blinkTimer / blinkDuration);
        float intensity = (lerp * blinkIntensity) + 1.0f;
        skinnedMeshRenderer.material.color = Color.white * intensity;

    }
}
