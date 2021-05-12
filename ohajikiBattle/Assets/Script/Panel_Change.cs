using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Panel_Change : MonoBehaviour {

    [SerializeField] private Sprite blue;
    [SerializeField] private Sprite red;

    [SerializeField] private int ChangeMode;
    GameObject newPar;

    //パネルに入った時に駒の色を切り替える
    private void OnTriggerEnter2D(Collider2D c)
    {
        if (c.gameObject.tag == "Player2" || c.gameObject.tag == "Player1")
        {
            // 1:青赤切り替え
            if (ChangeMode == 1)
            {
                changeBlueORRed(c);
            }
            //赤ににする
            else if (ChangeMode == 2)
            {
                changeBlue(c);
            }
            //青にする
            else if (ChangeMode == 3)
            {
                changeRed(c);
            }
        }
    }

    //青と赤を入れ替える
    private void changeBlueORRed(Collider2D c)
    {
        //レイヤーはint型で返されるため名称を取得する
        if (LayerMask.LayerToName(c.gameObject.layer) == "player1")
        {
            c.gameObject.layer = LayerMask.NameToLayer("player2");
            c.gameObject.tag = "Player2";
            c.GetComponent<SpriteRenderer>().sprite = red;

            newPar = GameObject.Find("player2");
            if(newPar != null)
            {
                c.gameObject.transform.parent = newPar.gameObject.transform;
            }
        }
        else if (LayerMask.LayerToName(c.gameObject.layer) == "player2")
        {
            c.gameObject.layer = LayerMask.NameToLayer("player1");
            c.gameObject.tag = "Player1";
            c.GetComponent<SpriteRenderer>().sprite = blue;

            newPar = GameObject.Find("player1");
            if (newPar != null)
            {
                c.gameObject.transform.parent = newPar.gameObject.transform;
            }
        }
    }

    //入った駒を赤にする
    private void changeBlue(Collider2D c)
    {
        if (LayerMask.LayerToName(c.gameObject.layer) == "player1")
        {
            c.gameObject.layer = LayerMask.NameToLayer("player2");
            c.gameObject.tag = "Player2";
            c.GetComponent<SpriteRenderer>().sprite = red;

            newPar = GameObject.Find("player2");
            if (newPar != null)
            {
                c.gameObject.transform.parent = newPar.gameObject.transform;
            }

        } 
    }

    //入った駒を青にする
    private void changeRed(Collider2D c)
    {
        if (LayerMask.LayerToName(c.gameObject.layer) == "player2")
        {
            c.gameObject.layer = LayerMask.NameToLayer("player1");
            c.gameObject.tag = "Player1";
            c.GetComponent<SpriteRenderer>().sprite = blue;

            newPar = GameObject.Find("player1");
            if (newPar != null)
            {
                c.gameObject.transform.parent = newPar.gameObject.transform;
            }
        }
    }
}
