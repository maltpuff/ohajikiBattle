using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gamemanagement : MonoBehaviour {

    GameObject chara1;
    GameObject chara2;
    GameObject chara3;
    GameObject enemy1;
    GameObject enemy2;
    GameObject enemy3;
    GameObject turn;
    string charaname = "Player";


	void Start () {
        chara1 = GameObject.Find("player1");
        chara2 = GameObject.Find("player2");
        chara3 = GameObject.Find("player3");
        enemy1 = GameObject.Find("enemy1");
        enemy2 = GameObject.Find("enemy2");
        enemy3 = GameObject.Find("enemy3");
        turn = GameObject.Find("turn");
    }
	

    public void turnControl()
    {
        if (chara1 != null )
            chara1.GetComponent<CCs>().SetTurn();
        if (chara2 != null)
            chara2.GetComponent<CCs>().SetTurn();
        if (chara3 != null)
            chara3.GetComponent<CCs>().SetTurn();
        if (enemy1 != null)
            enemy1.GetComponent<CCs>().SetTurn();
        if (enemy2 != null)
            enemy2.GetComponent<CCs>().SetTurn();
        if (enemy3 != null)
            enemy3.GetComponent<CCs>().SetTurn();

        if(charaname=="Player")
        {
            charaname = "Enemy";
        }
        else
        {
            charaname = "Player";
        }

        turn.GetComponent<Turn>().nextturn(charaname);


    }
}
