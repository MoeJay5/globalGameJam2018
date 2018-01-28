using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudManager : MonoBehaviour {

    public float cloudSpeed = 4;

    // Update is called once per frame
    void Update () {
        transform.Translate(transform.forward * cloudSpeed * Time.deltaTime);
	}
}
