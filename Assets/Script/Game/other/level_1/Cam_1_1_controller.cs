using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Cam_1_1_controller : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<CinemachineVirtualCamera>().enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) this.GetComponent<CinemachineVirtualCamera>().enabled = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) this.GetComponent<CinemachineVirtualCamera>().enabled = false;
    }
}
