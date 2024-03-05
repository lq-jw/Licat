using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.SceneManagement;

public class Close_trigger : MonoBehaviour
{
    public GameObject trigger;
    public Animator eatAni;
    public GameObject Cat;

    public bool isPressF = false;


    void Start()
    {
        Hide(trigger);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Show(trigger);
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        Hide(trigger);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKeyDown(KeyCode.F) || Input.GetButtonDown("X"))
        {
            eatAni.SetBool("is_pressF", true);
            Cat.SetActive(false);
            isPressF = true;
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
