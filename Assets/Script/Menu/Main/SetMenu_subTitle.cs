using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SetMenu_subTitle : MonoBehaviour
{
    [SerializeField] Mainmenu_btn_controller mainmenu_btn_controller;
    [SerializeField] Animator btn_animator;
    [SerializeField] private int firstIndex, lastIndex;

    private void Update()
    {
        if (mainmenu_btn_controller.GetSelect() >= firstIndex && mainmenu_btn_controller.GetSelect() <= lastIndex)
        {
            btn_animator.SetBool("btn_hover", true);
        }
        else
        {
            btn_animator.SetBool("btn_hover", false);
        }
    }
}