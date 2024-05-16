using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B_Btn_L_controller : MonoBehaviour
{
    //public Animator btn_ani;
    public GameObject connectedDoor; // 連接的門
    public GameObject btn;

    private float btnNow_Y_pisition;
    private float btnPress_Y_pisition;
    private float btnUnpress_Y_pisition;

    private void Start()
    {
        btnUnpress_Y_pisition = btn.transform.position.y;
        btnPress_Y_pisition = btnUnpress_Y_pisition - 0.05f;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Box") || collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Player_blue") || collision.gameObject.CompareTag("Player_yellow"))
        {
            connectedDoor.GetComponent<B_Door_controller>().SetSwitch1(true);
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Box") || collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Player_blue") || collision.gameObject.CompareTag("Player_yellow"))
        {
            btnNow_Y_pisition = btn.transform.position.y;

            if (btnNow_Y_pisition >= btnPress_Y_pisition)
            {
                btn.transform.Translate(Vector3.down * 0.1f);
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Box") || collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Player_blue") || collision.gameObject.CompareTag("Player_yellow"))
        {
            connectedDoor.GetComponent<B_Door_controller>().SetSwitch1(false);
            UnPressBtn();
        }
    }


    private void UnPressBtn()
    {
        if (btnNow_Y_pisition <= btnUnpress_Y_pisition)
        {
            AudioManager.instance.PlaySE("obj_btnPress");
            btn.transform.Translate(Vector3.up * 0.08f);
            btnNow_Y_pisition = btn.transform.position.y;
        }
    }
}
