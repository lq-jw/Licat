using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.SceneManagement;

//控制吃怪東西的動畫

public class Close_trigger : MonoBehaviour
{
    public GameObject trigger;
    public Animator eatAni;
    public GameObject Cat;
    public GameObject S_eatAniController;

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
            S_eatAniController.SetActive(true);
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
