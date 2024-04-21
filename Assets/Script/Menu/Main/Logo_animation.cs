// menu openning logo 的 animator 隨機動畫控制器
// 播完後隨機選擇下一個動畫

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Logo_animation : MonoBehaviour
{

    [SerializeField] private Animator animator;
    [SerializeField] private int randInt = 0, iMaxAnimation = 4;
    [SerializeField] private bool isEnd = false, isRunning = false, isPlaySound = false;

    // Start is called before the first frame update
    void Start()
    {
        AudioManager.instance.PlayBGM("lv1_water");
        PlaySound(0);
    }

    // Update is called once per frame
    void Update()
    {
        if (!isRunning) CheckAnimationIsEnd();
        // if (isEnd) GetNextAnimation();
    }

    private void CheckAnimationIsEnd()
    {
        // 获取当前层级上的动画状态信息
        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);

        // 检查是否播放到最后一帧
        if (stateInfo.normalizedTime >= 1f)
        {
            isRunning = true;
            isEnd = true;
            // Debug.Log("play is end.");
            GetNextAnimation();
            // StartCoroutine(Wait());
        }
        else
        {
            isPlaySound = false;
            isEnd = false;
        }
    }

    private void GetNextAnimation()
    {
        if (isEnd)
        {
            isRunning = true;
            randInt = Random.Range(0, iMaxAnimation);
            animator.SetInteger("index", randInt);
            Debug.Log("Play movie clip" + randInt);
            // isPlaySound = false;
            PlaySound(randInt);
            isEnd = false;
            // StartCoroutine(Wait());
            isRunning = false;
        }
    }
    private void PlaySound(int i)
    {
        if (!isPlaySound)
        {
        // isPlaySound = true;
        // AudioManager.instance.PlaySE("opWaterDrop_" + i);
        // Debug.Log("Play opWaterDrop_" + i);
        }
    }

    IEnumerator Wait()
    {
        Debug.Log("Coroutine started");
        GetNextAnimation();
        yield return new WaitForSeconds(0.75f); // 等待3秒
        Debug.Log("Coroutine resumed after 0.75 seconds");
        // 在這裡繼續執行想要的操作
    }
}
