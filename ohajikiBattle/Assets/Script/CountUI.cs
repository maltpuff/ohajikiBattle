using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/* 駒の残数をテキストに出力する機能
 * AllobjectManagerから操作する
 */


public class CountUI : MonoBehaviour {

    [SerializeField]GameObject objManager;
    GameObject destroyArea;
    [SerializeField] int player1Count;
    [SerializeField] int player2Count;
    private Text counttext;

    StageManager stMana;
    private int gameMode;


    // Use this for initialization
    //ゲームモードを先に読み込んでおけるのでsetTextでスルーされない
    void Awake () {
        GameObject count = GameObject.Find("charactercounter");
        counttext = count.transform.GetComponent<Text>();
        stMana = this.GetComponent<StageManager>();
        gameMode = stMana.getGameMode();
    }

    public void setCountUI(int player1, int player2)
    {
        setCount(player1,player2);
        setText();
    }

    public void setPlayer1CountUI(int player1)
    {
        player1Count = player1;
        setText();
    }

    public void setPlayer2CountUI(int player2)
    {
        player2Count = player2;
        setText();
    }


    public void setCount(int player1,int player2)
    {
        player1Count = player1;
        player2Count = player2;
        setText();
    }

    //どこかで値変更(set)されたらテキストを変更する
    //もしくはsetをした後に個別のsetTextを作り呼び出す
    public void setText()
    {
        if (gameMode == 2)
        {
            counttext.text = "BLUE:残" + player1Count + "\nRED:残" + player2Count;
        }
        else if (gameMode == 1)
        {
            counttext.text = "Player BLUE:残" + player1Count+"\nターゲット:残" + player2Count;

        }
        //ここでステージごとのテキストを設定
    }
}
