using UnityEngine;
 using UnityEngine.SceneManagement;

public class playerHealth : MonoBehaviour
{

    public double maxHealth = 100;
    public double currentHealth;
    public int food = 4;
    public int water = 3;
    public int medicine = 2;

    public int microphone = 0;
    public int controllerBox = 0;
    public int broadcastDish = 0;
    public int battery = 0;

    #region Singeton
    public static playerHealth instance;
    void Awake()
    {
        instance = this;
    }
    #endregion
    public GameObject player;
    public void takeDamage(int amount)
    {
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            CancelInvoke();
            //Debug.Log("Dead!");
        }
        currentHealth -= amount;
        //Debug.Log("Took Damage");
        //Debug.Log("Player Health = " + currentHealth);
        SimpleHealthBar.UpdateBar("healthBar", (float)currentHealth, (float)maxHealth);
        SimpleHealthBar.UpdateBar("smallBar", (float)currentHealth, (float)maxHealth);
    }
    void Start()
    {
        InvokeRepeating("damageOverTime", 0.0f, 1.0f);
        currentHealth = maxHealth;
    }
    public void damageOverTime()
    {
        takeDamage(1);
    }

    public void turnIn(int resource)
    {
        if (resource == 1)
            food--;
        if (resource == 2)
            water--;
        if (resource == 3)
            medicine--;
        maxHealth += 10;
    }
    public void rest()
    {
        Debug.Log("rested");
        double modifier = 0;
        if (food >= 1)
        {
            modifier++;
            food--;
        }
        if (water >= 1)
        {
            modifier++;
            water--;
        }
        if (medicine >= 1)
        {
            modifier++;
            medicine--;
        }
        currentHealth = maxHealth * (modifier / 3);
        //Debug.Log("Current Health" + currentHealth);
        //Debug.Log("Modifier " + modifier);
        //Debug.Log("Current Health: = " + currentHealth);
        if (currentHealth <= 0)
              SceneManager.LoadScene("GameOver", LoadSceneMode.Single);

        if (microphone ==1 && battery ==1 && controllerBox == 1 && broadcastDish == 1 ){
            //Game win condition / cutscene
        }
    }
}