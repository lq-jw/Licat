using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Check_point_update : MonoBehaviour
{
    Licat_react_controller Licat_react_controller;
    Licat_react_yellow_controller Licat_react_yellow_controller;
    Licat_react_blue_controller Licat_react_blue_controller;

    private void Awake()
    {
        Licat_react_controller = GameObject.FindGameObjectWithTag("Player").GetComponent<Licat_react_controller>();
        Licat_react_blue_controller = GameObject.FindGameObjectWithTag("Player_blue").GetComponent<Licat_react_blue_controller>();
        Licat_react_yellow_controller = GameObject.FindGameObjectWithTag("Player_yellow").GetComponent<Licat_react_yellow_controller>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") || collision.CompareTag("Player_blue") || collision.CompareTag("Player_yellow"))
        {
            Licat_react_controller.UpdateCheckPoint(transform.position);
            Licat_react_yellow_controller.UpdateCheckPoint(transform.position);
            Licat_react_blue_controller.UpdateCheckPoint(transform.position);
        }
    }
}
