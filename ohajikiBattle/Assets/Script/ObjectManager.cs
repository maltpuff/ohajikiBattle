using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    プレイヤーの親オブジェクトにつけることで子オブジェクトを取得する
    Piececontrolで取得したオブジェクトを使う
 *
*/
public class ObjectManager : MonoBehaviour
{

    //[SerializeField] private int playerCount;
    [SerializeField] private int objNum;
    [SerializeField] private GameObject gameMana;
    //アタッチされたオブジェクトのデータを取得
    //rigidbody2Dと子オブジェクトを配列に格納する
    public GameObject player;
    public GameObject[] player_child;
    public Rigidbody2D[] player_rg;
    Rigidbody2D rigid2d;

    // ゲーム開始時の初期化
    void Awake()
    {
        player = this.gameObject;
        objNum = player.transform.childCount;
        //objNum = 3;
        //setObjCount(objNum);
        player_child = new GameObject[player.transform.childCount * 2];   //プレイヤー1のオブジェクト数を初期化
        player_rg = new Rigidbody2D[player.transform.childCount * 2];
        getObject();
    }

    public void getObject()
    {

        //プレイヤーの子オブジェクトを取得
        for (int i = 0; i < player.transform.childCount; i++)
        {
            //player1_child[i] = player1.transform.GetChild(i).gameObject;
            player_child[i] = player.transform.GetChild(i).gameObject;
            player_rg[i] = player_child[i].GetComponent<Rigidbody2D>();
        }
    }

    public int getObjNum()
    {
        return player.transform.childCount;
    }

    //アクティブ状態のコマがあるか判断するメソッド
    //アクティブ状態のコマがあればtrue そうでなければfalseを返す
    public bool ExistsActivChileds()//player_rg[i].velocity.magnitude != 0
    {
        for (int i = 0; i < getObjNum(); i++)
        {
            //今存在している子オブジェクト　かつ　スリープ状態でないオブジェクト
            if (CheckObjExists(player_child[i]) && !player_rg[i].IsSleeping())
            {
                //スリープ状態でないオブジェクトを発見
                //Debug.Log("どれかがアクティブ状態");
                return true;
            }
            else
            {
                //止まっている場合は何もしない
            }
        }
        //Debug.Log("すべてスリープ状態です");
        return false;
    }

    //ゲームオブジェクトが存在するか確認するメソッド
    private bool CheckObjExists(GameObject Obj)
    {
        if (Obj)
        {
            //Debug.Log("まだ生きてる");
            return true;
        }
        else
        {
            //Debug.Log("死亡確認済み");
            return false;
        }
    }



    /*
    //現時点でプレイヤーオブジェクトは数値を持つ意味はない
    //主にDestroyAreaで駒が減った時に呼び出される
    public void setObjCount(int pc)//player 1 count の略
    {
        playerCount = pc;
        //CountUIへ減った結果を送る
        //cUI.setCountUI(pl1c, pl2c);
    }
    */
}
