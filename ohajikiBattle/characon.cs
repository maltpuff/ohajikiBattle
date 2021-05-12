using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
 
public class characon : MonoBehaviour
{

    Rigidbody2D rigid2d;
    Vector2 startPos;

    public Slider shotGauge;
    float speed = 0;
    float gaugeLength = 0;
    bool shotGaugeSet = false;
    public int play = 0;
    public int now;
    void Start()
    {
        this.rigid2d = GetComponent<Rigidbody2D>();

    }

    void Update()
    {
       /* if (Input.GetMouseButtonDown(0))
        {

            clickedGameObject = null;

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit2d = Physics2D.Raycast((Vector2)ray.origin, (Vector2)ray.direction);

            if (hit2d)
            {
                clickedGameObject = hit2d.transform.gameObject;
            }

                Debug.Log(clickedGameObject);
        }*/
        
        if (play == 0)
        {
            // マウスを押した地点の座標を記録
            if (Input.GetMouseButtonDown(0))
            {
                this.startPos = Input.mousePosition;
                shotGaugeSet = true;
            }

            // マウスを離した地点の座標から、発射方向を計算
            if (Input.GetMouseButtonUp(0))
            {
                Vector2 endPos = Input.mousePosition;
                Vector2 startDirection = -1 * (endPos - startPos).normalized;
                this.rigid2d.AddForce(startDirection * speed);
                shotGaugeSet = false;
                gaugeLength = 0;
                shotGauge.value = gaugeLength;

            }

            // マウスが押されている間 ショットゲージを呼ぶ
            if (shotGaugeSet)
            {
                shotGaugeValue();
            }

            // テスト用：スペースキー押下で停止
            if (Input.GetKeyDown(KeyCode.Space))
            {
                this.rigid2d.velocity *= 0;
            }
        }

    }

    void FixedUpdate()
    {
        if (this.rigid2d.velocity.magnitude >= 100f)
        {
            this.rigid2d.velocity *= 0.995f;
        }
        else if (this.rigid2d.velocity.magnitude >= 20f)
        {
            this.rigid2d.velocity *= 0.9f;
        }
        else if (this.rigid2d.velocity.magnitude >= 0.5f)
        {
            this.rigid2d.velocity *= 0.85f;
        }
        // 速さが一定以下になったことを検知し、キャラを停止しターンを終了
        if (this.rigid2d.velocity.magnitude < 0.5f && this.rigid2d.velocity.magnitude != 0)
        {
            this.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }
    }


    // ショットゲージ関数
    void shotGaugeValue()
    {

        gaugeLength += 0.015f;
        //ゲージがMaxでゼロに戻る
        if (gaugeLength > 1.015f)
        {
            gaugeLength = 0;
        }

        //ゲージ長さをlengthに代入
        shotGauge.value = gaugeLength;
        // スピードをゲージ値から計算
        speed = gaugeLength * 1000f + 300f;
    }
}