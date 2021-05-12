using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 *エリア外へ出たコマを削除して残存コマ数の計算するスクリプト 
 * 盤となるオブジェクトにアタッチする(Gamemanager -> battleArea)
 * この中では値を一切保持しない
 */


public class DestroyArea : MonoBehaviour
{
    //ゲームモード(人数)はAllobjectManagerから取得する
    //[SerializeField] private int gameMode;

    //[SerializeField] private int player1Counter;
    //[SerializeField] private int player2Counter;
    //[SerializeField] private GameObject gameManager;

    //public GameObject canvas;

    //StageManager stMana;

    private void Start()
    {
        //駒数の取得と駒の数の初期化
        //stMana = gameManager.GetComponent<StageManager>();
        //gameMode = stMana.getGameMode();
    }

    //範囲から出たオブジェクトを引数にとる
    //今回の場合は外に出たオブジェクトを削除し、残存の駒をカウントする役目をもつ
    void OnTriggerExit2D(Collider2D c)
    {
        //外に出たオブジェクトを削除
        Destroy(c.gameObject);
    } 
}

