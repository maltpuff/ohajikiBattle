using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CCs : MonoBehaviour
{
    Rigidbody2D rigid2d;
    Vector2 startPos;
    public int playernumber;
    private GameObject select;

    public string Cname ;
    public Slider shotGauge;
    float speed = 0;
    float gaugeLength = 0;
    public bool movemana;
    bool shotGaugeSet = false;
    public bool skill1 = false;
    public bool skill2 = false;
    public bool skill3 = false;
    string skillnow = null;

    public int turncount=0;
    public int playermove;

    public GameObject direction;
    public GameObject destroyefect;

    public bool skill2start = false;

    GameObject clickedGameObject;
    GameObject gameManager;


    void Start()
    {
        this.rigid2d = GetComponent<Rigidbody2D>();
        gameManager = GameObject.Find("Gamemaneger");
        select = GameObject.Find("NowSkill");
    }

    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {

            clickedGameObject = null;

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit2d = Physics2D.Raycast((Vector2)ray.origin, (Vector2)ray.direction);
            if (turncount%2 == playermove)
            {
                if (hit2d.transform.gameObject.name == Cname)
                {
                    clickedGameObject = hit2d.transform.gameObject;
                    this.startPos = Input.mousePosition;
                    shotGaugeSet = true;
                    direction.gameObject.SetActive(true);
                }
                else
                {
                    //skill1 = false; skill2 = false;//スキルの解除

                }
                Debug.Log(hit2d.transform.gameObject.name);
            }
        }

        if (shotGaugeSet)
        {
            if (Input.GetMouseButtonUp(0))
            {
                Vector2 endPos = Input.mousePosition;
                Vector2 startDirection = -1 * (endPos - startPos).normalized;
                this.rigid2d.AddForce(startDirection * speed);
                shotGaugeSet = false;
                gaugeLength = 0;
                shotGauge.value = gaugeLength;
                clickedGameObject = null;
                skill1 = false;
                direction.gameObject.SetActive(false);
                if (skill2 == true)
                {
                    skill2start = true;
                }
                if (startDirection != Vector2.zero)
                {
                    movemana = true;
                }
            }
            shotGaugeValue();//クリック中は稼働
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
            this.rigid2d.velocity *= 0.8f;
        }
        // 速さが一定以下になったことを検知し、キャラを停止しターンを終了
        if (this.rigid2d.velocity.magnitude < 0.5f && this.rigid2d.velocity.magnitude != 0)
        {
            this.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            if (movemana == true)
            {
                gameManager.GetComponent<Gamemanagement>().turnControl();
            }

            if (skill2start == true)
            {
                skill2 = false;
                skill2start = false;
                Exprosion(transform);
            }

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
        speed = gaugeLength * 1400f + 600f;

        if (skill1 == true)
        {
            speed *= 2.2f;
        }
    }

    public void OnClick1()
    {
        skill2 = false;
        skill3 = false;
        if (skill1 == false)
        {
            skill1 = true;
        }
        else
        {
            skill1 = false;
        }
    }

    public void OnClick2()
    {
        skill1 = false;
        skill3 = false;
        if (skill2 == false)
        {
            skill2 = true;
        }
        else
        {
            skill2 = false;
        }
    }

    public void OnClick3()
    {
        skill2 = false;
        skill1 = false;
        if (skill3 == false)
        {
            skill3 = true;
        }
        else
        {
            skill3 = false;
        }
    }

    /* private void OnTriggerEnter2D(Collider2D i_other)
     {
         if (skill2start == true)
         {
             GameObject enterObject = i_other.gameObject;
             if (LayerMask.LayerToName(i_other.gameObject.layer) == "enemy")
             {
                 Destroy(i_other.gameObject);
             }
         }
     }*/

    public void Exprosion(Transform origin)
    {
        Instantiate(destroyefect, origin.position, origin.rotation);
    }

    public void SetTurn()
    {

            skill1 = false;
            skill2 = false;
            skill3 = false;
            this.turncount++;
            Debug.Log("ターン");
        select.GetComponent<UIscript>().Resetskill();
        movemana = false;
    }
    public void marker()
    {
        if(movemana==true)
        {
            gameManager.GetComponent<Gamemanagement>().turnControl();
        }

    }
}