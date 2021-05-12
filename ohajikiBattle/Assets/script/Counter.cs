using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Counter : MonoBehaviour {

    public int enemycount = 3;
    public int characount = 3;

    public Text counttext;
    // Use this for initialization
    void Start () {
        Text score_text = counttext.GetComponent<Text>();
        counttext.text = "Player1:残"+ characount + "\nPlayer2:残" + enemycount ;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void lost(int x)
    {
        switch(x)
        {
            case 0:
                characount--;
                break;

            case 1:
                enemycount--;
                break;
        }
    }

    public void hyoji()
    {
        counttext.text = "Player1:残" + characount + "\nPlayer2:残" + enemycount;
    }
}
