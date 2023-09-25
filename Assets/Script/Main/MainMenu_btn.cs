using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu_btn : MonoBehaviour
{
    [SerializeField] Mainmenu_btn_controller mainmenu_btn_controller;
    [SerializeField] Animator btn_animator;
    [SerializeField] int thisIndex;
    public GameObject Main_menu;
    public GameObject Set_menu;


    private void Update()
    {
        if (mainmenu_btn_controller.index == thisIndex)
        {
            btn_animator.SetBool("btn_hover", true);
            if (Input.GetKeyDown(KeyCode.Return))
            {
                switch (thisIndex)
                {
                    case 0:
                        SceneManager.LoadScene("gameScene");
                        break;
                    case 1:
                        SceneManager.LoadScene("gameScene");
                        break;
                    case 2:
                        Main_menu.SetActive(false);
                        Set_menu.SetActive(true);
                        break;
                    case 3:
                        //SceneManager.LoadScene("gameScene");
                        break;
                    case 4:
                        //SceneManager.LoadScene("gameScene");
                        break;
                    case 5:
                        Debug.Log("Quit Game");
                        Application.Quit();
                        break;
                    default:
                        break;
                }
            }
        }
        else
        {
            btn_animator.SetBool("btn_hover", false);
        }
    }
}
