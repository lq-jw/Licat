using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B_openFloor_btn : Btn_controller
{
    public Animator openFloor_ani;

    protected override void OnBtnStay()
    {
        openFloor_ani.SetBool("is_open", false);
    }

    protected override void OnBtnExit()
    {
        openFloor_ani.SetBool("is_open", true);
    }
}