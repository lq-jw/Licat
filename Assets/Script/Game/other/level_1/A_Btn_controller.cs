using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class A_Btn_controller : MonoBehaviour
{
    //public Animator btn_ani;
    public Animator door_light;
    public Animator btn_door_ani;
    public GameObject btn;

    private float btnNow_Y_pisition;
    private float btnPress_Y_pisition;
    private float btnUnpress_Y_pisition;

    private void Start()
    {
        btnUnpress_Y_pisition = btn.transform.position.y;
        btnPress_Y_pisition = btnUnpress_Y_pisition - 0.05f;
    }

    private void OnCollisionStay2D(Collision2D collision) //開門
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Box") || collision.gameObject.CompareTag("Player_blue") || collision.gameObject.CompareTag("Player_yellow"))
        {
            btn_door_ani.SetBool("is_open", true);
            door_light.Play("open");

            btnNow_Y_pisition = btn.transform.position.y;

            if (btnNow_Y_pisition >= btnPress_Y_pisition)
            {
                btn.transform.Translate(Vector3.down * 0.1f);
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)  //關門
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Box") || collision.gameObject.CompareTag("Player_blue") || collision.gameObject.CompareTag("Player_yellow"))
        {
            btn_door_ani.SetBool("is_open", false);
            door_light.Play("close");
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
