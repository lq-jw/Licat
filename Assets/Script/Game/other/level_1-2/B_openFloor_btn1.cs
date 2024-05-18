using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B_openFloor_btn1 : PullBtn_controller
{
    protected override void SwitchDoor()
    {
        licat_ani.Play("push_pole_L");
        floor_btn_ani.SetBool("is_open", true);
        floor_door_ani.SetTrigger("openFloor");

        StartCoroutine(closeFloor());
    }

    IEnumerator closeFloor()
    {
        yield return new WaitForSeconds(5);
        floor_btn_ani.SetBool("is_open", false);
    }
}
