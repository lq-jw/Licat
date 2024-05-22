using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class A_openFloor_btn : PullBtn_controller
{
    protected override void SwitchDoor()
    {
        ani_state = floor_btn_ani.GetBool("is_open");
        if (ani_state)
        {
            //print("string true");
            ani_state = true;
            licat_ani.Play("pull_pole_L");
        }
        else if(!ani_state)
        { 
            //print("string false");
            ani_state = false;
            licat_ani.Play("push_pole_L");
        }
        
        floor_btn_ani.SetBool("is_open", !ani_state);
        floor_door_ani.SetBool("is_open", !ani_state);
        //print("close");
    }




}
