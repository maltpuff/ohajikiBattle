using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
    駒の操作後にターンを進めるスクリプト
    gamemanager系のオブジェクトにアタッチし
    シーン内に一つだけ使う
*/
public class TurnManager : MonoBehaviour {

    //それぞれのプレイヤーのpiececontrolを取得してターンをセットする
    //現状では駒を動かした瞬間に次ターンが始まるので何らかの方法で全部止まったらにした方がいいかも
    //方法としては動かした駒が止まった時に他の駒が止まっているかどうかの確認をして動いてる駒にその確認を止まった時にさせるとか
    [SerializeField] private GameObject player1;
    [SerializeField] private GameObject player2;
    [SerializeField] private int turnCount;
    
    // Use this for initialization
    void Start () {
        turnCount = 1; //初期化   
    }
	

    //ターンの更新
    //外部から呼び出されて更新するのでpublic
    public void setNextTurn()
    {
        turnCount++;
        this.GetComponent<TurnUI>().setTurn(turnCount);
    }

    public int GetTurnCount()
    {
        return turnCount;
    }
}
