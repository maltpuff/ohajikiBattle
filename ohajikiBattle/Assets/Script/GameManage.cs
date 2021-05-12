using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManage : MonoBehaviour {

    [SerializeField] private bool TurnFlag;
    [SerializeField] private GameObject gameobj;
    [SerializeField] private GameObject stageobjs;
    TurnManager TurnMana;
    StageManager stMana;
    Result result;
    StageReseter streset;
    private int gameMode;
    private bool UserPlayed;
    private bool resultdisplay = false;

    [SerializeField] private GameObject player1;
    [SerializeField] private GameObject player2;

    // Use this for initialization
    void Start () {

        TurnMana = gameobj.GetComponent<TurnManager>();
        streset = stageobjs.GetComponent<StageReseter>();
        stMana = this.GetComponent<StageManager>();
        result = this.GetComponent<Result>();

        //ユーザーの操作後である、かつコマの動きがない時にtrueとなる変数
        TurnFlag = false;
        //ゲームモードを取得
        gameMode = stMana.getGameMode();
        //コマを一回操作するとtrueになる変数（ターン内に何度も操作できるようにすることを防止する）
        UserPlayed = false;

    }
	
	// Update is called once per frame
	void Update () {

        //ユーザーの操作後である、かつコマの動きがない場合
        if (TurnFlag)
        {
            //勝利条件のチェック と 結果の表示があったかを代入
            resultdisplay = resultCheck();

            //結果の表示がなければターン更新
            if (!resultdisplay)
            {
                //ここでターン更新をかける
                TurnMana.GetComponent<TurnManager>().setNextTurn();
                //ステージのオブジェクトにリセットをかける
                StageReset();

                //ターン更新処理が完了した合図
                TurnFlag = false;
                //ユーザーがコマの操作をすること許可
                UserPlayed = false;
            }
            //結果の表示があった場合
            else
            {
                //ターン更新処理が完了した合図
                TurnFlag = false;
            }
        }
        //ユーザーの操作中、またはコマが動いている場合
        else
        {
            //何もしない
        }
    }

    public void setTurnFlag(bool change)
    {
        TurnFlag = change;
    }

    public void setUserPlayed(bool change)
    {
        UserPlayed = change;
    }

    public bool getTurnFlag()
    {
        return TurnFlag;
    }

    public bool getUserPlayed()
    {
        return UserPlayed;
    }

    //プレイヤーのコマの数に応じて結果を表示するメソッド
    //結果を表示した場合はtureを返し、そうでなければfalseを返す
    private bool resultCheck()
    {
        //二人プレイ用
        if (gameMode == 2)
        {
            resultdisplay = result.countCheck();
        }
        //一人プレイ用
        else if (gameMode == 1)
        {
            resultdisplay = result.singleCountCheck();
        }

        return resultdisplay;
    }

    //ステージにセットされているアイテムのリセット
    private void StageReset()
    {
        streset.ResetPanel();
    }
}
