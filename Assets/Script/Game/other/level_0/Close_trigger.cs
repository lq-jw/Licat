using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.SceneManagement;

public class Close_trigger : MonoBehaviour
{
    public GameObject trigger;

    public CinemachineVirtualCamera licat_cam_0;
    public GameObject licat;
    public Cam_controller cam_;


    void Start()
    {
        Hide(trigger);
        //cam_ = GetComponent<Cam_controller>();
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

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            print("switch level");
            SceneManager.LoadScene("Level_1");
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
