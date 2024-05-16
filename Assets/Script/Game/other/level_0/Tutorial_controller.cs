using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Tutorial_controller : MonoBehaviour
{
    public Animator Tutorial_ani;
    public Animator Tutorial_icon_ani;
    public Animator BigCatAni;

    public int Tutorial_Max_count;
    private int Tutorial_count = 0;
    private bool b_Move_check;
    private bool b_Jump_check;
    private bool b_JumpDown_check;
    private bool b_Meow_check;
    private bool b_AllTutorial_check = false;

    private float timer = 0;
    private float TutorialAni_countDown = 3f;

    void Start()
    {
        UpdateIconMode();
    }

    void Update()
    {
        timer += Time.deltaTime;
        UpdateIconMode();
        if (b_AllTutorial_check == false)
        {
            TutorialAni();
        }
        else if (b_AllTutorial_check == true && timer > TutorialAni_countDown)
        {
            RandomTutorialAni();
            timer = 0;
        }
    }

    private void TutorialAni()
    {
        if (!b_Move_check) b_Move_check = BigCatAni.GetBool("is_move") || BigCatAni.GetBool("is_move_R");
        if (!b_Jump_check) b_Jump_check = Input.GetKeyDown(KeyCode.Space) || Input.GetButtonDown("A");
        if (!b_JumpDown_check) b_JumpDown_check = Input.GetKeyDown(KeyCode.S) || Input.GetAxisRaw("Vertical") == -1;
        if (!b_Meow_check) b_Meow_check = Input.GetKeyDown(KeyCode.C) || Input.GetButtonDown("LB");


        if (Tutorial_count == 3 && b_Meow_check)
        {
            b_AllTutorial_check = true;
        }
        else if (b_Move_check && b_Jump_check && b_JumpDown_check)
        {
            Tutorial_count = 3;
            UpdateTutorialAni();
        }
        else if (b_Move_check && b_Jump_check)
        {
            Tutorial_count = 2;
            UpdateTutorialAni();
        }
        else if (b_Move_check)
        {
            Tutorial_count = 1;
            UpdateTutorialAni();
        }
    }

    private void RandomTutorialAni()
    {
        Tutorial_count = Random.Range(0, Tutorial_Max_count);
        UpdateTutorialAni();
    }

    private void UpdateTutorialAni()
    {
        Tutorial_ani.SetInteger("Tutorial_controller", Tutorial_count);
        Tutorial_icon_ani.SetInteger("Tutorial_icon_controller", Tutorial_count);
    }

    private void UpdateIconMode()
    {       // 用於根據 handle 顯示對應教學圖片，以 game manager 為主
        Tutorial_icon_ani.SetBool("isUseHandle", GameManager.instance.GetIsUseHandle());
    }
}
