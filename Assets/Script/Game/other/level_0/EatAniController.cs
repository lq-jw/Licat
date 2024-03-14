using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EatAniController : MonoBehaviour
{
    public Animator eatAni_1;  //紙袋

    public GameObject G_eatAni_2;  //吃怪東西
    public Animator eatAni_2;

    public GameObject G_eatAni_3;  //流出
    public Animator eatAni_3;

    public GameObject G_cupboard;  //水槽
    public GameObject G_floor;     //地板

    public Animator Vcam_flowOut_ani;  //鏡頭

    private bool isPressF = false;
    private bool isEatAni_2_finish = false;
    private bool isEatAni_3_finish = false;

    void Update()
    {
        // 獲取當前動畫狀態
        bool stateInfo0 = eatAni_1.GetCurrentAnimatorStateInfo(0).IsName("eat_over");
        bool stateInfo2 = eatAni_2.GetCurrentAnimatorStateInfo(0).IsName("eat_over_2");
        bool stateInfo3 = eatAni_3.GetCurrentAnimatorStateInfo(0).IsName("flow_out_over");

        isPressF = eatAni_1.GetBool("is_pressF");

        if (stateInfo0 && isEatAni_2_finish == false && isPressF)  //播放吃怪東西、鏡頭的動畫
        {
            G_eatAni_2.SetActive(true);
            isEatAni_2_finish = true;
            Vcam_flowOut_ani.enabled = true;
        }

        if (stateInfo2 && isEatAni_3_finish == false)   //播放流出的動畫
        {
            G_eatAni_3.SetActive(true);
            G_eatAni_2.SetActive(false);
            G_cupboard.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0.6f);
            G_floor.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0.6f);
            isEatAni_3_finish = true;
        }

        if (stateInfo3)   //換關卡
        {
            // 在動畫播放完畢後執行的操作
            Debug.Log("動畫播放完畢。");
            print("switch level");
            //SceneManager.LoadScene("Level_1");
            //SceneManager.LoadScene("PauseScene", LoadSceneMode.Additive);
        }
    }
}
