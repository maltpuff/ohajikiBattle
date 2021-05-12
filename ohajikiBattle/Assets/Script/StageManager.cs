using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour {

    [SerializeField] private int gameMode;
    [SerializeField] private int stage;
    [SerializeField] private string nextStage;

    public int getGameMode()
    {
        return gameMode;
    }

    public int getStage()
    {
        return stage;
    }

    public string getNextStage()
    {
        return nextStage;
    }


}
