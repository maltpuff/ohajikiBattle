using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Text.RegularExpressions;

/*
 * ステージセレクトシーンのUIを処理するスクリプト
 * 主にステージボタンの生成、ステージプレビューの表示・非表示、操作の保存を行う。
 * 前回の操作の記録が残っていればその状態を復元する。
 */

public class StageSelectCreater : MonoBehaviour
{
    [SerializeField] GameObject preview;
    [SerializeField] int VSMax; //インスペクターから設定
    [SerializeField] int SingleMax; //インスペクターから設定
    ChangeImage changeime;
    ButtonManager buttonMana;
    public GameObject[] _stagebutton;
    public GameObject[] _kage;
    Vector2 mousePos;
    RaycastHit2D hit2d;
    private int page = 0; //ページに対応する変数。1ページはステージボタン1～5まで表示、2ページは6～10まで表示...とする
    private static int keeppage = 1; //ステージセレクト画面のページを保持し続ける変数
    private static string clickedBtn; //最後に押されたステージボタンを保持する変数
    private List<RaycastResult> raycastResults = new List<RaycastResult>(); //クリックした先にあるものを入れるリスト

    // Use this for initialization
    void Start()
    {
        buttonMana = this.GetComponent<ButtonManager>();
        changeime = preview.GetComponent<ChangeImage>();
        buttonMana.stageText_text = buttonMana.stageText.transform.GetComponent<Text>();
        buttonMana.pageText_text = buttonMana.pageText.transform.GetComponent<Text>();
        buttonMana.gameModeText_text = buttonMana.gameModeText.transform.GetComponent<Text>();

        //画面左上に表示されるテキストボックスををgameModeに応じて書き換える
        //二人プレイ選択時
        if (buttonMana.getgameMode() == 2)
        {
            buttonMana.gameModeText_text.text = ("VSモード");
        }
        //一人プレイ選択時
        else if (buttonMana.getgameMode() == 1)
        {
            buttonMana.gameModeText_text.text = ("シングルモード");
        }

        //最初はプレビュー非表示
        preview.gameObject.SetActive(false);
        buttonMana.playBtn.gameObject.SetActive(false);
        buttonMana.playKage.gameObject.SetActive(false);

        _stagebutton = new GameObject[5]; //ステージボタン用のインスタンスを5個作る
        _kage = new GameObject[5]; //ステージボタン用のインスタンスを5個作る

        CreateButton(); //Canvas下にプレハブからボタンを生成
    }

    void Update()
    {
        //マウスのクリックが起こったときのイベント
        if (Input.GetMouseButtonDown(0))
        {
            //uGUI以外の部分をクリックした場合　かつ　オブジェクト以外をクリックした場合
            if (!IsPointerOnUGUI(Input.mousePosition) && !IsPointerOnColider2D())
            {
                //previewを非表示にする
                buttonMana.stageText_text.text = ("────");
                preview.gameObject.SetActive(false);
                buttonMana.playBtn.gameObject.SetActive(false);
                buttonMana.playKage.gameObject.SetActive(false);
            }
        }
    }

    //マウスポインタの位置にuGUIがあるか判定する。あればtrue、なければfalseを返す
    public bool IsPointerOnUGUI(Vector2 screenPosition)
    {
        // EventSystemがない = uGUIがないときは遮るものがないので処理そのものをさせないよ
        if (EventSystem.current == null) { return false; }

        // EventSystemにタップした座標を設定するよ
        PointerEventData eventDataCurrent = new PointerEventData(EventSystem.current);
        eventDataCurrent.position = screenPosition;

        // タップ地点の先にあるものを調べるためにRayCastするよ
        EventSystem.current.RaycastAll(eventDataCurrent, raycastResults);
        bool result = raycastResults.Count > 0;

        raycastResults.Clear(); //リセットしておくよ
        return result;
    }

    //マウスポインタの位置にオブジェクトがあるか判定する。あればtrue、なければfalseを返す
    public bool IsPointerOnColider2D()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        hit2d = Physics2D.Raycast(mousePos, Vector2.zero);

