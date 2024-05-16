// 使用在每個主選單UI按鈕當中，賦予物件可以因為 menu btn controller 的選擇就被 hover 的功能
// 使用時子類別需要在 start 呼叫 Initial_selectable_item 函式
// 使用時子類別需要在 update 呼叫 Update_selectable_item 函式
// 處理 animator

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selectable_item : MonoBehaviour
{
    [SerializeField] protected Menu_btn_controller menu_btn_controller;
    [SerializeField] private Animator btn_animator;
    [SerializeField] protected int firstIndex, lastIndex;

    protected void Initial_selectable_item()      // 防呆
    {
        if (lastIndex == 0) lastIndex = firstIndex;
    }

    protected void Update_selectable_item()
    {
        CheckIsHover();
    }

    private void Start()
    {
        Initial_selectable_item();
    }
    private void Update()
    {
        Update_selectable_item();
    }

    private void CheckIsHover()       // 處理 hover
    {
        if (menu_btn_controller.GetSelect() >= firstIndex && menu_btn_controller.GetSelect() <= lastIndex)
        {
            btn_animator.SetBool("btn_hover", true);
        }
        else
        {
            btn_animator.SetBool("btn_hover", false);
        }
    }
}