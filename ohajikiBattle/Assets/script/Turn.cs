using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Turn : MonoBehaviour
{

    public int turn=1;
    public Text targetText;

    void Start()
    {
    }

    public void nextturn(string play)
    {
        turn++;
        this.targetText.text = turn + "ターン目\n"
                              + play + "ターン";
    }
}
