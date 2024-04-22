using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class A_dropBox : MonoBehaviour
{
    private bool btn_L_Set = false;
    private bool btn_R_Set = false;

    private bool btn_L0 = false;
    private bool btn_L1 = false;
    private bool btn_L2 = false;
    private bool btn_L3 = false;
    private bool btn_R0 = false;
    private bool btn_R1 = false;
    private bool btn_R2 = false;
    private bool btn_R3 = false;

    public Animator box;

    public void SetSwitchL(bool activated, int number)
    {
        switch (number)
        {
            case 0:
                btn_L0 = activated;
                break;
            case 1:
                btn_L1 = activated;
                break;
            case 2:
                btn_L2 = activated;
                break;
            case 3:
                btn_L3 = activated;
                break;
            default:
                break;
        }
        CheckSwitch_L();
        
    }

    public void SetSwitchR(bool activated, int number)
    {
        switch (number)
        {
            case 0:
                btn_R0 = activated;
                break;
            case 1:
                btn_R1 = activated;
                break;
            case 2:
                btn_R2 = activated;
                break;
            case 3:
                btn_R3 = activated;
                break;
            default:
                break;
        }
        CheckSwitch_R();
    }

    private void CheckSwitch_L()
    {
        if (!btn_L0 && !btn_L1 && btn_L2 && !btn_L3)
        {
            btn_L_Set = true;
            CheckSwitches();
            print("SetSwitchL");
        }
    }

    private void CheckSwitch_R()
    {
        if (!btn_R0 && btn_R1 && btn_R2 && !btn_R3)
        {
            btn_R_Set = true;
            CheckSwitches();
            print("SetSwitchR");
        }
    }


    private void CheckSwitches()
    {
        // 如果兩個開關都被觸發，打開門，否則關閉門
        if (btn_L_Set && btn_R_Set)
        {
            DropBox();
        }

    }


    private void DropBox()
    {
        box.SetTrigger("is_drop");
    }
}
