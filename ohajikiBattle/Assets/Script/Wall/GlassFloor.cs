using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlassFloor : MonoBehaviour {

    [SerializeField] private int life = 4;
    [SerializeField] private Sprite[] state = new Sprite[4];
    [SerializeField] private GameObject glassArea;
    [SerializeField] private GameObject destroyArea;
    SpriteRenderer mainSpriteRenderer;

    // Use this for initialization
    void Start()
    {
        mainSpriteRenderer = glassArea.GetComponent<SpriteRenderer>();
    }

    void OnTriggerEnter2D(Collider2D c)
    {
        if (c.transform.tag == "Player1" || c.transform.tag == "Player2")
        {
            if (life != 0)
            {
                lifeDic();
                changeSprite();
            }
        }
    }

    void lifeDic()
    {
        life--;
    }

    void changeSprite()
    {
        if (life != 0)
        {
            mainSpriteRenderer.sprite = state[life];
        }
        else
        {
            Destroy(glassArea);
            destroyArea.SetActive(true);
        }
    }
}
