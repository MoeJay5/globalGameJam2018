using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpDetection : MonoBehaviour
{
    [HideInInspector]
    public bool isGrounded = false;

    void OnCollisionEnter(Collision col)
    {
		if (col.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit(Collision col)
    {
        if (col.gameObject.tag == "Ground")
        {
            isGrounded = false;
        }
    }
}
