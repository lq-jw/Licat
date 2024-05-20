using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tube_trigger_controller : MonoBehaviour
{
    public GameObject trigger;
    public Animator Big_cat_ani;
    private int triggerCounter = 0;

    void Start()
    {
        Hide(trigger);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Player_blue") || collision.gameObject.CompareTag("Player_yellow"))
        {
            if (Big_cat_ani.GetBool("is_solid") == false)
            {
                Show(trigger);
                print("enter");
            }
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Player_blue") || collision.gameObject.CompareTag("Player_yellow"))
        {
            Hide(trigger);
            print("exit");
        }
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
