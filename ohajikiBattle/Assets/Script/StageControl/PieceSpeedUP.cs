using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceSpeedUP : MonoBehaviour {

    [SerializeField] private float speedUP = 20f;

    private bool PanelUsed = false;
    /*
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Is Trigger : ON で, 当たり判定に入ったとき.");
    }
    */
    private void OnTriggerStay2D(Collider2D other)
    {
        //if (!PanelUsed)
        //{
            //Debug.Log("Is Trigger : ON で, 当たり判定に入っている間.");
            other.attachedRigidbody.AddForce(speedUP * other.attachedRigidbody.velocity);
        //}
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        //Debug.Log("Is Trigger : ON で, 当たり判定から抜けたとき.");
        PanelUsed = true;
    }

    public void setPanelUsed(bool change)
    {
        PanelUsed = change;
    }
    
}
