using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//
//接触オブジェクトの反発方向へ1200の力を加える
//springWallにアタッチ
public class SpringWall : MonoBehaviour {

    [SerializeField] private float speed = 1200f;

    void OnCollisionExit2D(Collision2D c)
    {
        if (c.transform.tag == "Player1"|| c.transform.tag == "Player2" || c.transform.tag =="Target")
        {
            Vector2 force = c.collider.attachedRigidbody.velocity.normalized;
            c.collider.attachedRigidbody.AddForce(force * speed);
            //Debug.Log(force);
        }
    }

}
