using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BringPlatformCat : MonoBehaviour
{
    public B_elevator_down B_Elevator_Down;
    private GameObject catOnPlatform;
    public GameObject platform;
    private Vector3 V3_cat;

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Box") || collision.gameObject.CompareTag("Player_blue") || collision.gameObject.CompareTag("Player_yellow"))
        {
            catOnPlatform = collision.gameObject;
            print("catOnPlatform " + catOnPlatform.name);
            //movePlatform();
            B_Elevator_Down.GetPlatformCat(catOnPlatform);
            //V3_cat = catOnPlatform.transform.position;
            //V3_cat.x = platform.transform.position.x;
        }
    }
}
