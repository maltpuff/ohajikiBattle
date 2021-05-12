using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyent : MonoBehaviour
{

    private GameObject counter;
    public bool going=false;

    private void Awake()
    {
        counter = GameObject.Find("charactercounter");
        Destroy(gameObject, 1.0f);

    }


    void OnTriggerEnter2D(Collider2D c)
    {

            if (LayerMask.LayerToName(c.gameObject.layer) == "player")
            {
                counter.GetComponent<Counter>().lost(0);
            }

            if (LayerMask.LayerToName(c.gameObject.layer) == "enemy")
            {
                counter.GetComponent<Counter>().lost(1);
            }

        counter.GetComponent<Counter>().hyoji();

           Destroy(c.gameObject);
    }

}

