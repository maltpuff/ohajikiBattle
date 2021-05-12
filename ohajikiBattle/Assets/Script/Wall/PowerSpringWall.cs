using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerSpringWall : MonoBehaviour {

    private float speed = 1200f;
    Vector2 force = new Vector2(2f, 0f);

    void OnCollisionEnter2D(Collision2D c)
    {
        if (c.transform.tag == "Player1" || c.transform.tag == "Player2" || c.transform.tag == "Target")
        {
            
            c.collider.attachedRigidbody.AddForce(force * speed);
            //Debug.Log(force);
        }
    }

}
