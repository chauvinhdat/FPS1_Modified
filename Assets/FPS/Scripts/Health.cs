using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [Tooltip("Maximum amount of health")]
    public float maxHealth = 10f;
    // 2022--01-26: Added max lives bar 
    public float maxLive = 1f;
    [Tooltip("Health ratio at which the critical health vignette starts appearing")]
    public float criticalHealthRatio = 0.3f;

    public UnityAction<float, GameObject> onDamaged;
    public UnityAction<float> onHealed;
    public UnityAction onDie;

    public float currentHealth { get; set; }
    // 2022--01-26: Added current lives bar 
    public float currentLive { get; set; }

    public bool invincible { get; set; }

    public bool canPickup() => currentHealth < maxHealth;

    public float getRatio() => currentHealth / maxHealth;
    public bool isCritical() => getRatio() <= criticalHealthRatio;

    bool m_IsDead;

    private void Start()
    {
        currentHealth = maxHealth;
        // 2022--01-26: multiply the default health by n lives to get the total health
        currentLive = maxLive;
    }

    // 2022--01-26: 
    public void checkHealLive()
    {
        if(currentHealth >= maxHealth && currentLive < maxLive)
        {
            currentLive += 1;
        }
    }

    public void Heal(float healAmount)
    {
        float healthBefore = currentHealth;
        currentHealth += healAmount;
        // 2022--01-26: 
        if (currentHealth >= maxHealth && currentLive < maxLive)
        {
            currentLive += 1;
            currentHealth = currentHealth - maxHealth;
        }
        currentHealth = Mathf.Clamp(currentHealth, 0f, maxHealth);
        

        // call OnHeal action
        float trueHealAmount = currentHealth - healthBefore;
        if (trueHealAmount > 0f && onHealed != null)
        {
            onHealed.Invoke(trueHealAmount);
        }
    }

    public void TakeDamage(float damage, GameObject damageSource)
    {
        if (invincible)
            return;

        float healthBefore = currentHealth;
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0f, maxHealth);

        // 2022--01-26: statement to deal with lives
        if (currentHealth <= 0 && currentLive > 1)
        {
            currentLive -= 1;
            currentHealth = maxHealth;
        }

        // call OnDamage action
        float trueDamageAmount = healthBefore - currentHealth;
        if (trueDamageAmount > 0f && onDamaged != null)
        {
            onDamaged.Invoke(trueDamageAmount, damageSource);
        }

        HandleDeath();
    }

    public void Kill()
    {
        currentHealth = 0f;
        currentLive = 0f;

        // call OnDamage action
        if (onDamaged != null)
        {
            onDamaged.Invoke(maxHealth, null);
        }

        HandleDeath();
    }

    private void HandleDeath()
    {
        if (m_IsDead)
            return;

        // call OnDie action
        // 2022--01-26: added currentLive constraint
        if (currentHealth <= 0f && currentLive <= 1f)
        {
            if (onDie != null)
            {
                m_IsDead = true;
                onDie.Invoke();
            }
        }
    }


}
