using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageReseter : MonoBehaviour {

    GameObject[] stageobj;
    PieceSpeedUP piecespUP;

    void Start () {
        GetChilds();
    }

    //バトルフィールド内にある装飾オブジェクトを取得
    private void GetChilds()
    {
        stageobj = new GameObject[this.transform.childCount];
        for (int i = 0; i < this.transform.childCount; i++)
        {
            stageobj[i] = this.transform.GetChild(i).gameObject;
        }
    }

    //バトルフィールド内にあるタグがPanelのオブジェクトをリセット
    public void ResetPanel()
    {
        stageobj = new GameObject[this.transform.childCount];
        for (int i = 0; i < this.transform.childCount; i++)
        {
            stageobj[i] = this.transform.GetChild(i).gameObject;
            //Panelタグの子オブジェクトからPieceSpeedUPを取得しておく
            if (stageobj[i].gameObject.tag == "Panel")
            {
                piecespUP = stageobj[i].GetComponent<PieceSpeedUP>();
                piecespUP.setPanelUsed(false);
            }
        }
    }
}
