using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
 * このスクリプトでボタンの処理を一括できます
 * ボタン名とそのボタンの処理内容を追加できます
 * 
 * このスクリプトはボタンの親オブジェクト(Canvasなど)にアタッチされている
 * BaseButtunControllerのButtonの枠にぶち込んでください
 * 
 * 各ボタンのOnClickは、親オブジェクト(Canvasなど)をぶち込んでBaseButtunControllerのOnClick()を選んでください
 */

public class GameButtonController : BaseButtonController {

    ButtonManager buttonMana;
    StageSelectCreater stageCre;
    [SerializeField] GameObject gameManager;
    void Start()
    {
        GameObject canvas = GameObject.Find("Canvas");
        buttonMana = canvas.GetComponent<ButtonManager>();
        stageCre = canvas.GetComponent<StageSelectCreater>();
    }

    /*
     * ボタン名を追加するとところ
     * どのボタンが押されたかの判別します
     */
    protected override void OnClick(string objectName)
    {
        //StageSelectにシーンを切り替えるボタン
        if("VS_Btn".Equals(objectName))
        {
            this.VS_BtnClick();
        }
        //StageSelectにシーンを切り替えるボタン
        else if ("Single_Btn".Equals(objectName))
        {
            this.Single_BtnClick();
        }
        //ゲームを終了するボタン
        else if ("Exit_Btn".Equals(objectName))
        {
            this.Exit_BtnClick();
        }
        //Titleにシーンを切り替えるボタン
        else if ("Title_Btn".Equals(objectName))
        {
            this.Title_BtnClick();
        }
        //ReTry（読み込んでいるシーンと）同じシーンを読み込むボタン
        else if ("Retry_Btn".Equals(objectName))
        {
            this.Retry_BtnClick();
        }
        //Play対応する各ステージにシーンを切り替えるボタン
        else if ("Play_Btn".Equals(objectName))
        {
            this.Play_BtnClick();
        }
        else if ("NextStage".Equals(objectName))
        {
            this.NextStage_BtnClick();
        }
        else if ("SystemButton".Equals(objectName))
        {
            this.SystemDisplay();
        }
        //ステージセレクトシーンのステージボタンの入れ替え用のボタン
        else if ("Prev_Btn".Equals(objectName))
        {
            this.Prev_BtnClick();
        }
        //ステージセレクトシーンのステージボタンの入れ替えのボタン
        else if ("Next_Btn".Equals(objectName))
        {
            this.Next_BtnClick();
        }
        //操作説明シーンへ移動するボタン
        else if ("HOW_Btn".Equals(objectName))
        {
            this.HOW_BtnClick();
        }
    }
    
    /*
     * ボタンの処理内容を追加するところ
     */
    private void VS_BtnClick()
    {
        //Debug.Log(buttonMana.getgameMode());
        SceneManager.LoadScene("StageSelect");
        //ButtonManagerにゲームモード2であるとセット
        buttonMana.setgameMode(2);
    }
    private void Single_BtnClick()
    {
        //Debug.Log(buttonMana.getgameMode());
        SceneManager.LoadScene("StageSelect");
        //ButtonManagerにゲームモード1であるとセット
        buttonMana.setgameMode(1);
    }
    private void Exit_BtnClick()
    {
        //UnityEditor.EditorApplication.isPlaying = false;
        //Application.Quit();
    }
    private void Title_BtnClick()
    {
        SceneManager.LoadScene("Title");
        //ButtonManagerにゲームモード0をリセットさせる
        buttonMana.setgameMode(0);
    }
    private void Retry_BtnClick()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void Play_BtnClick()
    {
        //Debug.Log(buttonMana.getgameMode());
        //二人プレイ用
        if (buttonMana.getgameMode() == 2) {
            //VSStageXを読み込む
            SceneManager.LoadScene("VS" + stageCre.getclickedBtn());
        }
        //一人プレイ用
        else if (buttonMana.getgameMode() == 1)
        {
            //SingleStageXを読み込む
            SceneManager.LoadScene("Single" + stageCre.getclickedBtn());
        }
    }
    private void NextStage_BtnClick()
    {
        string next = gameManager.GetComponent<StageManager>().getNextStage();
        SceneManager.LoadScene(next);
        Debug.Log(next);
    }

    private void SystemDisplay()
    {
        buttonMana.SystemButtonDisplay();
    }

    private void Prev_BtnClick()
    {
        if (SceneManager.GetActiveScene().name == "StageSelect") 
        {
            stageCre.ResetStageBtn(-1);
        }
        else if (SceneManager.GetActiveScene().name == "How")
        {
            Debug.Log("戻るボタン！！！！");
            //操作説明シーンの処理は書けばOK/////////////////////////////////////////////////////////////////ここに書けば動くはず
        }
    }
    private void Next_BtnClick()
    {
        if (SceneManager.GetActiveScene().name == "StageSelect")
        {
            stageCre.ResetStageBtn(1);
        }
        else if (SceneManager.GetActiveScene().name == "How")
        {
            Debug.Log("進むボタン！！！！");
            //操作説明シーンの処理は書けばOK/////////////////////////////////////////////////////////////////ここに書けば動くはず
        }
    }

    private void HOW_BtnClick()
    {
        SceneManager.LoadScene("How");
    }
}
