using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//控制貓抓板提示 F 的顯示
public class CatGrasp_trigger_controller : MonoBehaviour
{
    public GameObject trigger;
    public Animator Big_cat_ani;

    void Start()
    {
        Hide(trigger);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Show(trigger);
        print("enter");
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKeyDown(KeyCode.F) || Input.GetButtonDown("X"))
        {
            Big_cat_ani.Play("_N_R_grasp");
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        Hide(trigger);
        print("exit");
    }


    public void Show(GameObject trigger)
    {
        trigger.SetActive(true);
    }
    public void Hide(GameObject trigger)
    {
        trigger.SetActive(false);
    }
}
