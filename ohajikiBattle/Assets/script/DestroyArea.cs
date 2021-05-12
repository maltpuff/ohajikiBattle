using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyArea : MonoBehaviour
{
    private GameObject gamemanager;
    public GameObject counter;

    private void Start()
    {
        gamemanager = GameObject.Find("Gamemaneger");
        counter = GameObject.Find("charactercounter");
    }

    void OnTriggerExit2D(Collider2D c)
    {
        c.GetComponent<CCs>().marker();
        Destroy(c.gameObject);
        if (LayerMask.LayerToName(c.gameObject.layer) == "player")
        {
            counter.GetComponent<Counter>().lost(0);
        }

        if (LayerMask.LayerToName(c.gameObject.layer) == "enemy")
        {
            counter.GetComponent<Counter>().lost(1);
        }


        counter.GetComponent<Counter>().hyoji();
    }

}

