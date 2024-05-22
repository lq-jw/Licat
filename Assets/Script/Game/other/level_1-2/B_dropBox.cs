using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//±¼¸¨½c¤l
public class B_dropBox : PullBtn_controller
{
    private bool is_press = false;

    protected override void SwitchDoor(int licatNum)
    {
        if (!is_press)
        {
            floor_btn_ani.SetBool("is_open", false);
            floor_door_ani.SetTrigger("is_drop");
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
            is_press = !is_press;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!is_press)
        {
            Show(trigger);
        }
        else Hide(trigger);
    }
}
