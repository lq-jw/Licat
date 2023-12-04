// 使用在每個主選單UI按鈕當中，決定按鈕自己到底要不要被hover
// 如果onclick，就呼叫主選單畫面控制的btnOnClick，並把自己的index傳給它
// 使用時子類別需要在 update 呼叫 SetBtnAction 函數，執行按鈕的各種反應
// 使用時子類別需要完成 CheckIsClick 函數


using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public abstract class Menu_btn : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler
{
    [SerializeField] private Mainmenu_btn_controller mainmenu_btn_controller;
    [SerializeField] private Animator btn_animator;
    [SerializeField] protected int thisIndex, clickMode = 0;
    [SerializeField] protected bool isClick = false;

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("onclick");
        MarkIsClick();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        mainmenu_btn_controller.ChangeSelect(thisIndex);
    }

    protected abstract void CheckIsClick();
    protected void SetBtnAction()
    {
        if (mainmenu_btn_controller.GetSelect() == thisIndex)
        {
            // Debug.Log("select" + thisIndex);
            btn_animator.SetBool("btn_hover", true);
            if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Space))
            {
                MarkIsClick();
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                MarkIsClick(1);
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                MarkIsClick(2);
            }
        }
        else
        {
            btn_animator.SetBool("btn_hover", false);
        }
    }

    private void MarkIsClick(int mode = 0)
    {
        isClick = true;
        clickMode = mode;
    }
}
