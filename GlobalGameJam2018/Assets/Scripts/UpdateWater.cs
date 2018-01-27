using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateWater : MonoBehaviour {

	GameObject player;
	public int water;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player");
	}

	// Update is called once per frame
	void Update () {
		water = player.GetComponent<playerHealth> ().water;
		gameObject.GetComponent<Text> ().text = "Water: " + water.ToString();
	}
}
