using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Light_1_1_controller : MonoBehaviour
{
    public GameObject G_light;
    private bool is_lightOn = true;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") || collision.CompareTag("Player_blue") || collision.CompareTag("Player_yellow"))  //¸I¨ì¤ô·¾(¦º)
        {
            print("passBySwitch");
            if (is_lightOn)
            {
                G_light.SetActive(false);
                is_lightOn = !is_lightOn;
            }
            else if (!is_lightOn)
            {
                G_light.SetActive(true);
                is_lightOn = !is_lightOn;
            }
        }
    }
}
