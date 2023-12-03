using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B_Door_controller : MonoBehaviour
{
    private bool btn_L = false;
    private bool btn_R = false;

    public Animator door;

    public void SetSwitch1(bool activated)
    {
        btn_L = activated;
        CheckSwitches();

        print("btn_L " + btn_L);
    }

    public void SetSwitch2(bool activated)
    {
        btn_R = activated;
        CheckSwitches();

        print("btn_R " + btn_R);
    }

    private void CheckSwitches()
    {
        // �p�G��Ӷ}�����QĲ�o�A���}���A�_�h������
        if (btn_L && btn_R)
        {
            OpenDoor();
            print("open door");
        }
        else
        {
            CloseDoor();
            print("close door");
        }
    }

    public void OpenDoor()
    {
        // ��{���}�����޿�
        Debug.Log("Door opened!");
        door.SetBool("is_open", true);
    }

    public void CloseDoor()
    {
        // ��{���������޿�
        Debug.Log("Door closed!");
        door.SetBool("is_open", false);
    }
}
