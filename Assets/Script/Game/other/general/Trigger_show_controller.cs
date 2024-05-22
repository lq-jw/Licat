using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger_show_controller : MonoBehaviour
{
    public GameObject obj;
    private int triggerCounter = 0;

    void Start()
    {
        Hide(obj);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Player_blue") || collision.gameObject.CompareTag("Player_yellow"))
        {
            Show(obj);
            print("enter");
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Player_blue") || collision.gameObject.CompareTag("Player_yellow"))
        {
            Hide(obj);
            print("exit");
        }
    }

    public void Show(GameObject obj)
    {
        obj.SetActive(true);
    }
    public void Hide(GameObject obj)
    {
        obj.SetActive(false);
    }
}
