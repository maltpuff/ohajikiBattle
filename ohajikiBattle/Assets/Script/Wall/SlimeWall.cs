using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeWall : MonoBehaviour {

    private Vector3 contactPos;

    void OnCollisionEnter2D(Collision2D c)
    {
        if (c.transform.tag == "Player1" || c.transform.tag == "Player2" || c.transform.tag == "Target")
        {
            contactPos.Set(c.contacts[0].point.x, c.contacts[0].point.y, 0);
            Debug.Log(contactPos);
            c.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            c.gameObject.GetComponent<Transform>().position = contactPos;
        }
    }
}
