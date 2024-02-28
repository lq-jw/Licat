// 繼承 Hoverable_item
// 使用在每個主選單UI按鈕當中，處理按鈕的 click（不包含執行內容）
// 如果onclick，就呼叫主選單畫面控制的btnOnClick，並把自己的index傳給它
// 不可單獨使用
// 使用時子類別需要在 update 呼叫 SetBtnAction 函數，執行按鈕的各種反應
// 使用時子類別需要完成 CheckIsClick 函式
// 母類別包含menu_btn_controller, thisIndex
// 母類別處理 animator（不可調用）、btn選擇、滑鼠hover

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public abstract class Menu_btn : Hoverable_item, IPointerClickHandler
{
    [SerializeField] protected int clickMode = 0;
    [SerializeField] protected bool isClick = false;
    [SerializeField] private HandleState_passer passer;

    protected void Initial_menu_btn()      // 防呆
    {
        Initial_hoverable_item();
    }
    protected void Update_menu_btn()
    {
        Update_hoverable_item();
        SetBtnAction();
    }

    void Awake()
    {
        passer = GameObject.FindObjectOfType<HandleState_passer>();
    }

    protected abstract void CheckIsClick();     // 須完成

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("onclick");
        MarkIsClick();
    }

    private void SetBtnAction()       // update
    {
        if (menu_btn_controller.GetSelect() == thisIndex)
        {
            // Debug.Log("select" + thisIndex);
            if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Space))
            {
                MarkIsClick();
                passer.SetIsHandle(false);
            }
            else if (Input.GetButtonDown("A"))
            {
                MarkIsClick();
                passer.SetIsHandle(true);
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetButtonDown("LB"))
            {
                MarkIsClick(1);
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetButtonDown("RB"))
            {
                MarkIsClick(2);
            }
        }
    }

    private void MarkIsClick(int mode = 0)
    {
        Debug.Log("mode" + mode);
        isClick = true;
        clickMode = mode;
    }
}
