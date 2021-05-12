using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Panel_WallColorChange : MonoBehaviour {

    [SerializeField] GameObject[] colorWallBlue;
    [SerializeField] GameObject[] colorWallRed;

    private void Start()
    {
    }


    private void OnTriggerEnter2D(Collider2D c)
    {
        if (c.gameObject.tag == "Player1" || c.gameObject.tag == "Player2")
        {
            changeWall();

        }
    }
    //切り替え方式
    private void changeWall()
    {
        if(colorWallBlue[0].activeSelf  == true)
        {
            for (int i = 0; i < colorWallBlue.Length; i++)
            {
                colorWallBlue[i].SetActive(false);
                colorWallRed[i].SetActive(true);
            }
        }
        else
        {
            for (int i = 0; i < colorWallRed.Length; i++)
            {
                colorWallBlue[i].SetActive(true);
                colorWallRed[i].SetActive(false);
            }
        }
    }
}
