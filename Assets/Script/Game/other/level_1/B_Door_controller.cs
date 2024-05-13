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
        // �p�G��Ӷ}�����QĲ�o�A���}���A�_�h������
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
        // ��{���}�����޿�
        //Debug.Log("Door opened!");
        door.SetBool("is_open", false);
        door_light.Play("open");
    }

    public void CloseDoor()
    {
        // ��{���������޿�
        //Debug.Log("Door closed!");
        door.SetBool("is_open", true);
        door_light.Play("close");
    }
}
