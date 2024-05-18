using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B_verticleDoor : MonoBehaviour
{
    public Animator doorAni;

    private bool btnL = false;
    private bool btnR = false;

    public void SetBtn(bool activated, int number)
    {
        if (number == 0)
        {
            btnL = activated;
        }else if (number == 1)
        {
            btnR = activated;
        }

        CheckSwitch();
    }

    private void CheckSwitch()
    {
        print("btnL " + btnL);
        print("btnR " + btnR);
        if (btnL == true && btnR == true)
        {
            doorAni.SetBool("is_open",false);
        }
        else
        {
            doorAni.SetBool("is_open", true);
        }
    }
}
