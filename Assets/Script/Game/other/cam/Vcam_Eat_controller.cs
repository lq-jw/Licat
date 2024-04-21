using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

//�Y�ǪF�誺���Y�A�b������ F ����|���}
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
            GameManager.instance.SetIsPlayAni(true);    // �s�X�ʵe����
            EatCamSwitch();
        }
    }

    private void EatCamSwitch()
    {
        this.GetComponent<CinemachineVirtualCamera>().enabled = true;
    }
}
