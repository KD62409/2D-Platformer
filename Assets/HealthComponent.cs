using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthComponent : MonoBehaviour
{
    public int maxHealth = 100;
    private float currentHealth;
    private bool invincibility;
    public delegate void OnHealthChangedHandler(float newHealth, float amountChanged);
    public event OnHealthChangedHandler OnHealthChanged;
    public delegate void OnHealthInitializedHandler(float nweHealth);
    public event OnHealthInitializedHandler OnHealthInitialez;
    private void Start()
    {
        currentHealth = maxHealth;
        OnHealthInitialez?.Invoke(currentHealth);
    }

    public void ReceiveDamage(float amount)

    { if (!invincibility)
        {
            currentHealth -= amount;
            OnHealthChanged?.Invoke(currentHealth, amount);
            invincibility = true;
            StartCoroutine(ResetInvincibility(3));
        }
    if(currentHealth <=0)
        {
            SceneManager.LoadScene("EndScene");
        }

    }
    
    
    
    IEnumerator ResetInvincibility(float resetTime)
    {
        yield return new WaitForSeconds(resetTime);
        invincibility = false;
    }
    
    


public void AddHealth(float amount)
    {
        currentHealth += amount;
        OnHealthChanged?.Invoke(currentHealth, amount);
        //Debug.Log(currentHealth);
    }
}
