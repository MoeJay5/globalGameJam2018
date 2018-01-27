using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateFood : MonoBehaviour {

	public GameObject player;
	public int food;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
		food = player.GetComponent<playerHealth> ().food;
		gameObject.GetComponent<Text> ().text = "Food: " + food.ToString();
	}
}
