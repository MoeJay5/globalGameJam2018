using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateMedicine : MonoBehaviour {

	public GameObject player;
	public int medicine;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player");
	}

	// Update is called once per frame
	void Update () {
		medicine = player.GetComponent<playerHealth> ().medicine;
		gameObject.GetComponent<Text> ().text = "Medicine: " + medicine.ToString();
	}
}
