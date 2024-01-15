using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetMenu_slider : Hoverable_item
{
    [SerializeField] private Slider slider;
    private bool flag = false;

    // Start is called before the first frame update
    void Start()
    {
        Initial_hoverable_item();
        flag = false;
    }

    // Update is called once per frame
    void Update()
    {
        Update_hoverable_item();
        if (menu_btn_controller.GetSelect() == thisIndex)
        {
            // Debug.Log("select" + thisIndex);
            flag = true;

            if (Input.GetAxis("Horizontal") == -1)
            {
                SetSlider(false);
            }
            else if (Input.GetAxis("Horizontal") == 1)
            {
                SetSlider(true);
            }
        }
        else
        {
            flag = false;
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
