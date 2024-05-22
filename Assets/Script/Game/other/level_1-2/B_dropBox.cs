using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//±¼¸¨½c¤l
public class B_dropBox : PullBtn_controller
{
    private bool is_press = false;

    protected override void SwitchDoor()
    {
        if (!is_press)
        {
            floor_btn_ani.SetBool("is_open", false);
            floor_door_ani.SetTrigger("is_drop");
            licat_ani.Play("pull_pole_L");
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
