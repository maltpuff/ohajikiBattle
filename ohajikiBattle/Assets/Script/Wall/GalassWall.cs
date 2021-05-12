using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GalassWall : MonoBehaviour {


    [SerializeField] private int life = 4;
    [SerializeField] private Sprite [] state = new Sprite[3];
    SpriteRenderer mainSpriteRenderer;

    // Use this for initialization
    void Start () {
        mainSpriteRenderer = this.GetComponent<SpriteRenderer>();
    }

    void OnCollisionExit2D(Collision2D c)
    {
        if (c.transform.tag == "Player1" || c.transform.tag == "Player2")
        {
            lifeDic();
            changeSprite();
        }
    }

    void lifeDic()
    {
        life--;
        if (life == 0)
        {
            Destroy(this.gameObject);
        }
    }

    void changeSprite()
    {
        if (life != 0)
        {
            mainSpriteRenderer.sprite = state[life - 1];
        }
    }
}
