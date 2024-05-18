using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_Btn_L_controller : Btn_controller
{
    public GameObject connectedDoor; // �s������

    protected override void OnBtnEnter()
    {
        connectedDoor.GetComponent<C_Door_controller>().SetSwitch1(true);
    }

    protected override void OnBtnExit()
    {
        connectedDoor.GetComponent<C_Door_controller>().SetSwitch1(false);
    }
}
