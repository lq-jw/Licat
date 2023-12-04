using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B_Btn_L_controller : MonoBehaviour
{
    public Animator btn_ani;
    public GameObject connectedDoor; // 連接的門

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Box") || collision.CompareTag("Player") || collision.CompareTag("Player_blue") || collision.CompareTag("Player_yallow"))
        {
            connectedDoor.GetComponent<B_Door_controller>().SetSwitch1(true);
            print("switch1 true");
            btn_ani.SetBool("is_trigger", true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Box") || collision.CompareTag("Player") || collision.CompareTag("Player_blue") || collision.CompareTag("Player_yallow"))
        {
            connectedDoor.GetComponent<B_Door_controller>().SetSwitch1(false);
            btn_ani.SetBool("is_trigger", false);
        }
    }
}
