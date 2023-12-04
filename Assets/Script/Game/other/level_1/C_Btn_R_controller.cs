using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_Btn_R_controller : MonoBehaviour
{
    public GameObject connectedDoor; // 連接的門

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Box") || collision.CompareTag("Player") || collision.CompareTag("Player_blue") || collision.CompareTag("Player_yallow"))
        {
            connectedDoor.GetComponent<C_Door_controller>().SetSwitch2(true);
            print("switch2 true");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Box") || collision.CompareTag("Player") || collision.CompareTag("Player_blue") || collision.CompareTag("Player_yallow"))
        {
            connectedDoor.GetComponent<C_Door_controller>().SetSwitch2(false);
        }
    }
}
