// 使用在每個主選單UI按鈕當中，賦予物件可以被滑鼠 hover 的功能
// 使用時子類別需要在 start 呼叫 Initial_hoverable_item 函式
// 使用時子類別需要在 update 呼叫 CheckIsHover 函式
// 母類別包含menu_btn_controller, firstIndex, lastIndex
// 母類別處理 animator（不可調用）、btn選擇

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Hoverable_item : Selectable_item, IPointerEnterHandler
{
    [SerializeField] protected int thisIndex;

    protected void Initial_hoverable_item()      // 防呆
    {
        Initial_selectable_item();
        firstIndex = thisIndex;
        lastIndex = thisIndex;
    }

    protected void Update_hoverable_item()
    {
        Update_selectable_item();
    }

    private void Start()
    {
        Initial_hoverable_item();
    }

    // private void Update()
    // {
    //     Update_hoverable_item();
    // }

    public void OnPointerEnter(PointerEventData eventData)
    {
        menu_btn_controller.ChangeSelect(thisIndex);
    }
}
