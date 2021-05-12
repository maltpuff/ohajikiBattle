using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/* ターンをテキストに表示する機能
 * TurnManagerから操作する
 */

public class TurnUI : MonoBehaviour {

    private Text turnText;
    public string player;
    private int turnCount;
    [SerializeField] private int gameMode;

    StageManager stMana;

    // Use this for initialization
    void Start () {

        GameObject turnObj = GameObject.Find("turn");
        turnText = turnObj.transform.GetComponent<Text>();

        stMana = this.GetComponent<StageManager>();
        gameMode = stMana.getGameMode();

        turnCount = 1;
        player = "BLUE";
        if (gameMode==1)
        {
            turnText.text = turnCount + "ターン目";
                                  
        }
        else if(gameMode ==2)
        {
            turnText.text = turnCount + "ターン目\n"
                                  + player + "ターン";
        }
    }
	
	

    public void setTurn(int count)
    {
        turnCount = count;
        checkPlayer(); 
        setTurnText();
    }

    void setTurnText()
    {
        if (gameMode == 1)
        {
            turnText.text = turnCount + "ターン目";
        }
        else if (gameMode == 2)
        {
            turnText.text = turnCount + "ターン目\n"
                                  + player + "ターン";
        }
    }

    void checkPlayer()
    {
        //一人プレイ用の
        if(gameMode == 1)
        {
            player = "BLUE";
        }
        //二人プレイ用の
        else if (gameMode == 2)
        {
            if (turnCount % 2 == 1)
            {
                player = "BLUE";
            }
            else
            {
                player = "RED";
            }
        }
        
    }
}
