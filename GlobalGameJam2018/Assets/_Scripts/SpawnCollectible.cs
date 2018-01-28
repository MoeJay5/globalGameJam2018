using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCollectible : MonoBehaviour {

	public GameObject food;
	public GameObject medicine;
	public GameObject water;

	public float spawnPick;

	// Use this for initialization
	void Start () {
		Rigidbody foodRB = food.GetComponent<Rigidbody> ();
		Rigidbody medicineRB = medicine.GetComponent<Rigidbody> ();
		Rigidbody waterRB = water.GetComponent<Rigidbody> ();
		spawnPick = Random.Range(0.0f,1.0f);

		if (spawnPick <= .34f){
			Instantiate(foodRB, transform.position, Quaternion.identity);
		} else if (spawnPick > .34f && spawnPick <= .67f){
			Instantiate(medicineRB, transform.position, Quaternion.identity);
		} else {
			Instantiate(waterRB, transform.position, Quaternion.identity);
		}
	}
}
