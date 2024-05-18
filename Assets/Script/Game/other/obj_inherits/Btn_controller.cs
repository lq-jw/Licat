using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Btn_controller : MonoBehaviour
{
    [SerializeField] protected GameObject btn;

    protected float btnPress_Y_pisition, btnUnpress_Y_pisition, btnNow_Y_pisition;

    private void Start()
    {
        // 確認按鈕位置
        btnUnpress_Y_pisition = btn.transform.position.y;
        btnPress_Y_pisition = btnUnpress_Y_pisition - 0.05f;
        OnBtnStart();
    }

    protected virtual void OnBtnStart()
    {
        // 可選是否完成
        // 子類需要 Start 的話用這個
    }
    protected virtual void OnBtnEnter()
    {
        // 可選是否完成
        // 貓/箱子與按鈕產生碰撞的那刻
    }

    protected virtual void OnBtnStay()
    {
        // 可選是否完成
        // 貓/箱子與按鈕碰撞中的時候
    }
    protected virtual void OnBtnExit()
    {
        // 可選是否完成
        // 貓/箱子離開按鈕的那刻
    }

    private void OnCollisionEnter2D(Collision2D collision) //踩下去
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Box") || collision.gameObject.CompareTag("Player_blue") || collision.gameObject.CompareTag("Player_yellow"))
        {
            PlaySE();
            OnBtnEnter();
        }
    }

    private void OnCollisionStay2D(Collision2D collision) // 正在踩
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Box") || collision.gameObject.CompareTag("Player_blue") || collision.gameObject.CompareTag("Player_yellow"))
        {
            btnNow_Y_pisition = btn.transform.position.y;

            if (btnNow_Y_pisition >= btnPress_Y_pisition)
            {
                btn.transform.Translate(Vector3.down * 0.1f);
            }
            OnBtnStay();
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

    private void UnPressBtn() // 按鈕位移
    {
        if (btnNow_Y_pisition <= btnUnpress_Y_pisition)
        {
            btn.transform.Translate(Vector3.up * 0.08f);
            btnNow_Y_pisition = btn.transform.position.y;
        }
    }

    private void PlaySE() // 播放音效
    {
        AudioManager.instance.PlaySE("obj_btnPress");
    }
}