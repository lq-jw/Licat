// pause menu 的 aniblack 的 animator

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AniBlack_animation : MonoBehaviour
{

    [SerializeField] private Animator animator;
    [SerializeField] private bool isPlayAni, isAfterLoading;

    // Start is called before the first frame update
    void Start()
    {
        isPlayAni = GameManager.instance.GetIsPlayAni();
        isAfterLoading = GameManager.instance.GetIsAfterLoading();
        animator.SetBool("isPlayAni", isPlayAni);
        animator.SetBool("isAfterLoading", isAfterLoading);
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
    }

}
