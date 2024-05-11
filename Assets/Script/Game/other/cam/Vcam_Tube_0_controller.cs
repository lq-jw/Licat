using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Vcam_Tube_0_controller : MonoBehaviour
{
    public GameObject licat;
    public Animator beginAni;
    public Animator catAni;
    public GameObject G_begin;

    private Vector3 G_begin_position;

    private void Start()
    {
        catAni.SetBool("is_solid", false);
        GameManager.instance.GotoAniMode(true);      // �H�J�A���}�ʵe����
    }

    void Update()
    {
        bool stateInfo0 = beginAni.GetCurrentAnimatorStateInfo(0).IsName("_1");
        bool stateInfo1 = beginAni.GetCurrentAnimatorStateInfo(0).IsName("_2");

        if (stateInfo0)
        {
            Invoke("closeCam", 2.3f);
            catAni.SetBool("is_faceRight", true);
        }
        else if (stateInfo1)
        {
            G_begin_position = G_begin.transform.position;
            G_begin_position.x = (G_begin_position.x) - 0.3f;
            G_begin_position.y = (G_begin_position.y) + 0.3f;
            licat.transform.position = G_begin_position;

            G_begin.SetActive(false);
            this.gameObject.SetActive(false);
            GameManager.instance.LeaveAniMode(false);      // �����ʵe����
        }
    }

    private void closeCam()
    {
        this.GetComponent<CinemachineVirtualCamera>().enabled = false;
    }
}
