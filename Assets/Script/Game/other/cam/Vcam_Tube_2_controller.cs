using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Vcam_Tube_2_controller : MonoBehaviour
{
    public GameObject licat;
    public Animator catAni;
    public GameObject G_begin;
    public Animator beginAni;
    public GameObject licatPosition;

    public GameObject G_lv_1_2_2;
    public GameObject Vcam_1;
    public GameObject Vcam_2;


    private Vector3 G_begin_position;

    private void Start()
    {
        Vcam_1.SetActive(false);
        Vcam_2.SetActive(false);
        licat.transform.position = licatPosition.transform.position;
        catAni.SetBool("is_solid", false);
        GameManager.instance.GotoAniMode(true);      // 淡入，打開動畫黑邊
    }

    void Update()
    {
        bool stateInfo0 = beginAni.GetCurrentAnimatorStateInfo(0).IsName("1");
        bool stateInfo1 = beginAni.GetCurrentAnimatorStateInfo(0).IsName("2");

        if (stateInfo0)
        {
            Invoke("closeCam", 2.3f);

            //licat.SetActive(true);

            catAni.SetBool("is_faceRight", true);
        }
        else if (stateInfo1)
        {
            G_begin_position = G_begin.transform.position;
            G_begin_position.x = (G_begin_position.x) - 0.3f;
            G_begin_position.y = (G_begin_position.y) + 0.3f;
            licat.transform.position = G_begin_position;

            G_lv_1_2_2.SetActive(false);
            G_begin.SetActive(false);
            this.gameObject.SetActive(false);
            GameManager.instance.LeaveAniMode(false);      // 關掉動畫黑邊
        }
    }

    private void closeCam()
    {
        this.GetComponent<CinemachineVirtualCamera>().enabled = false;
    }
}
