using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIscript : MonoBehaviour {


    public Text targetText;
    
    void Start () {
        Resetskill();
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
        if(this.targetText.text == "Select:Remove")
        {
            Resetskill();
        } else {
            this.targetText.text = "Select:Remove";
        }
    }

    public void Resetskill()
    {
        this.targetText.text = "SkillSelect:なし";
    }
}
