using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

//����}���ʵe

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
            SetGameManagerFlag(true);
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
            SetGameManagerFlag(false);
        }
    }

    private void SetGameManagerFlag(bool set)    // �Ω�P�_�O�_�n�������
    {
        GameManager.instance.SetIsAfterLoading(set);
        GameManager.instance.SetIsPlayAni(set);
    }
}
