using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Check_point_update : MonoBehaviour
{
    Licat_react_controller Licat_react_controller;

    private void Awake()
    {
        Licat_react_controller = GameObject.FindGameObjectWithTag("Player").GetComponent<Licat_react_controller>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Licat_react_controller.UpdateCheckPoint(transform.position);
        }
    }
}
