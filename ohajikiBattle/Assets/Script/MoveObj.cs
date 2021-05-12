using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObj : MonoBehaviour {

    [SerializeField] private Vector3 speed = new Vector3(0.01f, 0f, 0f);
    [SerializeField] private Vector3 stPos;
    [SerializeField] private Vector3 endPos;

    private void Start()
    {
        stPos = this.transform.position;
    }

    private void FixedUpdate()
    {
        this.transform.position = this.transform.position + (speed);
        if (stPos.x < this.transform.position.x)
        {
            speed *= -1;
        }else if (endPos.x > this.transform.position.x)
        {
            speed *= -1;
        }
    }
}
