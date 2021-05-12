using System.Collections;
using UnityEngine;

public class MouseDrag : MonoBehaviour
{

    private Vector3 playerPos;  //このオブジェクトの位置
    private Vector3 mousePos;   //マウスのドラッグ位置
   // private float px ,py;

    void Update()
    {
        GameObject parent = transform.parent.gameObject;
        playerControl();
        Vector2 pos = transform.position;
        /*
        px = transform.position.x;
        py = transform.position.y;
        */
    }

    private void playerControl()
    {

        if (Input.GetMouseButtonDown(0))
        {
            playerPos = this.transform.position;
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }

        if (Input.GetMouseButton(0))
        {

            Vector3 prePos = this.transform.position;
            Vector3 diff = Camera.main.ScreenToWorldPoint(Input.mousePosition) - mousePos;

            diff.z = 0.0f;
            this.transform.position = playerPos + diff;

        }

        if (Input.GetMouseButtonUp(0))
        {
            playerPos = Vector3.zero;
            mousePos = Vector3.zero;
        }
    }
}