using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B_openFloor_btn1 : PullBtn_controller
{
    protected override void SwitchDoor(int licatNum)
    {
        //licat_ani.Play("push_pole_L");
        floor_btn_ani.SetBool("is_open", true);
        floor_door_ani.SetTrigger("openFloor");
        switch (licatNum)
        {
            case 0:
                licat_ani.Play("push_pole_L");
                break;
            case 1:
                licat_blue_ani.Play("push_pole_L_B");
                break;
            case 2:
                licat_yellow_ani.Play("push_pole_L_Y");
                break;
            default:
                break;
        }
        StartCoroutine(closeFloor());
    }

    IEnumerator closeFloor()
    {
        yield return new WaitForSeconds(1);
        floor_btn_ani.SetBool("is_open", false);
    }
}
