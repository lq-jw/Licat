using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Btn_controller : MonoBehaviour
{
    [SerializeField] protected GameObject btn;

    protected float btnPress_Y_pisition, btnUnpress_Y_pisition, btnNow_Y_pisition;

    private void Start()
    {
        btnUnpress_Y_pisition = btn.transform.position.y;
        btnPress_Y_pisition = btnUnpress_Y_pisition - 0.05f;
    }

    protected abstract void OnBtnStay();        // 須完成
    protected abstract void OnBtnExit();        // 須完成

    private void OnCollisionEnter2D(Collision2D collision) //踩下去
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Box") || collision.gameObject.CompareTag("Player_blue") || collision.gameObject.CompareTag("Player_yellow"))
        {
            PlaySE();
        }
    }
    private void OnCollisionStay2D(Collision2D collision) //開門
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Box") || collision.gameObject.CompareTag("Player_blue") || collision.gameObject.CompareTag("Player_yellow"))
        {
            OnBtnStay();

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
            OnBtnExit();
            UnPressBtn();
        }
    }

    private void UnPressBtn()
    {
        if (btnNow_Y_pisition <= btnUnpress_Y_pisition)
        {
            btn.transform.Translate(Vector3.up * 0.08f);
            btnNow_Y_pisition = btn.transform.position.y;
        }
    }

    private void PlaySE()
    {
        AudioManager.instance.PlaySE("obj_btnPress");       // 播放音效

    }
}