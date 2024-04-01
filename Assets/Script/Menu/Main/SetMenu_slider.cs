// 母類別包含 menu_btn_controller, firstIndex, lastIndex

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetMenu_slider : Hoverable_item
{
    [SerializeField] private Slider slider;
    private float volume = 0.5f;
    private bool flag = false;
    private string type = "";

    // Start is called before the first frame update
    void Start()
    {
        Initial_hoverable_item();
        flag = false;
        switch (thisIndex)
        {
            case 0:
                type = "bgmVolume";
                break;
            case 1:
                type = "seVolume";
                break;
            default:
                break;
        }
        volume = GameManager.instance.GetVolume(type);
        slider.value = volume;
        Debug.Log("init "+type+" = "+volume);
    }

    // Update is called once per frame
    void Update()
    {
        Update_hoverable_item();
        if (menu_btn_controller.GetSelect() == thisIndex)
        {
            // Debug.Log("select" + thisIndex);
            flag = true;

            if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetButtonDown("LB"))
            {
                SetSlider(false);
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetButtonDown("RB"))
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
            if (mode) SliderIncrease(); // +
            else SliderDecrease();      // -
        }
        if (volume < 0f) volume = 0f;
        if (volume > 1f) volume = 1f;
        UpdateSliderAndVolume();
    }
    private void SliderDecrease()
    {
        volume -= 0.1f;
    }
    private void SliderIncrease()
    {
        volume += 0.1f;
    }

    private void UpdateSliderAndVolume()
    {
        slider.value = volume;
        GameManager.instance.SetSettings(type, volume);
    }
}
