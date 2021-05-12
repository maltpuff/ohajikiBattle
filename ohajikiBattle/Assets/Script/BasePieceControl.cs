using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/*
    駒の操作に関するスクリプト、おもにクリックの判定とforceをする
    駒の親オブジェクトにアタッチするplayer1,player2の両方につける
    この際playerIDなどの記入をする
    もしかしたらもう一個親オブジェクトをつくったら生成の手間がなくなるかもしれない
*/
public class BasePiececontrol : MonoBehaviour
{
    /*バグったから一回消します
    //Rigidbody2D rigid2d;
    Vector2 startPos;
    public int playernumber;
    private GameObject select;


    public Slider shotGauge;
    //ボールの基本速度
    public float basespeed = 600f;
    //ゲージの上昇速度
    public float gagespeed = 1400f;
    float speed = 0;
    float gaugeLength = 0;
    private int moveNum;
    bool shotGaugeSet = false;
    private int turnCount = 1;
    [SerializeField] int playerID;
    RaycastHit2D hit2d;
    private GameObject direction;
    public GameObject destroyefect;
    [SerializeField] private GameObject gameobj;
    //駒の名称を取得して配列に入れて選択をできるようにする
    //子オブジェクトを全て取得して、配列に名前を格納名前が同じだったやつを動かす
    [SerializeField] private string playerName;
    public bool skill2start = false;
    ObjectManager ObjMana;
    TurnManager TurnMana;
    AllobjectManager AllobjMana;

    void Start()
    {
        //以前は動かす駒自体につけていた名残
        //今回から親オブジェクトが子オブジェクトを動かすため軽量化できる
        //ObjectManageから子オブジェクトを取得
        //rigid2d = this.GetComponent<Rigidbody2D>();
        //ここでなんらかのオブジェクトに付いたObjectManagerを取得することで値を保持できる
        ObjMana = this.GetComponent<ObjectManager>();
        AllobjMana = gameobj.GetComponent<AllobjectManager>();
        //TurnMana = GetComponent<>();
        turnCount = 1;
        //
        TurnMana = gameobj.GetComponent<TurnManager>();
    }

    void Update()
    {
        //ここでターンの切り替えをする
        if (turnCount % 2 == playerID % 2)
        {
            //勝利条件のチェック
            //AllobjMana.resultCheck();

            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                hit2d = Physics2D.Raycast((Vector2)ray.origin, (Vector2)ray.direction);
                //Debug.Log(ObjMana.getObjNum());
                if (hit2d.transform.gameObject.tag == playerName)
                {
                    this.startPos = Input.mousePosition;    //ここでドラックの確認
                    shotGaugeSet = true;                    //これがtrueの時ゲージがたまり始める
                }
            }

            if (shotGaugeSet)
            {
                if (Input.GetMouseButtonUp(0))
                {
                    shotGaugeSet = false;
                    Vector2 endPos = Input.mousePosition;
                    Vector2 startDirection = -1 * (endPos - startPos).normalized;
                    //動かす駒の番号を駒名から取得変換
                    moveNum = movePiece(hit2d.transform.gameObject.name) - 1;
                    //ここで動かすオブジェクトを決められる
                    ObjMana.player_rg[moveNum].AddForce(startDirection * speed);
                    //shotGaugeSet = false;
                    gaugeLength = 0;
                    shotGauge.value = gaugeLength;
                    //ここでターン更新をかける
                    TurnMana.GetComponent<TurnManager>().setNextTurn();

                }
                shotGaugeValue();//クリック中は稼働
            }
        }//ここでターンがおしまい
    }

    //もともとここに減速の文言があった
    void FixedUpdate()
    {

    }


    // ショットゲージ関数
    void shotGaugeValue()
    {
        //ゲージ長さをlengthに代入
        shotGauge.value = gaugeLength;
        gaugeLength += 0.015f;

        if (gaugeLength > 1.015f)   //ゲージがMaxでゼロに戻る
        {
            gaugeLength = 0;
        }

        // スピードをゲージ値から計算
        speed = gaugeLength * gagespeed + basespeed;
    }


    //クリックした駒と動かす駒を同期させる　ごり押しもっといい方法が知りたい
    //やってることはキャストstr→int
    int movePiece(string Num)
    {
        return int.Parse(Num);
    }

    //TurnManagerから操作してターンを進める
    //不具合があるなら毎ターン同期を兼ねて引数もたせると安全
    public void setTurn()
    {
        turnCount++;
    }*/
}