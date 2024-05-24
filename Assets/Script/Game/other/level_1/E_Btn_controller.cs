using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E_Btn_controller : PullBtn_controller
{
    public Animator floor_door_L_ani;

    private bool isdoorOpen = true;

    protected override void SwitchDoor(int licatNum)
    {
        if (isdoorOpen)
        {
            floor_btn_ani.SetBool("is_open", false);
            floor_door_ani.SetBool("is_open", false);
            floor_door_L_ani.SetBool("is_open", false);
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

            isdoorOpen = !isdoorOpen;
            Hide(trigger);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isdoorOpen)
        {
            Show(trigger);
        }
        else Hide(trigger);
    }
}
