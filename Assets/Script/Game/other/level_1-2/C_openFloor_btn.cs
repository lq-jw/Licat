using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_openFloor_btn : PullBtn_controller
{
    private bool isFloorOpen = true;

    protected override void SwitchDoor()
    {
        if (isFloorOpen)
        {
            licat_ani.Play("pull_pole_L");
            floor_btn_ani.SetBool("is_open", false);
            floor_door_ani.SetBool("is_open", false);
            isFloorOpen = false;
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
