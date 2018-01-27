using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickups : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider other) {
        if (other.tag.Equals("food"))
        {
            Debug.Log("food");
            Destroy(other.gameObject);
            gameObject.GetComponent<playerHealth>().food++;
        }
        if (other.tag.Equals("medicine"))
        {
            Debug.Log("medicine");
            Destroy(other.gameObject);
            gameObject.GetComponent<playerHealth>().medicine++;
        }
        if (other.tag.Equals("water"))
        {
            Debug.Log("water");
            Destroy(other.gameObject);
            gameObject.GetComponent<playerHealth>().water++;
        }
    }
}
