using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B_verticleDoor_btn : Btn_controller
{
    public GameObject connectDoor;
    public int btnNumber;


    protected override void OnBtnStay()
    {
        connectDoor.GetComponent<B_verticleDoor>().SetBtn(true, btnNumber);
    }

    protected override void OnBtnExit()
    {
        connectDoor.GetComponent<B_verticleDoor>().SetBtn(false, btnNumber);
    }
}
