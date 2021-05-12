using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Counter : MonoBehaviour {

    public int enemycount = 3;
    public int characount = 3;

    public Text counttext;
    public Text Result;
    public int resulton;
    // Use this for initialization
    void Start () {
        //Text score_text = counttext.GetComponent<Text>();
        counttext.text = "BLUE:残"+ characount + "\nRED:残" + enemycount ;

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void lost(int x)
    {
        switch (x)
        {
            case 0:
                characount--;
                break;

            case 1:
                enemycount--;
                break;
        }

        if(enemycount == 0 && characount==0)
        {//引き分け
            counttext.GetComponent<Winners>().Win(1);
        }
        else if(characount==0){
        //Aの価値
            counttext.GetComponent<Winners>().Win(3);

        }
        else if (enemycount == 0){
            counttext.GetComponent<Winners>().Win(2);

        }

        
    }

    public void hyoji()
    {
        counttext.text = "BLUE:残" + characount + "\nRED:残" + enemycount;
    }
}
