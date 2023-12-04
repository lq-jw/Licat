using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetMenu_slider : MonoBehaviour
{
    [SerializeField] Menu_btn_controller mainmenu_btn_controller;
    [SerializeField] Animator btn_animator;
    [SerializeField] private int thisIndex;
    [SerializeField] private Slider slider;
    private bool flag = false;
    // Start is called before the first frame update
    void Start()
    {
        flag = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (mainmenu_btn_controller.GetSelect() == thisIndex)
        {
            // Debug.Log("select" + thisIndex);
            flag = true;
            btn_animator.SetBool("btn_hover", true);
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                SetSlider(false);
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                SetSlider(true);
            }
        }
        else
        {
            flag = false;
            btn_animator.SetBool("btn_hover", false);
        }
    }

    private void SetSlider(bool mode)
    {
        if (flag)
        {
            if (mode) SliderIncrease();
            else SliderDecrease();
        }
    }
    private void SliderDecrease()
    {
        slider.value -= 0.1f;
    }
    private void SliderIncrease()
    {
        slider.value += 0.1f;
    }
}
