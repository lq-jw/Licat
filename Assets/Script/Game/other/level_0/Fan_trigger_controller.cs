using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fan_trigger_controller : MonoBehaviour
{
    public GameObject trigger;
    public Animator Big_cat_ani;

    void Start()
    {
        Hide(trigger);
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.CompareTag("Player") || collision.CompareTag("Player_blue") || collision.CompareTag("Player_yallow"))
    //    {
    //        Show(trigger);
    //        print("enter");
    //    }

    //}

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") || collision.CompareTag("Player_blue") || collision.CompareTag("Player_yellow"))
        {
            Show(trigger);
            print("enter");
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
