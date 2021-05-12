using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
 * このスクリプトと、BaseButtonControllerをを制御したいボタンの親オブジェクト(Canvasなど)にアタッチしてください
 * その後インスペクタータブから
 * BaseButtonControllerのButtonに、ボタンの制御内容を書いたButtonControllerをぶち込んでください
 */
public class ButtonManager : MonoBehaviour
{
    private GameObject[] child_obj;
    private GameObject retryBtn;
    private GameObject vsBtn;
    private GameObject singleBtn;
    private GameObject titleBtn;
    private GameObject nextStageBtn;
    private GameObject cover;
    public GameObject playBtn;
    public GameObject systemBtnSdw;
    public GameObject playKage;
    public GameObject stageText;
    public GameObject prevBtn;
    public GameObject nextBtn;
    public GameObject prev_text;
    public GameObject next_text;
    public GameObject prevKage;
    public GameObject nextKage;
    public GameObject pageText;
    public GameObject gameModeText;
    public Text stageText_text;
    public Text gameModeText_text;
    public Text pageText_text;


    private static int gameMode = 0; //タイトル画面で押されたボタンをこのスクリプトで保持し続けます
    private static bool titleDisplayed = false; //タイトルに戻ったときにtrueになる変数
    private bool resulttime = false; //result画面が表示されている間はtrueになる変数

    void Awake()
    {
        //Canvas下の子オブジェクトを取得する
        GetAllChildButton();
    }

    //Canvas下の子オブジェクトを取得するメソッド
    //ステージセレクトシーンでボタンが新しく生成された場合も再取得のため呼び出される
    public void GetAllChildButton()
    {
        child_obj = new GameObject[this.transform.childCount];

        for (int i = 0; i < this.transform.childCount; i++)
        {
            child_obj[i] = this.transform.GetChild(i).gameObject;
            //Debug.Log(child_obj[i].gameObject.name);

            //あとから表示を変更したりする子オブジェクトは個別に記録しておく
            if (child_obj[i].gameObject.name == "Retry_Btn")
            {
                retryBtn = child_obj[i];
            }
            else if (child_obj[i].gameObject.name == "VS_Btn")
            {
                vsBtn = child_obj[i];
            }
            else if (child_obj[i].gameObject.name == "Single_Btn")
            {
                singleBtn = child_obj[i];
            }
            else if (child_obj[i].gameObject.name == "Title_Btn")
            {
                titleBtn = child_obj[i];
            }
            else if (child_obj[i].gameObject.name == "Play_Btn")
            {
                playBtn = child_obj[i];
            }
            else if (child_obj[i].gameObject.name == "Play_Kage")
            {
                playKage = child_obj[i];
            }
            else if (child_obj[i].gameObject.name == "StageX_Text")
            {
                stageText = child_obj[i];
            }
            else if (child_obj[i].gameObject.name == "NextStage")
            {
                nextStageBtn = child_obj[i];
            }
            else if (child_obj[i].gameObject.name == "Cover")
            {
                cover = child_obj[i];
            }
            else if (child_obj[i].gameObject.name == "Prev_Btn")
            {
                prevBtn = child_obj[i];
            }
            else if (child_obj[i].gameObject.name == "Next_Btn")
            {
                nextBtn = child_obj[i];
            }
            else if (child_obj[i].gameObject.name == "Prev_Text")
            {
                prev_text = child_obj[i];
            }
            else if (child_obj[i].gameObject.name == "Next_Text")
            {
                next_text = child_obj[i];
            }
            else if (child_obj[i].gameObject.name == "Prev_Kage")
            {
                prevKage = child_obj[i];
            }
            else if (child_obj[i].gameObject.name == "Next_Kage")
            {
                nextKage = child_obj[i];
            }
            else if (child_obj[i].gameObject.name == "Page_Text")
            {
                pageText = child_obj[i];
            }
            else if (child_obj[i].gameObject.name == "GameMode_Text")
            {
                gameModeText = child_obj[i];
            }
            else if (child_obj[i].gameObject.name == "Button_SystemShadow")
            {
                systemBtnSdw = child_obj[i];
            }

        }
    }

