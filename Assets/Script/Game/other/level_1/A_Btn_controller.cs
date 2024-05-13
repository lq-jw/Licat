using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class A_Btn_controller : Btn_controller
{
    //public Animator btn_ani;
    public Animator door_light;
    public Animator btn_door_ani;

    protected override void OnBtnStay()
    {
        btn_door_ani.SetBool("is_open", true);
        door_light.Play("open");
    }

    protected override void OnBtnExit()
    {
        btn_door_ani.SetBool("is_open", false);
        door_light.Play("close");
    }

}
