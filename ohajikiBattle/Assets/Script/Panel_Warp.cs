using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Panel_Warp : MonoBehaviour
{
    [SerializeField] GameObject warpPosObj;
    Vector2 warpPos;
    private void Start()
    {
        warpPos.Set(warpPosObj.transform.position.x, warpPosObj.transform.position.y);
    }

    private void OnTriggerEnter2D(Collider2D c)
    {
        if (c.gameObject.tag == "Player1" || c.gameObject.tag == "Player2") 
        {
            //c.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            c.gameObject.GetComponent<Transform>().position = warpPos;
        }
    }
}
