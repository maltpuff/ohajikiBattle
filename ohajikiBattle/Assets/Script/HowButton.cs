using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HowButton : MonoBehaviour {

    [SerializeField]Sprite[] HowImage = new Sprite[4];
    int page;
    SpriteRenderer mainSpriteRenderer;

    // Use this for initialization
    void Start()
    {
        mainSpriteRenderer = this.GetComponent<SpriteRenderer>();
        HowImage[0] = this.GetComponent<SpriteRenderer>().sprite;
        page = 0;//0が初期ページ
    }

    // Update is called once per frame
    void Update () {
		
	}

    public void PageNext()
    {
        if (page < 3)
        {
            page++;
            mainSpriteRenderer.sprite = HowImage[page];
        }else if(page ==3)
        {
            page = 0;
            mainSpriteRenderer.sprite = HowImage[0];

        }
    }

    public void PagePre()
    {
        if (page > 0)
        {
            page--;
            mainSpriteRenderer.sprite = HowImage[page];
        }else if (page == 0)
        {
            page = 3;
            mainSpriteRenderer.sprite = HowImage[3];
        }

    }

}
