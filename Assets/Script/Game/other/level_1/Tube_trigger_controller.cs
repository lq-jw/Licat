using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tube_trigger_controller : MonoBehaviour
{
    public GameObject trigger;

    void Start()
    {
        Hide(trigger);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Show(trigger);
        print("enter");
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
