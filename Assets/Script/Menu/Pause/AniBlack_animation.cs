// pause menu 的 aniblack 的 animator
// loader 會自動把 isPlayAni isGoingToLoad 設 false，isAfterLoading 設 true

// 換關卡後，如果沒有要播動畫，請把 isAfterLoading 設 false

// 黑色淡入＋黑帶，isAfterLoading 設 true（loader會自動設定），接著 isPlayAni 設 true
// ＾離開劇情並進遊戲時兩個都設 false（最好三個都false）

// 單純黑帶：isPlayAni 設 true，isAfterLoading 設 false

// 如果要黑色淡出離開並載入的話，進入動畫後把 isGoingToLoad 設 true
// ＾接著抓播放進度到 0.75f（自己決定，1是播完）時 isPlayAni 設 false
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
