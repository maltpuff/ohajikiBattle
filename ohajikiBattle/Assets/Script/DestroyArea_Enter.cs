using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * selectDestroyNumの値によってDestroyするオブジェクトを変える(タグ参照)
 * 0:全部削除
 * 1:Player1削除
 * 2:Player2削除
 * 初期値で0が入っているのでinspectoｒで変更可能
 */

public class DestroyArea_Enter : MonoBehaviour {

    [SerializeField] private int selectDestroyNum = 0;

    void OnTriggerEnter2D(Collider2D c)
    {
        //外に出たオブジェクトを削除
        selectDestroy(c);
    }

    void selectDestroy(Collider2D c)
    {
        if (selectDestroyNum == 0)
        {
            Destroy(c.gameObject);
        }
        else if(selectDestroyNum == 1 && c.gameObject.tag == "Player1")
        {
            Destroy(c.gameObject);
        }
        else if (selectDestroyNum == 2 && c.gameObject.tag == "Player2")
        {
            Destroy(c.gameObject);
        }
    }

}
