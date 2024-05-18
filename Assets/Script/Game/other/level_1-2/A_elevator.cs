using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class A_elevator : Btn_controller
{
    public GameObject G_elevator;

    private float elevatorNow_Y_pisition;
    private float elevatorVertex_Y_pisition;
    private float elevatorLowest_Y_pisition;
    private bool is_Rising = true;

    protected override void OnBtnStart()
    {
        elevatorVertex_Y_pisition = G_elevator.transform.position.y + 8;
        elevatorLowest_Y_pisition = G_elevator.transform.position.y;
        //------確認按鈕、電梯位置
    }

    protected override void OnBtnStay()
    {
        MoveElevator();
    }

    private void MoveElevator() //電梯移動
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
            G_elevator.transform.Translate(Vector3.up * 1.2f * Time.deltaTime);
        }
        else if (!is_Rising)
        {
            G_elevator.transform.Translate(Vector3.down * 1.2f * Time.deltaTime);
        }
    }
}
