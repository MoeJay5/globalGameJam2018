using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickups : MonoBehaviour {

    public GameObject particle; 

	// Use this for initialization
	void Start () {
        particle = GameObject.Find("PickupParticle");
    }

    void OnTriggerEnter(Collider other) {
        if (other.tag.Equals("food"))
        {
            Destroy(other.gameObject);
            Instantiate(particle);
            gameObject.GetComponent<playerHealth>().food++;
        }
        if (other.tag.Equals("medicine"))
        {
            Destroy(other.gameObject);
            Instantiate(particle);
            gameObject.GetComponent<playerHealth>().medicine++;
        }
        if (other.tag.Equals("water"))
        {
            Destroy(other.gameObject);
            Instantiate(particle);
            gameObject.GetComponent<playerHealth>().water++;
        }
    }
}
