using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Text.RegularExpressions;

public class StageButtonClick : MonoBehaviour
{
    StageSelectCreater stageCre;

    private Text buttonText;
    void Start()
    {
        //自身のテキストを自身の名前の書き替える
        buttonText = this.transform.GetChild(0).GetComponent<Text>();
        buttonText.text = Regex.Replace(this.gameObject.name, @"Stage", "ステージ");

        GameObject parentGameObject = transform.parent.gameObject;
        stageCre = parentGameObject.GetComponent<StageSelectCreater>();
    }
    public void OnClick()
    {
        //StageSelectCreaterに自分のオブジェクト名を渡し、プレビューを表示
        stageCre.DisplayStagePreview(this.gameObject.name);
    }
}