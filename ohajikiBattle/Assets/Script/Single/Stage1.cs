using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage1 : MonoBehaviour {

    [SerializeField] private GameObject gameManager;
    AllobjectManager allMana;


    [SerializeField] private int count;
	// Use this for initialization
	void Start () {
        count = gameManager.GetComponent<AllobjectManager>().getPlayer2Count();
	}
	
	// Update is called once per frame
	void Update () {
        CheckStageClear();
    }

    private void CheckStageClear()
    {
        if(count == 0)
        {

        }
    }
}
