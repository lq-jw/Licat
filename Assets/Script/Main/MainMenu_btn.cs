// 使用在每個主選單UI按鈕當中，決定按鈕自己到底要不要被hover
// 如果onclick，就呼叫主選單畫面控制的btnOnClick，並把自己的index傳給它

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu_btn : MonoBehaviour
{
    // 不知道這裡到底要怎麼決定public private好
    [SerializeField] Mainmenu_btn_controller mainmenu_btn_controller;
    [SerializeField] MainScenes_Controller mainScenes_controller;
    [SerializeField] Animator btn_animator;
    [SerializeField] private int thisIndex;

    private void Update()
    {
        if (mainmenu_btn_controller.GetSelect() == thisIndex)
        {
            // Debug.Log("select" + thisIndex);
            btn_animator.SetBool("btn_hover", true);
            if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Space))
            {
                mainScenes_controller.BtnOnClick(thisIndex);
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                mainScenes_controller.BtnOnClick(thisIndex, 1);
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                mainScenes_controller.BtnOnClick(thisIndex, 2);
            }
        }
        else
        {
            btn_animator.SetBool("btn_hover", false);
        }
    }
}
