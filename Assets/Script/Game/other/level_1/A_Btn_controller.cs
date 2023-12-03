using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class A_Btn_controller : MonoBehaviour
{
    public Animator btn_door_ani;
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Box") || collision.gameObject.CompareTag("Player_blue") || collision.gameObject.CompareTag("Player_yallow"))
        {
            print("play_btn_weight");
            btn_door_ani.SetBool("is_open", true);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Box") || collision.gameObject.CompareTag("Player_blue") || collision.gameObject.CompareTag("Player_yallow"))
        {
            btn_door_ani.SetBool("is_open", false);
        }
    }
}
