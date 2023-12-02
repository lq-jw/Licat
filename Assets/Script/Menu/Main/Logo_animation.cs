// menu openning logo 的 animator 隨機動畫控制器
// 播完後隨機選擇下一個動畫

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Logo_animation : MonoBehaviour
{

    [SerializeField] private Animator animator;
    [SerializeField] private int randInt = 0, iMaxAnimation = 4;
    [SerializeField] private bool isEnd = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        CheckAnimationIsEnd();
        if (isEnd) GetNextAnimation();
    }

    private void CheckAnimationIsEnd()
    {
        // 获取当前层级上的动画状态信息
        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);

        // 检查是否播放到最后一帧
        if (stateInfo.normalizedTime >= 1f) isEnd = true;
        else isEnd = false;
    }

    private void GetNextAnimation()
    {
        randInt = Random.Range(0, iMaxAnimation);
        animator.SetInteger("index", randInt);
    }
}
