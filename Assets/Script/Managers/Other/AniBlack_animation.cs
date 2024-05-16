// pause menu 的 aniblack 的 animator

// GotoAniMode：進入動畫模式，有上下兩個黑帶，接收一個 bool
// ＾true > 開頭有淡入，用在關卡開頭的動畫，請放在播放動畫前
//   false（預設） > 無淡入，用在關卡中間

// LeaveAniMode：離開動畫模式，上下兩個黑帶移開，接收一個 bool
// ＾true > 結尾有淡出，用在關卡結尾的動畫，時機請看下面
//   false（預設） > 無淡出，用在關卡中間

// 如果要黑色淡出離開並載入的話，進入動畫後把 isGoingToLoad 設 true
// ＾接著抓播放進度到 0.75f（可自己決定，1是播完）時 isPlayAni 設 false
// ＾因為載入會讓一切都卡住...

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AniBlack_animation : MonoBehaviour
{

    [SerializeField] private Animator animator;
    [SerializeField] private bool isPlayAni, isAfterLoading, isGoingToLoad;

    // Start is called before the first frame update
    void Start()
    {
        isPlayAni = GameManager.instance.GetIsPlayAni();
        isAfterLoading = GameManager.instance.GetIsAfterLoading();
        isGoingToLoad = GameManager.instance.GetIsGoingToLoad();
        animator.SetBool("isPlayAni", isPlayAni);
        animator.SetBool("isAfterLoading", isAfterLoading);
        animator.SetBool("isGoingToLoad", isGoingToLoad);
    }

    // Update is called once per frame
    void Update()
    {
        UpdateFlag();
    }

    private void UpdateFlag()
    {
        if (isPlayAni != GameManager.instance.GetIsPlayAni())
        {
            isPlayAni = GameManager.instance.GetIsPlayAni();
            animator.SetBool("isPlayAni", isPlayAni);
        }
        if (isAfterLoading != GameManager.instance.GetIsAfterLoading())
        {
            isAfterLoading = GameManager.instance.GetIsAfterLoading();
            animator.SetBool("isAfterLoading", isAfterLoading);
        }
        if (isGoingToLoad != GameManager.instance.GetIsGoingToLoad())
        {
            isGoingToLoad = GameManager.instance.GetIsGoingToLoad();
            animator.SetBool("isGoingToLoad", isGoingToLoad);
        }
    }

}
