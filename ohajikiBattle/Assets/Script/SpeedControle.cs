using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedControle : MonoBehaviour {


    [SerializeField] private float firstSpeed = 0.995f;
    [SerializeField] private float secondSpeed = 0.9f;
    [SerializeField] private float secondLine = 20f;
    [SerializeField] private float lastSpeed = 0.8f;


    Rigidbody2D rigid2d;
    private void Start()
    {
        this.rigid2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update () {
        if (this.rigid2d.velocity.magnitude >= 100f)
        {
            this.rigid2d.velocity *= firstSpeed;
        }
        else if (this.rigid2d.velocity.magnitude >= secondLine)
        {
            this.rigid2d.velocity *= secondSpeed;
        }
        else if (this.rigid2d.velocity.magnitude >= 0.5f)
        {
            this.rigid2d.velocity *= lastSpeed;
        }

        // 速さが一定以下になったことを検知し、キャラを停止しターンを終了
        if (this.rigid2d.velocity.magnitude < 0.5f && this.rigid2d.velocity.magnitude != 0)
        {
            this.rigid2d.velocity = Vector2.zero;
            //このあとターン切り替え

        }      
    }
}
