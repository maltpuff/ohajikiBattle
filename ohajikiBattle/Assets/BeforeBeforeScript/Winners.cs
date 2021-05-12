using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Winners : MonoBehaviour {

    string sceneName;
    public GameObject winnerA;
    public GameObject winnerB;
    public GameObject drow;
    public GameObject retry;

    void Start () {
        sceneName = SceneManager.GetActiveScene().name;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Win(int x)
    {
        if (x == 1)
        {
            drow.gameObject.SetActive(true);
            winnerA.gameObject.SetActive(false);
            winnerB.gameObject.SetActive(false);
            retry.gameObject.SetActive(true);
        }
        else if(x==2)
        {
            winnerA.gameObject.SetActive(true);
            retry.gameObject.SetActive(true);

        }
        else if (x == 3)
        {
            winnerB.gameObject.SetActive(true);
            retry.gameObject.SetActive(true);

        }

    }


    public void RetryButton()
    {
        SceneManager.LoadScene(sceneName);
        retry.gameObject.SetActive(false);

    }


}
