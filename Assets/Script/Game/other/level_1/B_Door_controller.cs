using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B_Door_controller : MonoBehaviour
{
    private bool btn_L = false;
    private bool btn_R = false;

    public Animator door;
    public Animator door_light;

    public void SetSwitch1(bool activated)
    {
        btn_L = activated;
        CheckSwitches();

        //print("btn_L " + btn_L);
    }

    public void SetSwitch2(bool activated)
    {
        btn_R = activated;
        CheckSwitches();

       //print("btn_R " + btn_R);
    }

    private void CheckSwitches()
    {
        // 如果兩個開關都被觸發，打開門，否則關閉門
        if (btn_L && btn_R)
        {
            OpenDoor();
            //door_light.Play("open");
            //print("open door");
        }
        else
        {
            CloseDoor();
            //door_light.Play("close");
            //print("close door");
        }
    }

    public void OpenDoor()
    {
        // 實現打開門的邏輯
        //Debug.Log("Door opened!");
        door.SetBool("is_open", false);
        door_light.Play("open");
    }

    public void CloseDoor()
    {
        // 實現關閉門的邏輯
        //Debug.Log("Door closed!");
        door.SetBool("is_open", true);
        door_light.Play("close");
    }
}
