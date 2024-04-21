using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

//吃怪東西的鏡頭，在接收到 F 之後會打開
public class Vcam_Eat_controller : MonoBehaviour
{
    void Start()
    {
        this.GetComponent<CinemachineVirtualCamera>().enabled = false;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKeyDown(KeyCode.F) || Input.GetButtonDown("X"))
        {
            GameManager.instance.SetIsPlayAni(true);    // 叫出動畫黑邊
            EatCamSwitch();
        }
    }

    private void EatCamSwitch()
    {
        this.GetComponent<CinemachineVirtualCamera>().enabled = true;
    }
}
