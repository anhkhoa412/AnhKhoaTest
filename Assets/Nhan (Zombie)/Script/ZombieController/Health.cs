using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour, IDamagable
{
    [SerializeField] int maxHealth;
    public int currentHealth;
    //Animator anim;
    public GameObject ghost;

    public UnityEvent OnDeath;
    public HealthBar healthBar;
    public Canvas UIGameOver;

   
    public float invincibilityDuration;
    public bool isInvincible = false;
    public bool isInvicibled = false;

    private void Start()
    {
        currentHealth = maxHealth;
        // anim = GetComponent<Animator>();
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerBullet"))
        {
            float[] damageValues = FindObjectOfType<Gun>().gunData.Damage; // Assuming Damage is a float array
            int randomIndex = Random.Range(0, damageValues.Length);
            int randomDamage = Mathf.RoundToInt(damageValues[randomIndex]);

            TakeDamage(randomDamage);
        }
    }


    public void TakeDamage(int damage)
    {
      
        if (!isInvincible)
            currentHealth -= damage;
        if (gameObject != null) 
            CharacterEvents.characterDamaged.Invoke(gameObject, damage);
        //anim.SetTrigger("Hit");
        if (ghost != null) 
        {
            GhostSkillManager ghostSkill = GetComponent<GhostSkillManager>();
            if (!isInvincible && !isInvicibled && currentHealth <= 10 && gameObject.tag.Equals("Ghost"))
            {
                isInvicibled = true;
                isInvincible = true;

                currentHealth = 10;
                ghostSkill.BlinkToPosition();
                invincibilityDuration = ghostSkill.totalTime;
                Invoke("InvincibilityCooldown", invincibilityDuration);
            }
        }
        

        if (currentHealth <= 0)
        {
            currentHealth = 0;
            OnDeath.Invoke();
        }

        healthBar.Updatebar(currentHealth, maxHealth);
    }

    void InvincibilityCooldown()
    {
        isInvincible = false;
    }
    public void Death()
    {
        //Animation Zombie death
        //anim.SetTrigger("Death");
        Destroy(gameObject, 1f);
    }

    public void GameOver()
    {
        Time.timeScale = 0;
        UIGameOver.gameObject.SetActive(true);
    }

}
