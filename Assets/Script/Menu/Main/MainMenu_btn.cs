// 繼承 Menu_btn
// MainMenu 控制的 btn（因為 scenes_controller 需要個別處理）
// 使用時需要在 update 呼叫 SetBtnAction 函數，執行按鈕的各種反應
// 使用時需要完成 CheckIsClick 函式

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu_btn : Menu_btn
{
    // 不知道這裡到底要怎麼決定public private好
    [SerializeField] private MainScenes_Controller scenes_controller;

    // private void Start()
    // {
    //     Initial_menu_btn();
    // }

    private void Update()
    {
        Update_menu_btn();
        if (scenes_controller != null) CheckIsClick();
        // else Debug.Log("Find no MainScenes controller");
    }

    protected override void CheckIsClick()     // 呼叫 scenes_controller 處理按鈕事件
    {
        if (isClick)
        {
            scenes_controller.BtnOnClick(thisIndex, clickMode);
            isClick = false;
        }
    }
}
