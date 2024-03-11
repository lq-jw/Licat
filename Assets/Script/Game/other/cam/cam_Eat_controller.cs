using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class cam_Eat_controller : MonoBehaviour
{
    public bool isEatAniTrigger = false;

    void Start()
    {
        this.GetComponent<CinemachineVirtualCamera>().enabled = false;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKeyDown(KeyCode.F) || Input.GetButtonDown("X"))
        {
            EatCamSwitch();
        }
    }

    private void EatCamSwitch()
    {
        this.GetComponent<CinemachineVirtualCamera>().enabled = true;
    }
}
