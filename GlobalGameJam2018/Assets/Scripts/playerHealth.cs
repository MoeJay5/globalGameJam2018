using UnityEngine;

public class playerHealth : MonoBehaviour
{
    public const int maxHealth = 100;
    public int currentHealth = maxHealth;
    public void takeDamage(int amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Debug.Log("Dead!");
        }
    }
}