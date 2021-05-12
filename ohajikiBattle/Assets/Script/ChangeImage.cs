using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeImage : MonoBehaviour {

    SpriteRenderer MainSpriteRenderer;

    //スプライトを代入する配列
    private Sprite[] uiSprites;
    public Sprite noimage;

    void Awake()
    {
        // このobjectのSpriteRendererを取得
        MainSpriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();

        //Resourcesのthumbnailをロードして配列に代入
        uiSprites = Resources.LoadAll<Sprite>("thumbnail");
        
    }

    public void ChangeStagePreview(string stage, int gamemode)
    {
        foreach (var spr in uiSprites)
        {
            //Debug.Log(spr.name);

            //二人プレイ用
            if (gamemode == 2)
            {
                if ("VS" + stage == spr.name)
                {
                    MainSpriteRenderer.sprite = spr;
                    return; //スプライト見つけた瞬間終了
                }
            }
            //一人プレイ用
            else if (gamemode == 1)
            {
                if ("Single" + stage == spr.name)
                {
                    MainSpriteRenderer.sprite = spr;
                    return; //スプライト見つけた瞬間終了
                }
            }
        }
        //スプライトが見つからなかった場合
        MainSpriteRenderer.sprite = noimage;
    }
}
