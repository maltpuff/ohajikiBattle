using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllobjectManager : MonoBehaviour {

    [SerializeField] private int gameMode;
    [SerializeField] GameObject player1objManager;
    [SerializeField] GameObject player2objManager;
    [SerializeField] private int player1count;
    [SerializeField] private int player2count;
    CountUI cUI;
    StageManager stMana;
    ObjectManager p1objMana;
    ObjectManager p2objMana;


    // Use this for initialization
    void Start () {
        stMana = this.GetComponent<StageManager>();
        cUI = this.GetComponent<CountUI>();
        gameMode = stMana.getGameMode();
        gameModeSelect(gameMode);
        //cUI.setText();
        p1objMana = player1objManager.GetComponent<ObjectManager>();
        p2objMana = player2objManager.GetComponent<ObjectManager>();
    }


    //getter,setter の設定
    public void setPlayerCount(int p1,int p2)
    {
        player1count = p1;
        player2count = p2;
        cUI.setCountUI(player1count, player2count);
        
    }
    public void setPlayer1Count(int p1)
    {
        player1count = p1;
        cUI.setPlayer1CountUI(player1count);
        
    }

    public void setPlayer2Count(int p2)
    {
        player2count = p2;
        cUI.setPlayer2CountUI(player2count);
        
    }

    public int getPlayer1Count()
    {
        return player1count;
    }

    public int getPlayer2Count()
    {
        return player2count;
    }
	
	private void gameModeSelect(int N)
    {
        if (N == 2)
        {
            //数値の初期化　駒数が違っても対応可能
            p1objMana = player1objManager.GetComponent<ObjectManager>();
            p2objMana = player2objManager.GetComponent<ObjectManager>();
            player1count = p1objMana.getObjNum();
            player2count = p2objMana.getObjNum();
            //全体の駒を取得できたのでCountUIを初期化
            cUI.setCountUI(player1count, player2count);
            cUI.setText();
        }
        else if(N == 1)
        {
            //数値の初期化　駒数が違っても対応可能
            p1objMana = player1objManager.GetComponent<ObjectManager>();
            player1count = p1objMana.getObjNum();
            //全体の駒を取得できたのでCountUIを初期化
            //現時点では全部のStageで取得する
            //Stageごとミッションがあるのでそれに合わせてStageManagerで管理true/false
            //if(stMana.getStage()==1)
            //{
            p2objMana = player2objManager.GetComponent<ObjectManager>();
                player2count = p2objMana.getObjNum();
                cUI.setPlayer2CountUI(player2count);
            //}
            cUI.setPlayer1CountUI(player1count);
            cUI.setText();
        }
    }

    //全てのコマの中にアクティブ状態のコマが存在するか確認するメソッド
    //アクティブなコマがひとつでもあればtrue　そうでなければfalseをかえす
    public bool ExistsActivAll()
    {
        if (p1objMana.ExistsActivChileds() || p2objMana.ExistsActivChileds())
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    //ObjectManagerからコマの数を取得
    public void AllPieceCount()
    {
        p1objMana.getObject();
        player1count = p1objMana.getObjNum();
        p2objMana.getObject();
        player2count = p2objMana.getObjNum();

        cUI.setPlayer1CountUI(player1count);
        cUI.setPlayer2CountUI(player2count);
    }
}