    //ボタンを非表示にするメソッド
    //Resultから呼び出される
    public void hideBtn()
    {
        //cover.SetActive(false);
        retryBtn.gameObject.SetActive(false);
        //二人プレイ用
        //if(gameMode == 2)
        if (CheckObjExists(vsBtn))
        {
            vsBtn.gameObject.SetActive(false);
        }
        //一人プレイ用
        else
        {
            singleBtn.gameObject.SetActive(false);
            if (nextStageBtn != null)
            {
                nextStageBtn.gameObject.SetActive(false);
            }
        }
        titleBtn.gameObject.SetActive(false);

        //リザルト表示前なのでfalse
        resulttime = false;
    }

    //ボタンを表示するメソッド
    //Resultから呼び出される
    public void displayBtn()
    {
        //cover.SetActive(true);
        retryBtn.gameObject.SetActive(true);
        //二人プレイ用
        //if(gameMode == 2)
        if (CheckObjExists(vsBtn))
        {
            vsBtn.gameObject.SetActive(true);
        }
        //一人プレイ用
        else
        {
            singleBtn.gameObject.SetActive(true);
        }
        titleBtn.gameObject.SetActive(true);

        //リザルト表示中はtrue
        resulttime = true;
    }

    public void displayNextStageBtn()
    {
        if(nextStageBtn != null)
        {
            nextStageBtn.gameObject.SetActive(true);
        }
    }

    //gameModeを返す。Play_Btnが押されたときと、ステージプレビューの表示のときに呼び出される
    public int getgameMode()
    {
        return gameMode;
    }

    public void setgameMode(int mode)
    {
        gameMode = mode;
        if(gameMode == 0)
        {
            titleDisplayed = true; //タイトルバックを検知するために記録
        }
    }

    private bool CheckObjExists(GameObject Obj)
    {
        if (Obj)
        {
            //Debug.Log("存在しています");
            return true;
        }
        else
        {
            //Debug.Log("存在していません");
            return false;
        }
    }

    //SystemBtnが押されたときの処理
    public void SystemButtonDisplay()
    {
        //リザルトを表示していない場合
        if (!resulttime)
        {
            //一人プレイ用
            //if (gameMode == 1)
            if (CheckObjExists(singleBtn))
            {
                if (retryBtn.gameObject.activeSelf == false)
                {
                    cover.SetActive(true);
                    retryBtn.gameObject.SetActive(true);
                    singleBtn.gameObject.SetActive(true);
                    titleBtn.gameObject.SetActive(true);
                }
                else
                {
                    cover.SetActive(false);
                    retryBtn.gameObject.SetActive(false);
                    singleBtn.gameObject.SetActive(false);
                    titleBtn.gameObject.SetActive(false);
                }
            }
            //二人プレイ用
            //else if(gameMode == 2)
            else if (CheckObjExists(vsBtn))
            {
                if (retryBtn.gameObject.activeSelf == false)
                {
                    cover.SetActive(true);
                    retryBtn.gameObject.SetActive(true);
                    vsBtn.gameObject.SetActive(true);
                    titleBtn.gameObject.SetActive(true);
                }
                else
                {
                    cover.SetActive(false);
                    retryBtn.gameObject.SetActive(false);
                    vsBtn.gameObject.SetActive(false);
                    titleBtn.gameObject.SetActive(false);
                }
            }
        }
        //リザルト中は機能なし
        else
        {
            systemBtnSdw.SetActive(false);
        }
    }

    //titleの表示を検知するメソッド
    //ステージセレクトシーンのページキープ解除のためStageSelectCreaterから呼び出される
    public bool gettitleDisplaed()
    {
        return titleDisplayed;
    }

    public void settitleDisplaed(bool change)
    {
        titleDisplayed = change;
    }
}
