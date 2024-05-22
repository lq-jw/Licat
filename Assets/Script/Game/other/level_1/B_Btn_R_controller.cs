using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B_Btn_R_controller : Btn_controller
{
    public GameObject connectedDoor; // �s������

    protected override void OnBtnEnter()
    {
        connectedDoor.GetComponent<B_Door_controller>().SetSwitch2(true);
    }

    protected override void OnBtnExit()
    {
        connectedDoor.GetComponent<B_Door_controller>().SetSwitch2(false);
    }
}
