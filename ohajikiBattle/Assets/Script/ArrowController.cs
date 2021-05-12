using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowController : MonoBehaviour {

    private GameObject arrowObj;
    private SpriteRenderer sRend;

    private GameObject Player1Obj;
    private GameObject Player2Obj;
    private Piececontrol piecectrl1;
    private Piececontrol piecectrl2;
    private Vector2 startPos;
    private Vector2 nowPos;
    private Vector2 direction;

    void Start () {

        arrowObj = this.transform.Find("arrow").gameObject;
        sRend = arrowObj.GetComponent<SpriteRenderer>();

        Player1Obj = GameObject.Find("player1");
        if (Player1Obj != null) {
            piecectrl1 = Player1Obj.GetComponent<Piececontrol>();
        }
        Player2Obj = GameObject.Find("player2");
        if (Player2Obj != null)
        {
            piecectrl2 = Player2Obj.GetComponent<Piececontrol>();
        }

        //アクティブなピースコントロールから、ユーザーがつかんでいるコマの座標を取得
        if (piecectrl1.Getactive() == true)
        {
            //コマの座標を取得
            startPos = piecectrl1.GetpiecePos();
        }
        else
        {
            //コマの座標を取得
            startPos = piecectrl2.GetpiecePos();
        }
        //Debug.Log(startPos);

        //矢印表示時から進行方向を向くよう初期化
        nowPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);                        //マウスの現在位置を追跡して代入する
        direction = -1 * (nowPos - startPos).normalized;     //ベクトルを計算

        //Debug.Log(direction);  //単位ベクトル
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;  //単位ベクトルを角度に変換
        this.transform.rotation = Quaternion.Euler(0.0f, 0.0f, angle);        //角度をを代入
    }
	
	void Update () {

        //ショットゲージの量に応じて色を変える
        if (piecectrl1.Getactive() == true)
        {
            //Debug.Log(piecectrl1.GetGaugeValue());
            sRend.material.color = new Color(255, 1- piecectrl1.GetGaugeValue(), 1 - piecectrl1.GetGaugeValue());
        }
        else
        {
            //Debug.Log(piecectrl2.GetGaugeValue());
            sRend.material.color = new Color(255, 1 - piecectrl1.GetGaugeValue(), 1 - piecectrl1.GetGaugeValue());
        }

        //マウスの位置に対応して矢印の向きを変える
        nowPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);                        //マウスの現在位置を追跡して代入する
        direction = -1 * (nowPos - startPos).normalized;     //ベクトルを計算

        //Debug.Log(direction);  //単位ベクトル
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;  //単位ベクトルを角度に変換
        this.transform.rotation = Quaternion.Euler(0.0f, 0.0f, angle);        //角度をを代入
    }
}
