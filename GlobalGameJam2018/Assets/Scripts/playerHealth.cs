using UnityEngine;

public class playerHealth : MonoBehaviour {

    public const double maxHealth = 100;
    public double currentHealth = maxHealth;
    public int food = 4;
    public int water = 3;
    public int medicine = 2;

    public void takeDamage(int amount) {
        if (currentHealth <= 0) {
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

    public void rest() {
        double modifier = 0;
        if (food >= 1) {
            modifier++;
            food--;
        }
        if (water >= 1) {
            modifier++;
            water--;
        }
        if (medicine >= 1) {
            modifier++;
            medicine--;
        }
        currentHealth = maxHealth * (modifier / 3);
        Debug.Log("Current Health" + currentHealth);
        Debug.Log("Modifier " + modifier);
        Debug.Log("Current Health: = " + currentHealth);
        if (currentHealth <= 0)
            Debug.Log("Dead!");
    }
}