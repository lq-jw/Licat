using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

//控制開場動畫

public class Vcam_Begin_controller : MonoBehaviour
{
    public GameObject licat;
    public Animator beginAni;
    public GameObject G_begin;

    //public SpriteRenderer tutorialRender;
    public GameObject G_bed;
    private bool isNewGame = true;

    private void Awake()
    {
        isNewGame = GameManager.instance.GetIsNewGame();
        Debug.Log(isNewGame);
    }
    private void Start()
    {
        Debug.Log(isNewGame);
        //tutorialRender.enabled = false;
        if (!isNewGame)
        {
            licat.SetActive(true);
            G_bed.SetActive(true);
            G_begin.SetActive(false);
            this.gameObject.SetActive(false);
            Debug.Log("Skip openning ani.");
        }
        else
        {
            licat.SetActive(false);
            G_bed.SetActive(false);
            G_begin.SetActive(true);
            GameManager.instance.GotoAniMode(true);      // 淡入，打開動畫黑邊
        }
    }

    void Update()
    {
        bool stateInfo0 = beginAni.GetCurrentAnimatorStateInfo(0).IsName("jump_out_over");
        bool stateInfo1 = beginAni.GetCurrentAnimatorStateInfo(0).IsName("opening_4_over");

        if (stateInfo1)
        {
            this.GetComponent<CinemachineVirtualCamera>().enabled = false;
        }
        if (stateInfo0)
        {
            licat.SetActive(true);
            G_bed.SetActive(true);
            G_begin.SetActive(false);
            //this.GetComponent<CinemachineVirtualCamera>().enabled = false;
            //tutorialRender.enabled = true;
            this.gameObject.SetActive(false);
            GameManager.instance.LeaveAniMode(false);      // 關掉動畫黑邊
        }
    }
}
