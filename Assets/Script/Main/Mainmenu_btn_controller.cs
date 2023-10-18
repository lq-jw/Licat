// 控制menu的選取，並輸出所選取的值給btn判斷要不要變成selected

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mainmenu_btn_controller : MonoBehaviour
{
    private int index;
    [SerializeField] private bool keyDown;
    [SerializeField] private int maxIndex;      // 每個menu的max都不一樣，要手動輸入


    public int GetSelect()      // 輸出選取值
    {
        return index;
    }
    public void ChangeSelect(int select = 0)        // 原本要用但暫時沒有用到
    {
        if (select < 0) index = -1;
        else if (select > maxIndex) index = maxIndex;
        // ^ 防呆
        else index = select;
        Debug.Log("change" + select);
    }

    private void Update()
    {
        if (Input.GetAxis("Vertical") != 0)
        {
            if (!keyDown)
            {
                if (Input.GetAxis("Vertical") < 0)
                {
                    if (index < maxIndex)
                    {
                        index++;
                    }
                    else
                    {
                        index = 0;
                    }
                }
                else if (Input.GetAxis("Vertical") > 0)
                {
                    if (index > 0)
                    {
                        index--;
                    }
                    else
                    {
                        index = maxIndex;
                    }
                }
                keyDown = true;
            }
        }
        else
        {
            keyDown = false;
        }
    }
}
