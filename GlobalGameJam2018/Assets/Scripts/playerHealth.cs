using UnityEngine;

public class playerHealth : MonoBehaviour {

    public const int maxHealth = 100;
    public int currentHealth = maxHealth;

    public void takeDamage(int amount) {
        if (currentHealth <= 5) {
            currentHealth = 0;
            CancelInvoke();
            Debug.Log("Dead!");
        }
        currentHealth -= amount;
        Debug.Log("Took Damage");
        Debug.Log("Player Health = " + currentHealth);
    }
    void Start() {
        InvokeRepeating("damageOverTime", 0.0f, 1.0f);
    }    
    public void damageOverTime() {
        takeDamage(1);
    }
}