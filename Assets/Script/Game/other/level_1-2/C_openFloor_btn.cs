using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_openFloor_btn : PullBtn_controller
{
    public Animator water_ani;
    private bool isFloorOpen = true;

    protected override void SwitchDoor(int licatNum)
    {
        if (isFloorOpen)
        {
            //licat_ani.Play("pull_pole_L");
            switch (licatNum)
            {
                case 0:
                    licat_ani.Play("pull_pole_L");
                    break;
                case 1:
                    licat_blue_ani.Play("pull_pole_L_B");
                    break;
                case 2:
                    licat_yellow_ani.Play("pull_pole_L_Y");
                    break;
                default:
                    break;
            }
            floor_btn_ani.SetBool("is_open", false);
            floor_door_ani.SetBool("is_open", false);
            isFloorOpen = false;
            Hide(trigger);
            water_ani.SetBool("isFloorOpen", true);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isFloorOpen)
        {
            Show(trigger);
        }
        else Hide(trigger);
    }
}
