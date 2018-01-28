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

          if (other.tag.Equals("controllerBox"))
        {
            Destroy(other.gameObject);
            Instantiate(particle);
            gameObject.GetComponent<playerHealth>().controllerBox++;
        }
          if (other.tag.Equals("broadcastDish"))
        {
            Destroy(other.gameObject);
            Instantiate(particle);
            gameObject.GetComponent<playerHealth>().broadcastDish++;
        }
          if (other.tag.Equals("battery"))
        {
            Destroy(other.gameObject);
            Instantiate(particle);
            gameObject.GetComponent<playerHealth>().battery++;
        }
          if (other.tag.Equals("microphone"))
        {
            Destroy(other.gameObject);
            Instantiate(particle);
            gameObject.GetComponent<playerHealth>().microphone++;
        }
    }
}