        if (hit2d.rigidbody != null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    //ステージプレビューを表示するメソッド
    //StageXのボタンが押されたときと、ゲームシーンからステージセレクト画面に戻ったときに呼び出される
    public void DisplayStagePreview(string btnname)
    {
        //プレビューを表示状態にする
        buttonMana.stageText.gameObject.SetActive(true);
        preview.gameObject.SetActive(true);
        buttonMana.playBtn.gameObject.SetActive(true);
        buttonMana.playKage.gameObject.SetActive(true);
        //押されたボタンの名前と、ゲームモードををChangeImageにわたす
        changeime.ChangeStagePreview(btnname, buttonMana.getgameMode());
        //押されたボタンの名前をプレビューの上のテキストボックスに書き込む
        buttonMana.stageText_text.text = Regex.Replace(btnname, @"Stage", "ステージ");

        //押されたボタンの名前を代入し記録しておく
        clickedBtn = btnname;
    }

    //押されたステージボタンの名前を返す
    //Play_Btnが押されたときと、前回の再現が行われるとき呼び出される
    public string getclickedBtn()
    {
        return clickedBtn;
    }

    //Prev_BtnかNext_Btnが押されたときに呼び出される
    public void ResetStageBtn(int addnum)
    {
        page += addnum; //ページを変更し、ページに応じてボタンを再生成
        CreateButton();
        keeppage = page; //変更したページを記録する
    }

    //ステージセレクト画面のボタンを生成するメソッド
    //シーンの開始時と、ページを変えたときに呼び出される
    private void CreateButton()
    {
        //ボタン初回作成時
        if (page == 0)
        {
            Reproduction(); //前回操作した記録があればそれを再現する、ここで表示するページが決まる
            LoadBtn(); //ページに対応するボタンを生成する

            buttonMana.GetAllChildButton(); //Canvasの子オブジェクトを再取得させる
        }
        //初回以外(prevやnextが押されたとき)
        else
        {
            //存在するステージボタンを全て削除
            foreach (var btn in _stagebutton)
            {
                Destroy(btn);
            }
            //存在するkageを全て削除
            foreach (var kag in _kage)
            {
                Destroy(kag);
            }
            LoadBtn(); //ページに対応するボタンを生成する

            buttonMana.GetAllChildButton(); //Canvasの子オブジェクトを再取得させる
        }

        buttonMana.pageText_text.text = page.ToString(); //表示しているページ番号を更新

        //ページによってprevボタンとnextボタンの表示・非表示を変更する
        //二人プレイ用
        if (buttonMana.getgameMode() == 2)
        {
            //1ページ目の場合
            if (page == 1)
            {
                //prevボタンを非表示
                buttonMana.prev_text.gameObject.SetActive(false);
                buttonMana.prevBtn.gameObject.SetActive(false);
                buttonMana.prevKage.gameObject.SetActive(false);
                //nextボタンを表示
                buttonMana.next_text.gameObject.SetActive(true);
                buttonMana.nextBtn.gameObject.SetActive(true);
                buttonMana.nextKage.gameObject.SetActive(true);
            }
            //最終ページの場合
            else if (page == (VSMax / 5) + 1 || (VSMax % 5 == 0 && page == VSMax / 5))
            {
                //prevボタンを表示
                buttonMana.prev_text.gameObject.SetActive(true);
                buttonMana.prevBtn.gameObject.SetActive(true);
                buttonMana.prevKage.gameObject.SetActive(true);
                //nextボタンを非表示
                buttonMana.next_text.gameObject.SetActive(false);
                buttonMana.nextBtn.gameObject.SetActive(false);
                buttonMana.nextKage.gameObject.SetActive(false);
            }
            //最初のページでも最後のページでもない場合
            else
            {
                //prevボタンとnextボタンを表示
                buttonMana.prev_text.gameObject.SetActive(true);
                buttonMana.prevBtn.gameObject.SetActive(true);
                buttonMana.prevKage.gameObject.SetActive(true);
                buttonMana.next_text.gameObject.SetActive(true);
                buttonMana.nextBtn.gameObject.SetActive(true);
                buttonMana.nextKage.gameObject.SetActive(true);
            }
        }
        //一人プレイ用
        else if (buttonMana.getgameMode() == 1)
        {
            //1ページ目の場合
            if (page == 1)
            {
                //prevボタンを非表示
                buttonMana.prev_text.gameObject.SetActive(false);
                buttonMana.prevBtn.gameObject.SetActive(false);
                buttonMana.prevKage.gameObject.SetActive(false);
                //nextボタンを表示
                buttonMana.next_text.gameObject.SetActive(true);
                buttonMana.nextBtn.gameObject.SetActive(true);
                buttonMana.nextKage.gameObject.SetActive(true);
            }
            //最終ページの場合
            else if (page == (SingleMax / 5) + 1 || (SingleMax % 5 == 0 && page == SingleMax / 5))
            {
                //prevボタンを表示
                buttonMana.prev_text.gameObject.SetActive(true);
                buttonMana.prevBtn.gameObject.SetActive(true);
                buttonMana.prevKage.gameObject.SetActive(true);
                //nextボタンを非表示
                buttonMana.next_text.gameObject.SetActive(false);
                buttonMana.nextBtn.gameObject.SetActive(false);
                buttonMana.nextKage.gameObject.SetActive(false);
            }

            //最初のページでも最後のページでもない場合
            else
            {
                //prevボタンとnextボタンを表示
                buttonMana.prev_text.gameObject.SetActive(true);
                buttonMana.prevBtn.gameObject.SetActive(true);
                buttonMana.prevKage.gameObject.SetActive(true);
                buttonMana.next_text.gameObject.SetActive(true);
                buttonMana.nextBtn.gameObject.SetActive(true);
                buttonMana.nextKage.gameObject.SetActive(true);
            }
        }
    }

    //プレハブの読み込みとステージボタンの設置を行うメソッド
    private void LoadBtn()
    {
        //プレハブをロードする
        GameObject stagebutton = (GameObject)Resources.Load("StageButton");
        GameObject kage = (GameObject)Resources.Load("StageButtonKage");
        //座標
        Vector2 pos;
        Vector2 kagepos;

        for (int i = 0; i < 5; i++)
        {
            kagepos.x = 208.0f;
            kagepos.y = 562.0f - (i * 100);
            _kage[i] = Instantiate(kage, kagepos, Quaternion.identity) as GameObject;
            _kage[i].transform.SetParent(this.transform);

            pos.x = 200.0f;
            pos.y = 570.0f - (i * 100);
            _stagebutton[i] = Instantiate(stagebutton, pos, Quaternion.identity) as GameObject;
            _stagebutton[i].transform.SetParent(this.transform);
            _stagebutton[i].gameObject.name = "Stage" + (i + 1 + 5 * (page - 1));

            //不必要なボタンは削除
            //二人プレイ用
            if (buttonMana.getgameMode() == 2 && i + 1 + 5 * (page - 1) > VSMax)
            {
                Destroy(_stagebutton[i]);
                Destroy(_kage[i]);
            }
            //一人プレイ用
            else if(buttonMana.getgameMode() == 1 && i + 1 + 5 * (page - 1) > SingleMax)
            {
                Destroy(_stagebutton[i]);
                Destroy(_kage[i]);
            }
        }
    }

    //前回の再現を行うメソッド
    //ページをキープする必要が無くなったときにkeeppageをリセットする
    private void Reproduction()
    {
        //タイトルバックを検知した場合
        if (buttonMana.gettitleDisplaed())
        {
            keeppage = 1; //キープページを初期化
            clickedBtn = null; //保持していたステージボタンの初期化
            buttonMana.settitleDisplaed(false);
        }
        //タイトルバックがなければステージセレクトシーン前回表示時の再現が行われる
        //前回最後に押していたステージボタンを押したときと同じ処理をする
        else
        {
            if (clickedBtn != null)
            {
                DisplayStagePreview(getclickedBtn());
            }
        }
        //keeppageに記録があればその記録をpageに代入、そうでなければ1が代入される
        page = keeppage;
    }
}
