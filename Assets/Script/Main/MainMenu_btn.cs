// 使用在每個主選單UI按鈕當中，決定按鈕自己到底要不要被hover
// 如果onclick，就呼叫主選單畫面控制的btnOnClick，並把自己的index傳給它

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu_btn : MonoBehaviour
{
    [SerializeField] Mainmenu_btn_controller mainmenu_btn_controller;
    [SerializeField] MainScenes_Controller mainScenes_controller;
    [SerializeField] Animator btn_animator;
    [SerializeField] int thisIndex;
    public GameObject Main_menu;
    public GameObject Set_menu;

    private void Update()
    {
        if (mainmenu_btn_controller.index == thisIndex)
        {
            Debug.Log("select" + thisIndex);
            btn_animator.SetBool("btn_hover", true);
            if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Space))
            {
                // Debug.Log("123");
                mainScenes_controller.BtnOnClick(thisIndex);
                //         switch (thisIndex)
                //         {
                //             case 0:
                //                 SceneManager.LoadScene("gameScene");
                //                 break;
                //             case 1:
                //                 SceneManager.LoadScene("gameScene");
                //                 break;
                //             case 2:

                //                 Main_menu.SetActive(false);
                //                 Set_menu.SetActive(true);


                //                 break;
                //             case 3:
                //                 //SceneManager.LoadScene("gameScene");
                //                 break;
                //             case 4:
                //                 //SceneManager.LoadScene("gameScene");
                //                 break;
                //             case 5:
                //                 Debug.Log("Quit Game");
                //                 Application.Quit();
                //                 break;
                //             default:
                //                 break;
                //         }
            }
        }
        else
        {
            btn_animator.SetBool("btn_hover", false);
        }
    }
}
