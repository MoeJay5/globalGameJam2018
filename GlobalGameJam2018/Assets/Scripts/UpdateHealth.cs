using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateHealth : MonoBehaviour {

	public GameObject player;
	public double currentHealth;
	public double maxHealth;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player");
	}

	// Update is called once per frame
	void Update () {
		currentHealth = player.GetComponent<playerHealth> ().currentHealth;
		maxHealth = player.GetComponent<playerHealth> ().maxHealth;
		gameObject.GetComponent<Text> ().text = "Health: " + currentHealth.ToString() + " / " + maxHealth.ToString();
	}
}
