using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class cam_Begin_controller : MonoBehaviour
{
    public GameObject licat;
    public Animator beginAni;
    public GameObject G_begin;

    public SpriteRenderer tutorialRender;

    private void Start()
    {
        tutorialRender.enabled = false;
    }

    void Update()
    {
        bool stateInfo0 = beginAni.GetCurrentAnimatorStateInfo(0).IsName("jump_out_over");

        if (stateInfo0)
        {
            licat.SetActive(true);
            G_begin.SetActive(false);
            this.GetComponent<CinemachineVirtualCamera>().enabled = false;
            tutorialRender.enabled = true;
            this.gameObject.SetActive(false);
        }
    }
}
