using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GearingPlatform_sub : MonoBehaviour
{
    public GearingPlatform gearingPlatform;
    private GameObject catOnPlatform;

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Box") || collision.gameObject.CompareTag("Player_blue") || collision.gameObject.CompareTag("Player_yellow"))
        {
            catOnPlatform = collision.gameObject;
            //movePlatform();
            gearingPlatform.GetOtherCat(catOnPlatform);
        }
    }
}
