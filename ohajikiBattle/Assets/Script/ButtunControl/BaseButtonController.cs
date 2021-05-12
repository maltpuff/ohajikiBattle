using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

/*
 * このスクリプトと、BaseButtonControllerをを制御したいボタンの親オブジェクト(Canvasなど)にアタッチしてください
 * その後インスペクタータブから
 * BaseButtonControllerのButtonに、ボタンの制御内容を書いたButtonControllerをぶち込んでください
 */

public class BaseButtonController : MonoBehaviour {

    private BaseButtonController bbctrl;
    PointerEventData pointer;

    void Start()
    {
        GameObject btnCtrlObj = GameObject.Find("ButtonController");
        bbctrl = btnCtrlObj.GetComponent<BaseButtonController>();
    }

    public void Onclick()
    {
        if(bbctrl == null)
        {
            throw new System.Exception("ボタンのインスタンスがないぞ");
        }

        // ポインタ（マウス/タッチ）イベントに関連するイベントの情報
        pointer = new PointerEventData(EventSystem.current);
        // マウスポインタの位置にレイ飛ばし、ヒットしたものを保存
        List<RaycastResult> results = new List<RaycastResult>();
        pointer.position = Input.mousePosition;
        EventSystem.current.RaycastAll(pointer, results);
        // ヒットしたUIの名前
        foreach (RaycastResult target in results)
        {
            //押されたボタンのオブジェクト名を渡す
            bbctrl.OnClick(target.gameObject.name);
        }
    }

    protected virtual void OnClick(string objectName)
    {
        //オーバーライド用の抜け殻メゾッド
    }
}
