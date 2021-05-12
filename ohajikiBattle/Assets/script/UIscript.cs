using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIscript : MonoBehaviour {


    public Text targetText;
    
    void Start () {
        this.targetText.text = "Select:なし";
    }
	
    public void Button1()
    {
        if (this.targetText.text == "Select:PowerUp")
        {
            Resetskill();
        } else {
            this.targetText.text = "Select:PowerUp";
        }
    }

    public void Button2()
    {
        if(this.targetText.text == "Select:Exprosion")
        {
            Resetskill();
        } else {
            this.targetText.text = "Select:Exprosion";
        }
    }

    public void Resetskill()
    {
        this.targetText.text = "Select:なし";
    }
}
