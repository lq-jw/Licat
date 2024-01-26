using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Cam_controller : MonoBehaviour
{
    public CinemachineVirtualCamera vCam_licat;
    public CinemachineVirtualCamera vCam_blue;
    public CinemachineVirtualCamera vCam_yellow;

    public GameObject blue_licat;
    public GameObject yellow_licat;

    void Update()
    {
        Cam_change();
    }


    public virtual void Cam_change()
    {
        if (blue_licat.GetComponent<Licat_blue_move_controller>().enabled && yellow_licat.GetComponent<Licat_yellow_move_controller>().enabled == false)
        {
            //print("vCam_blue  ON");
            vCam_licat.enabled = false;
            vCam_yellow.enabled = false;
            vCam_blue.enabled = true;
        }
        else if (blue_licat.GetComponent<Licat_blue_move_controller>().enabled == false && yellow_licat.GetComponent<Licat_yellow_move_controller>().enabled)
        {
            //print("vCam_yellow  ON");
            vCam_licat.enabled = false;
            vCam_blue.enabled = false;
            vCam_yellow.enabled = true;
        }
        else
        {
            //print("vCam_licat  ON");
            vCam_blue.enabled = false;
            vCam_yellow.enabled = false;
            vCam_licat.enabled = true;
        }
    }
}