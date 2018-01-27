using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpDetection : MonoBehaviour
{
    public bool isGrounded = false;

    void OnCollisionStay(Collision col)
    {
		ContactPoint contact = col.contacts[0];
		if (contact.point.y < gameObject.transform.position.y)
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit(Collision col)
    {
            isGrounded = false;
    }
}
