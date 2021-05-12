using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Result : MonoBehaviour {

    [SerializeField] private int gameMode;
    [SerializeField] private int stage;

    private GameObject winnerB;
    private GameObject drow;
    private GameObject winnerA;

    private GameObject stageclear;
    private GameObject gameover;

    StageManager stMana;
    ButtonManager btnMana;
    AllobjectManager allobjMana;
    public GameObject canvas;

    // Use this for initialization
    void Start () {
        canvas = GameObject.Find("Canvas");
        stMana = this.GetComponent<StageManager>();
        allobjMana = this.GetComponent<AllobjectManager>();
        gameMode = stMana.getGameMode();
        stage = stMana.getStage();
        btnMana = canvas.GetComponent<ButtonManager>();

        gameSetting(gameMode);
    }

    private void gameSetting(int gamemode)
    {
        if (gamemode == 1)
        {
            stageclear = canvas.transform.Find("StageClear").gameObject;
            gameover = canvas.transform.Find("GameOver").gameObject;
            btnMana.hideBtn();
        }
        else if (gamemode == 2)
        {
            winnerA = canvas.transform.Find("WinnerA").gameObject;
            drow = canvas.transform.Find("Drow").gameObject;
            winnerB = canvas.transform.Find("WinnerB").gameObject;
            btnMana.hideBtn();
        }
    }

    //外部から値を直接入力するのはあまりよくなさそう


    //プレイヤーのコマの数に応じて結果を表示するメソッド
    //結果を表示した場合はtureを返し、そうでなければfalseを返す

    //二人プレイ用
    public bool countCheck()
    {
        //現在のコマの数を更新
        allobjMana.AllPieceCount();
        //AllobjectManagerから現在のコマ数を取得
        int p1 = allobjMana.getPlayer1Count();
        int p2 = allobjMana.getPlayer2Count();
        //Debug.Log(p1);
        //Debug.Log(p2);

        if (p1 == 0 && p2 == 0)
        {
            //引き分けになるときは必ず先に一回青か赤の勝利表示が出るので消す必要がある
            winnerA.gameObject.SetActive(false);
            winnerB.gameObject.SetActive(false);
            drow.gameObject.SetActive(true);
            btnMana.displayBtn();
            btnMana.SystemButtonDisplay();//システムボタンの非表示化

            return true;
        }
        else if (p2 == 0)
        {
            winnerA.gameObject.SetActive(true);
            btnMana.displayBtn();
            btnMana.SystemButtonDisplay();//システムボタンの非表示化

            return true;
        }
        else if (p1 == 0)//1が負け=2の勝利
        {
            winnerB.gameObject.SetActive(true);
            btnMana.displayBtn();
            btnMana.SystemButtonDisplay();//システムボタンの非表示化

            return true;
        }
        else
        {
            return false;
        }
    }

    //一人プレイ用
    public bool singleCountCheck()
    {
        //現在のコマの数を更新
        allobjMana.AllPieceCount();
        //AllobjectManagerから現在のコマ数を取得
        int p1 = allobjMana.getPlayer1Count();
        int p2 = allobjMana.getPlayer2Count();

        if (p2 == 0)//Clear
        {
            //引き分けになるときは必ず先に一回合否の表示が出るので消す必要がある
            stageclear.gameObject.SetActive(true);
            gameover.gameObject.SetActive(false);
            btnMana.displayBtn();
            btnMana.displayNextStageBtn();
            btnMana.SystemButtonDisplay();//システムボタンの非表示化

            return true;
        }
        else if (p1 == 0)//プレイヤー全滅
        {
            gameover.gameObject.SetActive(true);
            btnMana.displayBtn();
            btnMana.SystemButtonDisplay();//システムボタンの非表示化

            return true;
        }
        else
        {
            return false;
        }
    }
}
