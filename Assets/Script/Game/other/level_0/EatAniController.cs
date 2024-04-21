using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EatAniController : MonoBehaviour
{
    [SerializeField] private ASyncLoader Loader;

    public Animator eatAni_1;  //�ȳU

    public GameObject G_eatAni_2;  //�Y�ǪF��
    public Animator eatAni_2;

    public GameObject G_eatAni_3;  //�y�X
    public Animator eatAni_3;

    public GameObject G_cupboard;  //����
    public GameObject G_floor;     //�a�O

    public Animator Vcam_flowOut_ani;  //���Y

    private bool isPressF = false;
    private bool isEatAni_2_finish = false;
    private bool isEatAni_3_finish = false;

    void Awake()
    {
        ASyncLoader Loader = GameObject.FindObjectOfType<ASyncLoader>();
    }

    void Update()
    {
        // �����e�ʵe���A
        bool stateInfo0 = eatAni_1.GetCurrentAnimatorStateInfo(0).IsName("eat_over");
        bool stateInfo2 = eatAni_2.GetCurrentAnimatorStateInfo(0).IsName("eat_over_2");
        bool stateInfo3 = eatAni_3.GetCurrentAnimatorStateInfo(0).IsName("flow_out_over");

        isPressF = eatAni_1.GetBool("is_pressF");

        if (stateInfo0 && isEatAni_2_finish == false && isPressF)  //����Y�ǪF��B���Y���ʵe
        {
            G_eatAni_2.SetActive(true);
            isEatAni_2_finish = true;
            Vcam_flowOut_ani.enabled = true;
        }

        if (stateInfo2 && isEatAni_3_finish == false)   //����y�X���ʵe
        {
            G_eatAni_3.SetActive(true);
            G_eatAni_2.SetActive(false);
            G_cupboard.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0.6f);
            G_floor.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0.6f);
            isEatAni_3_finish = true;
        }
        CheckAnimation3IsEnd();

        if (stateInfo3)   //�����d
        {
            // �b�ʵe���񧹲�����檺�ާ@
            Debug.Log("�ʵe���񧹲��C");
            print("switch level");
            GameManager.instance.LeaveAniMode(false); if (Loader != null)
            {
                Loader.LoadScene("Level_1", true);
            }
            else
            {
                SceneManager.LoadScene("Level_1");
                SceneManager.LoadScene("PauseScene", LoadSceneMode.Additive);
            }
        }
    }

    private void CheckAnimation3IsEnd()
    {
        // ���o�ʵe�v�檬�p
        AnimatorStateInfo stateInfo = eatAni_3.GetCurrentAnimatorStateInfo(0);

        Debug.Log(stateInfo.normalizedTime);
        // �ˬd�O�_�����w�d��]1���̫�^
        if (stateInfo.normalizedTime >= 0.75f)
        {
            GameManager.instance.LeaveAniMode(true);
            Debug.Log("Animation3 is going to end.");
        }
    }
}
