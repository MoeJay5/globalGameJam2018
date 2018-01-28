using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateHealth : MonoBehaviour {

	public GameObject player;
	public double currentHealth;
	public double maxHealth;
    public static GameObject bar;
    double maxHealthPos;
    double minHealthPos;
    double currentHealthPos;

    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        bar = GameObject.FindGameObjectWithTag("HealthBar");
        maxHealthPos = bar.transform.position.x;
        minHealthPos = maxHealthPos - 102;
        currentHealthPos = maxHealthPos;
    }

    // Update is called once per frame
    void Update () {
		currentHealth = player.GetComponent<playerHealth> ().currentHealth;
		maxHealth = player.GetComponent<playerHealth> ().maxHealth;
        //gameObject.GetComponent<Text> ().text = "Health: " + currentHealth.ToString() + " / " + maxHealth.ToString();
        //bar.transform.Translate(Vector3.left * Time.deltaTime);
        //healthManager(currentHealth / maxHealth);
	}
    public static void healthManager(int amount)
    {
        //bar.transform.Translate((float)(maxHealthPos-minHealthPos+(currentHealth/maxHealth * currentHealthPos/maxHealthPos)-currentHealthPos),0,0,Space.Self);
        //bar.transform.Translate((float)-healthRatio,0,0);
        bar.transform.Translate(-amount,0,0);
    }
}