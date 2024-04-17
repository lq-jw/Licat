using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class A_elevator : MonoBehaviour
{
    //public Animator btn_ani;
    public GameObject G_elevator;
    public GameObject G_btn;

    private float btnNow_Y_pisition;
    private float btnPress_Y_pisition;
    private float btnUnpress_Y_pisition;

    private float elevatorNow_Y_pisition;
    private float elevatorVertex_Y_pisition;
    private float elevatorLowest_Y_pisition;
    private bool is_Rising = true;
    

    private void Start()
    {
        btnUnpress_Y_pisition = G_btn.transform.position.y;
        btnPress_Y_pisition = btnUnpress_Y_pisition - 0.05f;

        elevatorVertex_Y_pisition = G_elevator.transform.position.y + 8;
        elevatorLowest_Y_pisition = G_elevator.transform.position.y;
    }

    private void OnCollisionStay2D(Collision2D collision) //開門
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Box") || collision.gameObject.CompareTag("Player_blue") || collision.gameObject.CompareTag("Player_yellow"))
        {
            MoveElevator();

            btnNow_Y_pisition = G_btn.transform.position.y;
            if (btnNow_Y_pisition >= btnPress_Y_pisition)
            {
                G_btn.transform.Translate(Vector3.down * 0.1f);
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)  //關門
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Box") || collision.gameObject.CompareTag("Player_blue") || collision.gameObject.CompareTag("Player_yellow"))
        {

            UnPressBtn();
        }
    }

    private void UnPressBtn()
    {
        if (btnNow_Y_pisition <= btnUnpress_Y_pisition)
        {
            G_btn.transform.Translate(Vector3.up * 0.08f);
            btnNow_Y_pisition = G_btn.transform.position.y;
        }
    }

    private void MoveElevator()
    {
        elevatorNow_Y_pisition = G_elevator.transform.position.y;
        if (elevatorNow_Y_pisition >= elevatorVertex_Y_pisition)
        {
            is_Rising = false;
        }
        else if (elevatorNow_Y_pisition <= elevatorLowest_Y_pisition)
        {
            is_Rising = true;
        }

        if (is_Rising)
        {
            G_elevator.transform.Translate(Vector3.up * 1f * Time.deltaTime);
        }
        else if (!is_Rising)
        {
            G_elevator.transform.Translate(Vector3.down * 1f * Time.deltaTime);
        }
    }
}
