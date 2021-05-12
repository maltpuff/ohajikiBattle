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
public class Piececontrol: MonoBehaviour
{
    [SerializeField] private string playerName;
    [SerializeField] private GameObject gameobj;
    [SerializeField] int playerID; //インスペクターでplayer1にアタッチされているPiececontrolは1、player2の場合は0が代入されています
    Vector2 startPos;
    RaycastHit2D hit2d;
    GameManage GameMana;
    TurnManager TurnMana;
    StageManager stMana;
    AllobjectManager AllobjMana;
    public int playernumber;
    private Slider shotGauge;
    //ボールの基本速度
    public float basespeed = 600f;
    //ゲージの上昇速度
    public float gagespeed = 1400f;
    float speed = 0;
    float gaugeLength = 0;
    bool shotGaugeSet = false;
    public GameObject destroyefect;
    public bool skill2start = false;
    private bool ActionTime; //ターン中（ユーザーの操作後とコマの動作中）にtrueになる変数
    private GameObject yajirushi_prefab; //ショットアシスト用の矢印プレハブ
    private GameObject yajirusiObj;      //矢印のインスタンス
    private Vector2 piecePos;
    private bool active;

    void Start()
    {
        GameObject shotGaugeObj = GameObject.Find("Slider");
        shotGauge = shotGaugeObj.GetComponent<Slider>();

        GameMana = gameobj.GetComponent<GameManage>();
        TurnMana = gameobj.GetComponent<TurnManager>();
        stMana = gameobj.GetComponent<StageManager>();
        AllobjMana = gameobj.GetComponent<AllobjectManager>();

        ActionTime = false;

        active = false;   //矢印から見てどれがアクティブかわかるようにする変数、非アクティブ状態で初期化
        yajirushi_prefab = (GameObject)Resources.Load("yajirusi");  //リソースから矢印を読み込む
    }

    void Update()
    {
        //二人プレイ用
        if (stMana.getGameMode() == 2)
        {
            //GameManageのターン処理が終わっている かつ ターン対象プレイヤーにアタッチされているPiececontrolの場合
            if (!GameMana.getTurnFlag() && TurnMana.GetTurnCount() % 2 == playerID % 2)
            {
                PieceControler();
            }
        }
        //一人プレイ用
        else if(stMana.getGameMode() == 1)
        {
            //GameManageのターン処理が終わっている
            if (!GameMana.getTurnFlag())
            {
                PieceControler();
            }
        }

        //ユーザーの操作が行われた状態　かつ　アクティブ状態のコマがない場合
        //ActionTimeがtrueの時のみコマの動作確認が行われる
        if (ActionTime && !AllobjMana.ExistsActivAll())
        {
            //ActionTimeを終了
            ActionTime = false;
            //ターン更新用の旗をあげる
            GameMana.setTurnFlag(true);
        }
    }

    // ショットゲージ関数
    void shotGaugeValue()
    {
        //ゲージ長さをlengthに代入
        shotGauge.value = gaugeLength;
        gaugeLength += 0.015f;
        
        if (gaugeLength > 1.1f)   //ゲージがMaxでゼロに戻る
        {
            gaugeLength = 0;
        }

        // スピードをゲージ値から計算
        speed = gaugeLength * gagespeed + basespeed;
    }

    //コマの操作をするメソッド
    private void PieceControler()
    {
        //マウスの入力　かつ　このターン内で一回目の操作である場合
        if (Input.GetMouseButtonDown(0) && !GameMana.getUserPlayed())
        {
            startPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            hit2d = Physics2D.Raycast(startPos, Vector2.zero);

            //レイキャストがコマに当たっている場合
            if (hit2d.rigidbody != null)
            {
                //二人プレイ用
                if (stMana.getGameMode() == 2)
                {
                    //ターン対象プレイヤーのコマだった場合
                    if (hit2d.transform.gameObject.tag == playerName)
                    {
                        this.startPos = Input.mousePosition;    //ここでドラックの確認
                        shotGaugeSet = true;                    //これがtrueの時ゲージがたまり始める

                        piecePos = hit2d.transform.position;    //コマの座標を代入
                        active = true;                          //このピースコントローラがアクティブだと伝える
                        //矢印をインスタンス化
                        yajirusiObj = Instantiate(yajirushi_prefab, hit2d.transform.position, Quaternion.identity);
                    }
                }
                //一人プレイ用
                else if (stMana.getGameMode() == 1)
                {
                    //青いコマか赤いコマだった場合
                    if (hit2d.transform.gameObject.tag == "Player1" || hit2d.transform.gameObject.tag == "Player2")
                    {
                        this.startPos = Input.mousePosition;    //ここでドラックの確認
                        shotGaugeSet = true;                    //これがtrueの時ゲージがたまり始める

                        piecePos = hit2d.transform.position;    //コマの座標を代入
                        active = true;                          //このピースコントローラがアクティブだと伝える
                        //矢印をインスタンス化
                        yajirusiObj = Instantiate(yajirushi_prefab, hit2d.transform.position, Quaternion.identity);
                    }
                }
            }
        }

        if (shotGaugeSet)
        {
            shotGaugeValue();//クリック中は稼働
            //マウスのボタン入力が終了したとき
            if (Input.GetMouseButtonUp(0))
            {
                shotGaugeSet = false;
                Vector2 endPos = Input.mousePosition;
                Vector2 startDirection = -1 * (endPos - startPos).normalized;
                //インスタンス化していた矢印を削除
                Destroy(yajirusiObj);
                active = false;  //このピースコントローラが非アクティブだとだと伝える
                //レイキャストのあたったオブジェクトを動かす
                hit2d.rigidbody.AddForce(startDirection * speed);

                gaugeLength = 0;
                shotGauge.value = gaugeLength;
                //コマの操作をしたためActionTimeを開始
                ActionTime = true;
                //一回目の操作したため合図をする
                GameMana.setUserPlayed(true);
            }
        }
    }

    public Vector2 GetpiecePos()
    {
        return piecePos;
    }
    public bool Getactive()
    {
        return active;
    }
    public float GetGaugeValue()
    {
        return shotGauge.value;
    }
}